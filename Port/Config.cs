using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Port
{
    public partial class Form1
    {
        public void LoadConfig(object sender, EventArgs e) {
            
            try
            {
                string[] lines = System.IO.File.ReadAllLines(NOMFICHIER);
                foreach (string index in lines)
                {
                    string[] splitString = index.Split(';');
                    foreach (Base indexTrame in listeTrier)
                    {
                        if (indexTrame.id == Int32.Parse(splitString[0]))
                        {
                            ((Mesure)indexTrame).min = Int32.Parse(splitString[1]);
                            ((Mesure)indexTrame).max = Int32.Parse(splitString[2]);
                        }

                    }
                }
            }

            catch (Exception ex) {
                MessageBox.Show("Fichier inexistant");   
            }

            
        }


        private void UpdateConfig(object sender, EventArgs e)
        {
            MessageBox.Show("Le fichier Config.txt a été créé,pour les prochains demarrage veuillez appuyez sur LOAD CONFIG");
            string test = "";

            foreach (Base index in listeTrier)
            {

                if (index.id > 0 && index.id < 11 && ((Mesure)index).min != 0)
                {

                    test += ((Mesure)index).id + ";" + ((Mesure)index).min + ";" + ((Mesure)index).max;
                    test += "\r\n";
                }

            }


            using (StreamWriter file = new StreamWriter(NOMFICHIER))
            {
                file.Write(test);
            }


        }

        private void ValidConfig(object sender, EventArgs e)
        {
            try
            {
                foreach (Base index in listeTrier)
                {

                    if (index.id == Int32.Parse(comboBox.Text))
                    {

                        ((Mesure)index).min = Int32.Parse(valMin.Text);
                        ((Mesure)index).max = Int32.Parse(valMax.Text);

                    }
                }

            }
            catch (Exception er) {
                MessageBox.Show("Veuillez rentrez le min et le max");
            }



        }
    }
}
