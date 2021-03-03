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

namespace Port
{
    public partial class Form1 : Form
    {
        static int MIN = -40;
        static int MAX = 80;
        static int ALARME_MIN = 10;
        static int ALARME_MAX = 25;
        List<Byte> listeSerial = new List<byte>();
        ArrayList listeTrier = new ArrayList();
        Dictionary<int,Tuple <int ,int >> configUser=new Dictionary<int,Tuple<int, int>>();
        Base keepAlive = new Base(0, 0, 0, 0, 0);
        Alarme alarme = new Alarme(0, 0, 0);

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
            //listeTrier.Add(keepAlive);
            //listeTrier.Add(alarme);
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

                

                        ulong data1 = 0;
                        
                        int debutData = debutTrame + 2;



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


                        
                        
                            
                            trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], data1, listeSerial[(debutTrame + 2) + (nbrocte + 1)]);

                            //trame.nbrData = listeSerial[debutTrame + 1];
                            //trame.type = listeSerial[debutTrame + 2];
                            //listeSerial[debutTrame] + "", listeSerial[debutTrame + 1] + "", listeSerial[debutTrame + 2] + "", data1, listeSerial[(debutTrame + 2) + (nbrocte + 1)] + ""))
                        
                        /*ulong data2 = 0;
                        data2 = listeSerial[debutData];
                        data1 =data1 << 8;
                        data1 += data2;*/

                        //MessageBox.Show(data1 + "");
                        //dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.Add(listeSerial[debutTrame] + "", listeSerial[debutTrame + 1] + "", listeSerial[debutTrame + 2] + "", data1, listeSerial[(debutTrame + 2) + (nbrocte + 1)] + "")));
                    }


                }


            }
            //serialPort1.Close();
        }


        private void trameMesure(int id, int nbrData, int type,ulong data,int checksum) {
            
            Boolean idExistant = true;
           
            foreach (Base index in listeTrier) {
                if (index.id == id) {
                    //MessageBox.Show("existant");
                    idExistant = false;
                    index.id = id;
                    index.nbrData = nbrData;
                    index.type = type;
                    index.data = data;
                    if (index.id > 0 && index.id < 11 && ((Mesure)index).min != 0)
                    {

                        ((Mesure)index).dataConverti = 45;

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
                    MessageBox.Show("INE");
                    Base trame = new Base(id,nbrData,type,data,0);
                    listeTrier.Add(trame);
                    
                }
                else if (id == 50)
                {
                    MessageBox.Show("INE");
                    Alarme trame = new Alarme(0,0,0);
                    trame.id = id;
                    trame.nbrData = nbrData;
                    trame.type = type;
                    trame.data = data;
                    listeTrier.Add(trame);
                }
                else if (id > 0)
                {
                    MessageBox.Show("INE");
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
                //configUser.Add(Int32.Parse(comboBox.Text), new Tuple<int, int>(Int32.Parse(valMin.Text), Int32.Parse(valMax.Text)));
            //MessageBox.Show(configUser[1].Item1+"");
        }
    }
}
