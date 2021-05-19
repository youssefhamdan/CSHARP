namespace Port
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.load_fichier = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.alarmeMax = new System.Windows.Forms.TextBox();
            this.alarmeMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.valid = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.valMax = new System.Windows.Forms.TextBox();
            this.valMin = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graph = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.text_connexion = new System.Windows.Forms.Label();
            this.adminPanel = new System.Windows.Forms.GroupBox();
            this.explication = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.accessID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.insertUtilisateur = new System.Windows.Forms.Button();
            this.addUser = new System.Windows.Forms.Button();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.gridP = new System.Windows.Forms.DataGridView();
            this.userUsername = new System.Windows.Forms.TextBox();
            this.group_connexion = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.submitLogin = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button_port = new System.Windows.Forms.Button();
            this.combo_port = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataSet1 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.adminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).BeginInit();
            this.group_connexion.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.Size = new System.Drawing.Size(520, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.load_fichier);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.alarmeMax);
            this.groupBox1.Controls.Add(this.alarmeMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.valid);
            this.groupBox1.Controls.Add(this.comboBox);
            this.groupBox1.Controls.Add(this.valMax);
            this.groupBox1.Controls.Add(this.valMin);
            this.groupBox1.Location = new System.Drawing.Point(566, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 267);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // load_fichier
            // 
            this.load_fichier.Location = new System.Drawing.Point(87, 160);
            this.load_fichier.Name = "load_fichier";
            this.load_fichier.Size = new System.Drawing.Size(85, 51);
            this.load_fichier.TabIndex = 15;
            this.load_fichier.Text = "Charger dernier configuration";
            this.load_fichier.UseVisualStyleBackColor = true;
            this.load_fichier.Click += new System.EventHandler(this.load_fichier_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Alarme Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Alarme Min";
            // 
            // alarmeMax
            // 
            this.alarmeMax.Location = new System.Drawing.Point(6, 124);
            this.alarmeMax.Name = "alarmeMax";
            this.alarmeMax.Size = new System.Drawing.Size(100, 20);
            this.alarmeMax.TabIndex = 12;
            // 
            // alarmeMin
            // 
            this.alarmeMin.Location = new System.Drawing.Point(6, 98);
            this.alarmeMin.Name = "alarmeMin";
            this.alarmeMin.Size = new System.Drawing.Size(100, 20);
            this.alarmeMin.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Min";
            // 
            // valid
            // 
            this.valid.Location = new System.Drawing.Point(6, 160);
            this.valid.Name = "valid";
            this.valid.Size = new System.Drawing.Size(75, 23);
            this.valid.TabIndex = 6;
            this.valid.Text = "Valider";
            this.valid.UseVisualStyleBackColor = true;
            this.valid.Click += new System.EventHandler(this.ValidConfig);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox.Location = new System.Drawing.Point(6, 19);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 3;
            // 
            // valMax
            // 
            this.valMax.Location = new System.Drawing.Point(6, 72);
            this.valMax.Name = "valMax";
            this.valMax.Size = new System.Drawing.Size(100, 20);
            this.valMax.TabIndex = 5;
            // 
            // valMin
            // 
            this.valMin.Location = new System.Drawing.Point(6, 46);
            this.valMin.Name = "valMin";
            this.valMin.Size = new System.Drawing.Size(100, 20);
            this.valMin.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(896, 504);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(888, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tableau";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.graph);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(888, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graphique";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(6, 15);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(739, 382);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // graph
            // 
            this.graph.FormattingEnabled = true;
            this.graph.Location = new System.Drawing.Point(47, 403);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(121, 21);
            this.graph.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.text_connexion);
            this.tabPage3.Controls.Add(this.adminPanel);
            this.tabPage3.Controls.Add(this.group_connexion);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(888, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Login";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // text_connexion
            // 
            this.text_connexion.AutoSize = true;
            this.text_connexion.Location = new System.Drawing.Point(38, 186);
            this.text_connexion.Name = "text_connexion";
            this.text_connexion.Size = new System.Drawing.Size(91, 13);
            this.text_connexion.TabIndex = 2;
            this.text_connexion.Text = "Tu est connecter ";
            this.text_connexion.Visible = false;
            // 
            // adminPanel
            // 
            this.adminPanel.Controls.Add(this.explication);
            this.adminPanel.Controls.Add(this.label11);
            this.adminPanel.Controls.Add(this.label10);
            this.adminPanel.Controls.Add(this.label9);
            this.adminPanel.Controls.Add(this.accessID);
            this.adminPanel.Controls.Add(this.button1);
            this.adminPanel.Controls.Add(this.insertUtilisateur);
            this.adminPanel.Controls.Add(this.addUser);
            this.adminPanel.Controls.Add(this.userPassword);
            this.adminPanel.Controls.Add(this.gridP);
            this.adminPanel.Controls.Add(this.userUsername);
            this.adminPanel.Location = new System.Drawing.Point(287, 26);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(582, 446);
            this.adminPanel.TabIndex = 1;
            this.adminPanel.TabStop = false;
            this.adminPanel.Text = "ADMIN PANEL";
            // 
            // explication
            // 
            this.explication.Location = new System.Drawing.Point(354, 285);
            this.explication.Name = "explication";
            this.explication.Size = new System.Drawing.Size(75, 23);
            this.explication.TabIndex = 14;
            this.explication.Text = "Explication";
            this.explication.UseVisualStyleBackColor = true;
            this.explication.Click += new System.EventHandler(this.information_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "idacces";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "username";
            // 
            // accessID
            // 
            this.accessID.FormattingEnabled = true;
            this.accessID.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.accessID.Location = new System.Drawing.Point(6, 330);
            this.accessID.Name = "accessID";
            this.accessID.Size = new System.Drawing.Size(121, 21);
            this.accessID.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.suppresion_CLick);
            // 
            // insertUtilisateur
            // 
            this.insertUtilisateur.Location = new System.Drawing.Point(100, 357);
            this.insertUtilisateur.Name = "insertUtilisateur";
            this.insertUtilisateur.Size = new System.Drawing.Size(75, 23);
            this.insertUtilisateur.TabIndex = 8;
            this.insertUtilisateur.Text = "Insert";
            this.insertUtilisateur.UseVisualStyleBackColor = true;
            this.insertUtilisateur.Click += new System.EventHandler(this.insertion_Click);
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(6, 357);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(75, 23);
            this.addUser.TabIndex = 7;
            this.addUser.Text = "Update";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.update_Clickl);
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(6, 305);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(100, 20);
            this.userPassword.TabIndex = 5;
            // 
            // gridP
            // 
            this.gridP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridP.Location = new System.Drawing.Point(6, 57);
            this.gridP.Name = "gridP";
            this.gridP.Size = new System.Drawing.Size(486, 200);
            this.gridP.TabIndex = 4;
            // 
            // userUsername
            // 
            this.userUsername.Location = new System.Drawing.Point(6, 279);
            this.userUsername.Name = "userUsername";
            this.userUsername.Size = new System.Drawing.Size(100, 20);
            this.userUsername.TabIndex = 2;
            // 
            // group_connexion
            // 
            this.group_connexion.Controls.Add(this.label8);
            this.group_connexion.Controls.Add(this.label7);
            this.group_connexion.Controls.Add(this.submitLogin);
            this.group_connexion.Controls.Add(this.password);
            this.group_connexion.Controls.Add(this.username);
            this.group_connexion.Location = new System.Drawing.Point(32, 26);
            this.group_connexion.Name = "group_connexion";
            this.group_connexion.Size = new System.Drawing.Size(200, 122);
            this.group_connexion.TabIndex = 0;
            this.group_connexion.TabStop = false;
            this.group_connexion.Text = "LOGIN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "username";
            // 
            // submitLogin
            // 
            this.submitLogin.Location = new System.Drawing.Point(116, 93);
            this.submitLogin.Name = "submitLogin";
            this.submitLogin.Size = new System.Drawing.Size(75, 23);
            this.submitLogin.TabIndex = 2;
            this.submitLogin.Text = "Valider";
            this.submitLogin.UseVisualStyleBackColor = true;
            this.submitLogin.Click += new System.EventHandler(this.submitLogin_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(6, 57);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 2;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(6, 31);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.button_port);
            this.tabPage4.Controls.Add(this.combo_port);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(888, 478);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Config Port";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Veuillez choisir un port COM";
            // 
            // button_port
            // 
            this.button_port.Location = new System.Drawing.Point(182, 41);
            this.button_port.Name = "button_port";
            this.button_port.Size = new System.Drawing.Size(75, 23);
            this.button_port.TabIndex = 1;
            this.button_port.Text = "VALIDER";
            this.button_port.UseVisualStyleBackColor = true;
            this.button_port.Click += new System.EventHandler(this.button_port_Click);
            // 
            // combo_port
            // 
            this.combo_port.FormattingEnabled = true;
            this.combo_port.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.combo_port.Location = new System.Drawing.Point(30, 41);
            this.combo_port.Name = "combo_port";
            this.combo_port.Size = new System.Drawing.Size(121, 21);
            this.combo_port.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.adminPanel.ResumeLayout(false);
            this.adminPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridP)).EndInit();
            this.group_connexion.ResumeLayout(false);
            this.group_connexion.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button valid;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox valMax;
        private System.Windows.Forms.TextBox valMin;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox graph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox adminPanel;
        private System.Windows.Forms.TextBox userUsername;
        private System.Windows.Forms.GroupBox group_connexion;
        private System.Windows.Forms.Button submitLogin;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.DataGridView gridP;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button insertUtilisateur;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox accessID;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button_port;
        private System.Windows.Forms.ComboBox combo_port;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox alarmeMax;
        private System.Windows.Forms.TextBox alarmeMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label text_connexion;
        private System.Windows.Forms.Button load_fichier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button explication;
    }
}

