using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Port
{
    public partial class Form1
    {
        String adminUsername = "youssefh";
        DataTable userTable = new DataTable("UserTable");
        String adminPassword = "1234";

        private void submitLogin_Click(object sender, EventArgs e)
        {
            if (username.Text == adminUsername && password.Text == adminPassword)
            {
                adminPanel.Visible = true;
            }
        }

        private void MakeDataTables()
        {
            // Run all of the functions.
            MakeParentTable();
            MakeChildTable();
            MakeDataRelation();
            BindToDataGrid();
        }

        private void MakeParentTable()
        {
            // Create a new DataTable.
            System.Data.DataTable table = new DataTable("AccessTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType,
            // ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Name";
            column.AutoIncrement = false;
            column.Caption = "Name";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "AllowCreateID";
            column.AutoIncrement = false;
            column.Caption = "AllowCreateID";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create fourth column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "AllowDestroyID";
            column.AutoIncrement = false;
            column.Caption = "AllowDestroyID";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create fifth column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "AllowConfigAlarm";
            column.AutoIncrement = false;
            column.Caption = "AllowConfigAlarm";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Create sixth column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "UserCreation";
            column.AutoIncrement = false;
            column.Caption = "UserCreation";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);



            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            // Instantiate the DataSet variable.
            dataSet1 = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet1.Tables.Add(table);

            // Create three new DataRow objects and add
            // them to the DataTable
           
            row = table.NewRow();
            row["id"] = 0;
            row["Name"] = "AdminRights";
            row["AllowCreateID"] = true;
            row["AllowDestroyID"] = true;
            row["AllowConfigAlarm"] = true;
            row["UserCreation"] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = 1;
            row["Name"] = "MasterRights";
            row["AllowCreateID"] = true;
            row["AllowDestroyID"] = true;
            row["AllowConfigAlarm"] = true;
            row["UserCreation"] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = 2;
            row["Name"] = "MiddleRights";
            row["AllowCreateID"] = true;
            row["AllowDestroyID"] = false;
            row["AllowConfigAlarm"] = true;
            row["UserCreation"] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = 3;
            row["Name"] = "BasicRights";
            row["AllowCreateID"] = false;
            row["AllowDestroyID"] = false;
            row["AllowConfigAlarm"] = true;
            row["UserCreation"] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row["id"] = 4;
            row["Name"] = "NoRights";
            row["AllowCreateID"] = false;
            row["AllowDestroyID"] = false;
            row["AllowConfigAlarm"] = false;
            row["UserCreation"] = false;
            table.Rows.Add(row);

        }

        private void MakeChildTable()
        {
            // Create a new DataTable.
            
            DataColumn column;
            //DataRow row;

            // Create first column and add to the DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.AutoIncrement = true;
            column.Caption = "id";
            column.ReadOnly = true;
            column.Unique = true;

            // Add the column to the DataColumnCollection.
            userTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "UserName";
            column.AutoIncrement = false;
            column.Caption = "UserName";
            column.ReadOnly = false;
            column.Unique = true;
            userTable.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "UserPassword";
            column.AutoIncrement = false;
            column.Caption = "UserPassword";
            column.ReadOnly = false;
            column.Unique = false;
            userTable.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Access_ID";
            column.AutoIncrement = false;
            column.Caption = "Access_ID";
            column.ReadOnly = false;
            column.Unique = false;
            userTable.Columns.Add(column);

            dataSet1.Tables.Add(userTable);

            // Create three sets of DataRow objects,
            // five rows each, and add to DataTable.
            /*for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                row["UserName"] = "User " + i;
                row["UserPassword"] = "123"+i;
                row["Access_ID"] = i;
                table.Rows.Add(row);
            }*/
            
        }

        private void MakeDataRelation()
        {
            // DataRelation requires two DataColumn
            // (parent and child) and a name.
            DataColumn parentColumn =
                dataSet1.Tables["AccessTable"].Columns["id"];
            DataColumn childColumn =
                dataSet1.Tables["UserTable"].Columns["id"];
            DataRelation relation = new
                DataRelation("parent2Child", parentColumn, childColumn);
            dataSet1.Tables["UserTable"].ParentRelations.Add(relation);
        }

        private void BindToDataGrid()
        {
            // Instruct the DataGrid to bind to the DataSet, with the
            // ParentTable as the topmost DataTable.

            gridP.AutoGenerateColumns = true;
            gridP.DataSource = dataSet1;
            gridP.DataMember = "UserTable";
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = userTable.NewRow();
            row["UserName"] = userUsername.Text;
            row["UserPassword"] = userPassword.Text;
            row["Access_ID"] = accessID.Text;
            userTable.Rows.Add(row);
        }
    }
}
