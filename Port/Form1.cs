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
            dataGridView1.Rows.Add("ID", "Data Nbr", "Type", "Data", "Checksum");
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



                        if (debutTrame == 15)
                        {
                            //listeTrier[0]
                        }
                        else if (debutTrame == 50)
                        {
                            //listeTrier[1]
                        }
                        else if (debutTrame > 0)
                        {
                            trameMesure(listeSerial[debutTrame], listeSerial[debutTrame + 1], listeSerial[debutTrame + 2], data1);

                            //trame.nbrData = listeSerial[debutTrame + 1];
                            //trame.type = listeSerial[debutTrame + 2];
                            //listeSerial[debutTrame] + "", listeSerial[debutTrame + 1] + "", listeSerial[debutTrame + 2] + "", data1, listeSerial[(debutTrame + 2) + (nbrocte + 1)] + ""))
                        }
                        /*ulong data2 = 0;
                        data2 = listeSerial[debutData];
                        data1 =data1 << 8;
                        data1 += data2;*/

                        //MessageBox.Show(data1 + "");
                        //dataGridView1.Invoke((MethodInvoker)(() => dataGridView1.Rows.Add(listeSerial[debutTrame] + "", listeSerial[debutTrame + 1] + "", listeSerial[debutTrame + 2] + "", data1, listeSerial[(debutTrame + 2) + (nbrocte + 1)] + "")));
                    }


                }


            }
            serialPort1.Close();
        }


        public void trameMesure(int id, int nbrData, int type,ulong data) {
            
            Boolean idExistant = true;
            
            foreach (Mesure index in listeTrier) {
                if (index.id == id) {
                    MessageBox.Show("existant");
                    idExistant = false;
                    index.id = id;
                    index.nbrData = nbrData;
                    index.type = type;
                    index.data = data;
                    index.min = MIN;
                    index.max = MAX;
                    index.dataConverti = 0;
                    index.alarmeMin = ALARME_MIN;
                    index.alarmeMax = ALARME_MAX;
                }   
            }

            if (idExistant) {
                MessageBox.Show("INE");
                Mesure trame = new Mesure(MIN,MAX,0,ALARME_MIN,ALARME_MAX);
                trame.id = id;
                trame.nbrData = nbrData;
                trame.type = type;
                trame.data = data;
                listeTrier.Add(trame);
            }
        
        }
    }
}
