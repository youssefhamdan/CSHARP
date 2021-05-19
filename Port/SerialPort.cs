using System;
using System.Windows.Forms;

namespace Port
{
    public partial class Form1
    {
        //Selection port COM
        private void button_port_Click(object sender, EventArgs e)
        {
            try
            {
                LoadConfig();
                serialPort1.PortName = combo_port.Text;
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port deja configurer ou acces refusé");
            }
        }
    }
}