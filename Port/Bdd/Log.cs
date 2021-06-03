using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Port
{
    public partial class Form1 
    {
        /******CODE EXAMEN: DEBUT*********/
        internal static string connectionLogString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                                                                            +
                                                                        @"Data Source=..\..\..\DB_Log.accdb;Cache Authentication=True";
        internal static DataTable Local_LogTable = new DataTable();

        private static void ConfigDataTable() {
            DataColumn Ref = new DataColumn("A", System.Type.GetType("System.Int16"));
            DataColumn Date = new DataColumn("B", System.Type.GetType("System.String"));
            DataColumn Type = new DataColumn("C", System.Type.GetType("System.String"));
            DataColumn Description = new DataColumn("D", System.Type.GetType("System.String"));

            Ref.AutoIncrement = true;
            Ref.Unique = true;
            Ref.ColumnName = "Ref";
            Ref.DataType = System.Type.GetType("System.Int32");
            Local_LogTable.Columns.Add(Ref);

            Date.AutoIncrement = false;
            Date.Unique = false;
            Date.ColumnName = "Date_Com";
            Date.DataType = System.Type.GetType("System.String");
            Local_LogTable.Columns.Add(Date);

            Type.AutoIncrement = false;
            Type.Unique = false;
            Type.ColumnName = "Type";
            Type.DataType = System.Type.GetType("System.String");
            Local_LogTable.Columns.Add(Type);

            Description.AutoIncrement = false;
            Description.Unique = false;
            Description.ColumnName = "Description";
            Description.DataType = System.Type.GetType("System.String");
            Local_LogTable.Columns.Add(Description);
            
        }

        private void BindDataGridLog() {
            grid_log.DataSource = Local_LogTable;
            Fill(Local_LogTable);
        }

        private void insertDbLog(String date, String type, String description)
        {
            Local_LogTable.Rows.Add(new object[] { null,date,type,description });
        }


      

       

        private void updateLogDb()
        {

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand("SELECT * FROM LogTable", connection);
                OleDbDataAdapter Adapter = new OleDbDataAdapter(command);

                try
                {

                    connection.Open();
                    OleDbCommandBuilder cbClientOrder = new OleDbCommandBuilder(Adapter);
                    Adapter.Update(Local_LogTable);

                    connection.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    connection.Close();
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            updateLogDb();
        }
        internal static void Fill(DataTable TableName)
        {
            TableName.Clear();

            OleDbDataAdapter Adapter = new OleDbDataAdapter();

            Adapter.SelectCommand = new OleDbCommand("SELECT * from " + "LogTable" + ";", connexionDB);

            try
            {
                connexionDB.Open();

                Adapter.Fill(TableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connexionDB.Close();
            }
        }

    }
    /******CODE EXAMEN: FIN***********/
}
