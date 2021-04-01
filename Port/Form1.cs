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
        List<double> values = new List<double>();
        ArrayList listeTrier = new ArrayList();
        int cpt = 0;


        public Form1()
        {
            InitializeComponent();
        }

        AutoResetEvent waitHandle = new AutoResetEvent(false);
        private void Form1_Load(object sender, EventArgs e)
        {
            graph.Items.Add(1);
            graph.Items.Add(2);
            graph.SelectedItem = 1;
            timer1.Start();
            tabControl1.SelectedTab = tabPage1;
            dataGridView1.ColumnCount = 5;
            dataGridView2.ColumnCount = 1;
            dataGridView1.Rows.Add("ID", "Data Nbr", "Type", "Data", "DataConverti");
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
            serialPort1.Open();
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            int nbrocte = 0;
            int debutTrame = 0;
            int offset = 0;
            int count = serialPort1.BytesToRead;
            byte[] tab = new byte[count];
            serialPort1.Read(tab, offset, count);


            for (int i = 0; i < tab.Length; i++)
            {
                dataGridView2.Invoke((MethodInvoker)(() => dataGridView2.Rows.Add(tab[i].ToString())));
                listeSerial.Add(tab[i]);
            }


            /*for (int i = 0; i < listeSerial.Count; i++)
            {
                if (i + 4 < listeSerial.Count && listeSerial[i] == 85 && listeSerial[i + 1] == 170 && listeSerial[i + 2] == 85 && listeSerial[i + 3] != 170)
                {


                    debutTrame = i + 3;
                    nbrocte = listeSerial[i + 4];

                    if (i + (7 + nbrocte) < listeSerial.Count && listeSerial[i + (7 + nbrocte)] == 170)
                    {

                        int debutData = debutTrame + 2;

                        rassemblerData(debutData, nbrocte);

                        trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], rassemblerData(debutData, nbrocte), listeSerial[(debutTrame + 2) + (nbrocte + 1)]);

                    }


                }


            }*/
            
                

                //serialPort1.Close();
            }


        private void traitement() {

            int nbrocte = 0;
            int debutTrame = 0;

            if (listeSerial.Count > 4 && listeSerial[0] == 85 && listeSerial[1] == 170 && listeSerial[2] == 85 && listeSerial[3] != 170)
            {

                debutTrame = 3;
                nbrocte = listeSerial[4];
                // MessageBox.Show(listeSerial[4] + "test" + listeSerial.Count + "condifiton" + listeSerial[7 + nbrocte]);
                if ((7 + nbrocte) < listeSerial.Count && listeSerial[(7 + nbrocte)] == 170)
                {

                    int debutData = debutTrame + 2;

                    rassemblerData(debutData, nbrocte);

                    trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], rassemblerData(debutData, nbrocte), listeSerial[(debutTrame + 2) + (nbrocte + 1)]);
                    for (int i = 0; i < (10 + nbrocte); i++)
                    {
                        listeSerial.RemoveAt(0);
                    }
                    //MessageBox.Show(listeSerial.Count + "");
                }

            }
        }


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
                    if (index.id > 0 && index.id < 11 && ((Mesure)index).min != 0)
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
                    else
                    {
                        PlacementGrid(index);
                    }

                }
            }

            if (idExistant)
            {


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

                dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.Add(id, nbrData, type, data)));
                
            }

        }


        private void PlacementGrid(Base trame)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == trame.id.ToString())
                {
                    dataGridView1.Rows[i].Cells[1].Value = trame.nbrData;
                    dataGridView1.Rows[i].Cells[2].Value = trame.type;
                    dataGridView1.Rows[i].Cells[3].Value = trame.data;
                }

            }
        }

        private void PlacementGrid(Mesure trame)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == trame.id.ToString())
                {
                    dataGridView1.Rows[i].Cells[1].Value = trame.nbrData;
                    dataGridView1.Rows[i].Cells[2].Value = trame.type;
                    dataGridView1.Rows[i].Cells[3].Value = trame.data;
                    dataGridView1.Rows[i].Cells[4].Value = trame.dataConverti;
                }

            }
        }
        
        private void Chart()
        {
            chart1.Series.Clear();
            Series series = chart1.Series.Add("Series2");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            foreach (Base index in listeTrier)
                {

                    if (index.id == int.Parse(graph.Text)&& ((Mesure)index).valuesConverti.Count!=0)
                    {

                    //chart1.Series["Series2"].Points.AddXY(cpt, ((Mesure)index).dataConverti);
                        for (int i = 0; i < ((Mesure)index).valuesConverti.Count; i++) {
                            series.Points.AddXY(i+1, ((Mesure)index).valuesConverti[i]);
                        }

                    }


                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            traitement();
            Chart();
            
        }

       
    }
}
