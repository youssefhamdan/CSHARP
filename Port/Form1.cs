﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Collections;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace Port
{
    public partial class Form1 : Form
    {

        static string NOMFICHIER = "config.txt";
        List<Byte> listeSerial = new List<byte>();
        ArrayList listeTrier = new ArrayList();
       


        public Form1()
        {
            InitializeComponent();
        }

        AutoResetEvent waitHandle = new AutoResetEvent(false);
        private void Form1_Load(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 3;
            graph.Items.Add(1);
            graph.Items.Add(2);
            graph.Items.Add(3);
            graph.SelectedItem = 1;
            combo_port.SelectedIndex = 0;
            timer1.Start();
            dataGridView1.ColumnCount = 4;
            adminPanel.Visible = false;
            dataGridView1.Rows.Add("ID","Type", "DataConverti","AlarmeStatus");
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            MakeDataTables();
        }

        //Recuperation donnes port COM + remplissage listeSerial
        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            int offset = 0;
            int count = serialPort1.BytesToRead;
            byte[] tab = new byte[count];
            serialPort1.Read(tab, offset, count);

            for (int i = 0; i < tab.Length; i++)
            {
                listeSerial.Add(tab[i]);
            }

            
            }

        //Traitement listeSerial et suppresion des donnés traités
        private void traitement() {

            int nbrocte = 0;
            int debutTrame = 0;
            while (listeSerial.Count > 2)
            {

                if (listeSerial.Count > 4 && listeSerial[0] == 85 && listeSerial[1] == 170 && listeSerial[2] == 85 && listeSerial[3] != 170)
                {

                    debutTrame = 3;
                    nbrocte = listeSerial[4]; 
                    if (listeSerial.Count > (9 + nbrocte)  && listeSerial[(9 + nbrocte)] == 170)
                    {

                        int debutData = debutTrame + 2;

                        rassemblerData(debutData, nbrocte);
                        trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], rassemblerData(debutData, nbrocte), listeSerial[(debutTrame + 2) + (nbrocte + 1)]);
                        for (int i = 0; i < (10 + nbrocte); i++)
                        {
                            listeSerial.RemoveAt(0);
                        } 
                    }
                    else
                    {
                        listeSerial.RemoveAt(0);
                    }
                }
                else
                {
                    listeSerial.RemoveAt(0);
                }
            }
            
        }

        //regroupage des data en un seul chiffre pour la conversion
        private ulong rassemblerData(int debutData, int nbrocte)
        {

            ulong data1 = 0;

            if (nbrocte > 0)
            {
                debutData++;
                data1 = listeSerial[debutData];
            }
            if (nbrocte > 1)
            {
                debutData++;

                data1 = data1 << 8;
                data1 += listeSerial[debutData];
            }
            if (nbrocte > 2)
            {
                debutData++;
                ulong data2 = 0;
                data2 = listeSerial[debutData];
                data1 = data1 << 16;
                data1 += data2;
            }

            return data1;
        }


        //verification si trame deja existante + conversion de data 
        //si trame existe changement dans grid
        //sinon rajout dans listeTrier
        private void trameMesure(int id, int nbrData, int type, ulong data, int checksum)
        {

            Boolean idExistant = true;

            foreach (Base index in listeTrier)
            {
                if (index.id == id)
                {

                    idExistant = false;
                    index.id = id;
                    index.nbrData = nbrData;
                    index.type = type;
                    index.data = data;
                    if (index.id > 0 && index.id < 11)
                    {

                        double math = Math.Pow(2, nbrData * 8);
                        double buffer = (double)data / math;
                        double max = (double)((Mesure)index).max;
                        double min = (double)((Mesure)index).min;
                        ((Mesure)index).dataConverti = buffer * (max - min) + min;


                            if (((Mesure)index).valuesConverti.Count < 10)
                        {
                            ((Mesure)index).valuesConverti.Add(((Mesure)index).dataConverti);
                        }
                        else {
                            ((Mesure)index).valuesConverti.RemoveAt(0);
                            ((Mesure)index).valuesConverti.Add(((Mesure)index).dataConverti);
                        }
                            
                        
                        
                        PlacementGrid(((Mesure)index));
                    }
                   

                }
            }

            if (idExistant)
            {
                string typeStr = typeNom(type,id);

                if (id == 0)
                {

                    Base trame = new Base(id, nbrData, type, data, 0);
                    listeTrier.Add(trame);
                   

                }
                else if (id == 50)
                {

                    Alarme trame = new Alarme(0, 0, 0);
                    trame.id = id;
                    trame.nbrData = nbrData;
                    trame.type = type;
                    trame.data = data;
                    listeTrier.Add(trame);
                }
                else if (id > 0)
                {
                   
                    Mesure trame = new Mesure(0, 0, 0, 0, 0);
                    trame.id = id;
                    trame.nbrData = nbrData;
                    trame.type = type;
                    trame.data = data;

                    listeTrier.Add(trame);
                   
                }

                dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.Add(id, typeStr)));
                
            }

        }

        // implementation des noms pour les types;lors de l'affichage dans le grid
        private String typeNom(int type,int id) {
            string nomType = "";

            if (type == 1)
            {
                nomType = "Température";
            }
            else if (type == 2) 
            {
                nomType = "Humidité";
            }
            else if (type == 3)
            {
                nomType = "Pression atmosphérique";
            }
            else if (type == 4)
            {
                nomType = "Luminosité";
            }
            else if (id == 0)
            {
                nomType = "KeepAlive";
            }
            else if (id == 50)
            {
                nomType = "Alarme";
            }

            return nomType;
        }

        //placement dans le grid
        private void PlacementGrid(Mesure trame)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == trame.id.ToString())
                {
                                        
                    dataGridView1.Rows[i].Cells[2].Value = trame.dataConverti;

                    if (trame.dataConverti > trame.alarmeMax && trame.alarmeMax!=0)
                    {
                        /******CODE EXAMEN: DEBUT*********/
                        insertDbLog(DateTime.Now.ToString(), "Alarm", "Trop chaud"+trame.dataConverti);
                        /******CODE EXAMEN: FIN***********/
                        dataGridView1.Rows[i].Cells[3].Value = "Trop chaud";
                    }
                    else if (trame.dataConverti < trame.alarmeMin && trame.alarmeMin != 0)
                    {
                        /******CODE EXAMEN: DEBUT*********/
                        insertDbLog(DateTime.Now.ToString(), "Alarm", "Trop froid" + trame.dataConverti);
                        /******CODE EXAMEN: FIN***********/
                        dataGridView1.Rows[i].Cells[3].Value = "Trop Froid";
                    }
                    else {
                       dataGridView1.Rows[i].Cells[3].Value = "Ok";
                    }
                }

            }
        }


        //Timer
        //contient le traitement des trames
        //et le comportement du graphique
        private void timer1_Tick(object sender, EventArgs e)
        {
            traitement();
            Chart();
            
        }

       
    }
}
