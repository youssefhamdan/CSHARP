using System;
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

            for (int i = 0; i < listeSerial.Count; i++)
            {
                if (i + 4 < listeSerial.Count && listeSerial[i] == 85 && listeSerial[i + 1] == 170 && listeSerial[i + 2] == 85 && listeSerial[i + 3] != 170)
                {


                    debutTrame = i + 3;
                    nbrocte = listeSerial[i + 4];

                    if (i + (7 + nbrocte) < listeSerial.Count && listeSerial[i + (7 + nbrocte)] == 170)
                    {

                

                        //ulong data1 = 0;
                        
                        int debutData = debutTrame + 2;

                        rassemblerData(debutData, nbrocte);

                        trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], rassemblerData(debutData, nbrocte), listeSerial[(debutTrame + 2) + (nbrocte + 1)]);

                    }


                }


            }
            //serialPort1.Close();
        }


        private ulong rassemblerData(int debutData,int nbrocte) {

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

        private void trameMesure(int id, int nbrData, int type,ulong data,int checksum) {
            
            Boolean idExistant = true;
           
            foreach (Base index in listeTrier) {
                if (index.id == id) {
                    
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
                        ((Mesure)index).dataConverti = buffer*(max-min)+min;

                        PlacementGrid(((Mesure)index));
                    }
                    else
                    {
                        PlacementGrid(index);
                    }
                    
                }   
            }

            if (idExistant) {


                if (id == 0)
                {
                    
                    Base trame = new Base(id,nbrData,type,data,0);
                    listeTrier.Add(trame);
                    
                }
                else if (id == 50)
                {
                    
                    Alarme trame = new Alarme(0,0,0);
                    trame.id = id;
                    trame.nbrData = nbrData;
                    trame.type = type;
                    trame.data = data;
                    listeTrier.Add(trame);
                }
                else if (id > 0)
                {
                    
                    Mesure trame = new Mesure(0,0,0,0,0);
                    trame.id = id;
                    trame.nbrData = nbrData;
                    trame.type = type;
                    trame.data = data;
                    
                    listeTrier.Add(trame);
                }

                dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.Add(id, nbrData, type, data)));
            }
        
        }


        private void PlacementGrid(Base trame) {

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++) {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == trame.id.ToString()) {
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

        private void valid_Click(object sender, EventArgs e)
        {

            foreach (Base index in listeTrier)
            {

                if (index.id == Int32.Parse(comboBox.Text)) {

                    ((Mesure)index).min = Int32.Parse(valMin.Text);
                    ((Mesure)index).max = Int32.Parse(valMax.Text);

                }
            }


           
            
         
        }

        private void update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UPDATE CONFIG");
            string test = "";

            foreach (Base index in listeTrier)
            {

                if (index.id >0&&index.id<11&&((Mesure)index).min!=0)
                {

                    test += ((Mesure)index).id +";"+ ((Mesure)index).min +";"+ ((Mesure)index).max;
                    test += "\r\n";
                }
                
            }

            
            using (StreamWriter file = new StreamWriter(NOMFICHIER))
            {
                file.Write(test);
            }

           
        }

        private void loadConfig_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(NOMFICHIER);

            foreach (string index in lines) {
                string [] splitString = index.Split(';');
                foreach (Base indexTrame in listeTrier) {
                    if (indexTrame.id == Int32.Parse(splitString[0])) {
                        ((Mesure)indexTrame).min = Int32.Parse(splitString[1]);
                        ((Mesure)indexTrame).max = Int32.Parse(splitString[2]);
                    }
                    
                }
            }
        }
    }
}
