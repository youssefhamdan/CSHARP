using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Port
{
    public partial class Form1
    {
        private Model.User user = new Model.User();

        internal static DataSet Local_UserAccess = new DataSet();

        internal static DataTable Local_UserTable = new DataTable();

        internal static DataTable Local_AccessTable = new DataTable();

        internal static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;"
                                                                            +
                                                                        @"Data Source=..\..\..\DB_UserAccess.accdb;Cache Authentication=True";

        internal static OleDbConnection connexionDB = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;"
                                                                            +
                                                                        @"Data Source=..\..\..\DB_UserAccess.accdb;Cache Authentication=True");



        //Manuel Panel Admin
        private void information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Manuel panel admin\n\nPour l'insertion veuillez rentrer un username, un mot de passe et un id d'accès dans le champ ici à gauche.\n\n" +
                "Pour la suppression il suffit de rentrer l'username de l'utilisateur que vous souhaitez supprimer dans le champ \"Username \" ici à gauche.\n\n" +
                "Pour la modification rentrez l'username de l'utilisateur que vous souhaitez modifier dans le champ \"Username\", un mot de passe dans le champ \"Password\" et choisissez un id d'accès");
        }

        //Test Login
        private void submitLogin_Click(object sender, EventArgs e)
        {
            string CommandText = "SELECT * from UserTable WHERE UserName = '" + username.Text + "';";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand DBCommand = new OleDbCommand(CommandText, connection);

                try
                {
                    connection.Open();

                    OleDbDataReader DBReader = DBCommand.ExecuteReader();

                    if (DBReader.HasRows)
                    {
                        while (DBReader.Read())
                        {
                            if ((String)(DBReader[2]) == password.Text)
                            {
                                user.username = (String)DBReader[1];
                                user.idAcces = (int)DBReader[3];
                                if ((int)DBReader[3] == 1)
                                {
                                    adminPanel.Visible = true;
                                    group_connexion.Visible = false;
                                }
                                else
                                {
                                    text_connexion.Text += (String)DBReader[1];
                                    text_connexion.Visible = true;
                                    group_connexion.Visible = false;
                                }
                            }
                        }
                    }

                    DBReader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Init
        private void MakeDataTables()
        {
            ConfigDataset();
            BindToDataGrid();
        }
        //Creation table+relation
        private static void ConfigDataset()
        {
            DataColumn UserKey_ID = new DataColumn("A", System.Type.GetType("System.Int16"));
            DataColumn UserName = new DataColumn("B", System.Type.GetType("System.String"));
            DataColumn UserPassword = new DataColumn("C", System.Type.GetType("System.String"));
            DataColumn Access_Id = new DataColumn("D", System.Type.GetType("System.Int16"));

            DataColumn AccessKey_Id = new DataColumn("E", System.Type.GetType("System.Int16"));
            DataColumn AccessName = new DataColumn("F", System.Type.GetType("System.String"));
            DataColumn AllowCreateID = new DataColumn("G", System.Type.GetType("System.Boolean"));
            DataColumn AllowDestroyID = new DataColumn("H", System.Type.GetType("System.Boolean"));
            DataColumn AllowConfigAlarm = new DataColumn("I", System.Type.GetType("System.Boolean"));
            DataColumn UserCreation = new DataColumn("J", System.Type.GetType("System.Boolean"));

            Local_UserTable.TableName = "Local_UserTable";
            Local_AccessTable.TableName = "Local_AccessTable";

            Local_UserAccess.Tables.Add(Local_UserTable);
            Local_UserAccess.Tables.Add(Local_AccessTable);

            UserKey_ID.AutoIncrement = true;
            UserKey_ID.Unique = true;
            UserKey_ID.ColumnName = "UserKey_ID";
            UserKey_ID.DataType = System.Type.GetType("System.Int32");
            Local_UserTable.Columns.Add(UserKey_ID);

            UserName.AutoIncrement = false;
            UserName.Unique = false;
            UserName.ColumnName = "UserName";
            UserName.DataType = System.Type.GetType("System.String");
            Local_UserTable.Columns.Add(UserName);

            UserPassword.AutoIncrement = false;
            UserPassword.Unique = false;
            UserPassword.ColumnName = "UserPassword";
            UserPassword.DataType = System.Type.GetType("System.String");
            Local_UserTable.Columns.Add(UserPassword);

            Access_Id.AutoIncrement = false;
            Access_Id.Unique = false;
            Access_Id.ColumnName = "Access_Id";
            Access_Id.DataType = System.Type.GetType("System.Int32");
            Local_UserTable.Columns.Add(Access_Id);

            AccessKey_Id.AutoIncrement = true;
            AccessKey_Id.Unique = true;
            AccessKey_Id.ColumnName = "AccessKey_Id";
            AccessKey_Id.DataType = System.Type.GetType("System.Int32");
            Local_AccessTable.Columns.Add(AccessKey_Id);

            AccessName.AutoIncrement = false;
            AccessName.Unique = false;
            AccessName.ColumnName = "AccessName";
            AccessName.DataType = System.Type.GetType("System.String");
            Local_AccessTable.Columns.Add(AccessName);

            AllowCreateID.AutoIncrement = false;
            AllowCreateID.Unique = false;
            AllowCreateID.ColumnName = "AllowCreateID";
            AllowCreateID.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowCreateID);

            AllowDestroyID.AutoIncrement = false;
            AllowDestroyID.Unique = false;
            AllowDestroyID.ColumnName = "AllowDestroyID";
            AllowDestroyID.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowDestroyID);

            AllowConfigAlarm.AutoIncrement = false;
            AllowConfigAlarm.Unique = false;
            AllowConfigAlarm.ColumnName = "AllowConfigAlarm";
            AllowConfigAlarm.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(AllowConfigAlarm);

            UserCreation.AutoIncrement = false;
            UserCreation.Unique = false;
            UserCreation.ColumnName = "UserCreation";
            UserCreation.DataType = System.Type.GetType("System.Boolean");
            Local_AccessTable.Columns.Add(UserCreation);

            DataColumn parentColumn = Local_UserAccess.Tables["Local_AccessTable"].Columns["AccessKey_Id"];
            DataColumn childColumn = Local_UserAccess.Tables["Local_UserTable"].Columns["Access_Id"];

            DataRelation relation = new DataRelation("parent2Child", parentColumn, childColumn);

            Local_UserAccess.Tables["Local_UserTable"].ParentRelations.Add(relation);
        }
        //Affectation DataSource
        private void BindToDataGrid()
        {
            gridP.AutoGenerateColumns = true;
            gridP.DataSource = Local_UserAccess;
            gridP.DataMember = "Local_UserTable";
            Fill(Local_UserAccess, "Local_UserTable", "UserTable");
        }
        //Modification bdd button
        private void update_Clickl(object sender, EventArgs e)
        {
            updateDb(userUsername.Text, userPassword.Text, accessID.Text);
            Fill(Local_UserAccess, "Local_UserTable", "UserTable");
        }
        //Insertion bdd button
        private void insertion_Click(object sender, EventArgs e)
        {
            insertDb(userUsername.Text, userPassword.Text, accessID.Text);
            Fill(Local_UserAccess, "Local_UserTable", "UserTable");
        }
        //Suppresion bdd button
        private void suppresion_CLick(object sender, EventArgs e)
        {
            deleteDb(userUsername.Text);
            Fill(Local_UserAccess, "Local_UserTable", "UserTable");
        }
        //Recuperation de la bdd + affectation Dataset
        internal static void Fill(DataSet dataset, string TableName, string DB_Table)
        {
            dataset.Tables[TableName].Clear();

            OleDbDataAdapter Adapter = new OleDbDataAdapter();

            Adapter.SelectCommand = new OleDbCommand("SELECT * from " + DB_Table + ";", connexionDB);

            try
            {
                connexionDB.Open();

                Adapter.Fill(dataset.Tables[TableName]);
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

        
        //Insertion bdd
        private void insertDb(String user, String password, String acess)
        {
            string CommandText = "insert into UserTable(UserName,UserPassword,AccessKey_Id) values('" + user + "','" + password + "','" + acess + "');";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(CommandText, connection);

                OleDbDataAdapter Adapter = new OleDbDataAdapter();

                try
                {
                    Adapter.InsertCommand = command;

                    connection.Open();
                    int buffer = Adapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();

                    if (buffer != 0) MessageBox.Show("Utilisateur inséré avec succès");
                    else MessageBox.Show("Utilisateur non inséré");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Modification bdd
        private void updateDb(String user, String password, String acess)
        {
            string CommandText = "UPDATE UserTable SET UserPassword = '" + password + "', AccessKey_Id = '" + acess + "' WHERE UserName = '" + user + "';";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(CommandText, connection);

                OleDbDataAdapter Adapter = new OleDbDataAdapter();

                try
                {
                    Adapter.UpdateCommand = command;

                    connection.Open();
                    int buffer = Adapter.UpdateCommand.ExecuteNonQuery();
                    connection.Close();

                    if (buffer != 0) MessageBox.Show("L'utilisateur a été modifié avec succès");
                    else MessageBox.Show("Utilisateur non modifié");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Suppresion bdd
        private void deleteDb(String user)
        {
            string CommandText = "DELETE FROM UserTable WHERE UserName = '" + user + "';";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbCommand command = new OleDbCommand(CommandText, connection);
                OleDbDataAdapter Adapter = new OleDbDataAdapter();

                try
                {
                    Adapter.DeleteCommand = command;

                    connection.Open();
                    int buffer = Adapter.DeleteCommand.ExecuteNonQuery();
                    connection.Close();

                    if (buffer != 0) MessageBox.Show("Utilisateur supprimé avec succès");
                    else MessageBox.Show("Utilisateur non trouvé");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}