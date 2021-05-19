using System;
using System.IO;
using System.Windows.Forms;

namespace Port
{
    public partial class Form1
    {

        //Chargement fichier Config
        public void LoadConfig()
        {
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
                            ((Mesure)indexTrame).alarmeMin = Int32.Parse(splitString[3]);
                            ((Mesure)indexTrame).alarmeMax = Int32.Parse(splitString[4]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fichier inexistant");
            }
        }

        //Creation fichier Config
        private void UpdateConfig()
        {
            string test = "";

            foreach (Base index in listeTrier)
            {
                if (index.id > 0 && index.id < 11 && ((Mesure)index).min != 0)
                {
                    test += ((Mesure)index).id + ";" + ((Mesure)index).min + ";" + ((Mesure)index).max + ";" + ((Mesure)index).alarmeMin + ";" + ((Mesure)index).alarmeMax;
                    test += "\r\n";
                }
            }

            using (StreamWriter file = new StreamWriter(NOMFICHIER))
            {
                file.Write(test);
            }
        }

        //Button chargement fichier config
        private void load_fichier_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }

        //Test configuration id
        private void ValidConfig(object sender, EventArgs e)
        {
            Boolean ifConfig = false;
            try
            {
                foreach (Base index in listeTrier)
                {
                    if (index.id == Int32.Parse(comboBox.Text))
                    {
                        if (user.idAcces == 1 || user.idAcces == 2 || user.idAcces == 3)
                        {
                            ((Mesure)index).min = Int32.Parse(valMin.Text);
                            ((Mesure)index).max = Int32.Parse(valMax.Text);
                            ifConfig = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas les droit de configurer l'id ou vous devez vous connecter");
                        }

                        if (user.idAcces == 1 || user.idAcces == 2 || user.idAcces == 3 || user.idAcces == 4)
                        {
                            ((Mesure)index).alarmeMin = Int32.Parse(alarmeMin.Text);
                            ((Mesure)index).alarmeMax = Int32.Parse(alarmeMax.Text);
                            ifConfig = true;
                        }
                        else
                        {
                            MessageBox.Show("Vous n'avez pas les droit de configuerer l'alarme ou vous devez vous connecter");
                        }
                        if (ifConfig)
                        {
                            UpdateConfig();
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Veuillez rentrez min,max,alarmeMin et alarmeMax ; sinon les valeurs par defaut vont etre inserer");
            }
        }
    }
}