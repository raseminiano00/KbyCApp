namespace Catering_Menu
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNotif = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOthers = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKids = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGuest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtVip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.clmnGuest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Action = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeDishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDishToGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addDishToKidsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDishToCrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDishToOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.Action.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1436, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.lblNotif);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1436, 36);
            this.panel3.TabIndex = 14;
            this.panel3.Visible = false;
            // 
            // lblNotif
            // 
            this.lblNotif.AutoSize = true;
            this.lblNotif.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.lblNotif.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNotif.Location = new System.Drawing.Point(509, 9);
            this.lblNotif.Name = "lblNotif";
            this.lblNotif.Size = new System.Drawing.Size(0, 18);
            this.lblNotif.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(906, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 782);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 757);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 32);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(512, 725);
            this.panel6.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(512, 725);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox5);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(512, 32);
            this.panel5.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox5.Location = new System.Drawing.Point(209, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(235, 24);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "Search box";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.LocationChanged += new System.EventHandler(this.textBox5_LocationChanged);
            this.textBox5.TabStopChanged += new System.EventHandler(this.textBox5_TabStopChanged);
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.Enter += new System.EventHandler(this.textBox5_Enter);
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Appetizer",
            "Bread Service",
            "Soup",
            "Salad",
            "Pasta",
            "Main dish",
            "Kiddie Meal",
            "Rice",
            "Dessert",
            "Cake",
            "Drinks",
            "Crew meal",
            "OTHERS"});
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 26);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.Location = new System.Drawing.Point(444, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 32);
            this.button4.TabIndex = 13;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(903, 378);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Catering description";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtOthers);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtCrew);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtKids);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtGuest);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.txtVip);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 353);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Buffet",
            "Russian",
            "Plated",
            "Cocktail",
            "Lauriat"});
            this.comboBox3.Location = new System.Drawing.Point(465, 265);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(395, 26);
            this.comboBox3.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(462, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Type of Service";
            // 
            // txtOthers
            // 
            this.txtOthers.Location = new System.Drawing.Point(716, 124);
            this.txtOthers.Name = "txtOthers";
            this.txtOthers.Size = new System.Drawing.Size(144, 24);
            this.txtOthers.TabIndex = 5;
            this.txtOthers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(713, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "Others";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Weddings",
            "Birthday",
            "Debut",
            "Anniversary",
            "Corporate",
            "Others"});
            this.comboBox2.Location = new System.Drawing.Point(42, 265);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(395, 26);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 44;
            this.label5.Text = "Type of Event";
            // 
            // txtCrew
            // 
            this.txtCrew.Location = new System.Drawing.Point(541, 124);
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.Size = new System.Drawing.Size(144, 24);
            this.txtCrew.TabIndex = 4;
            this.txtCrew.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.txtCrew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(538, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "No. of Crew meal";
            // 
            // txtKids
            // 
            this.txtKids.Location = new System.Drawing.Point(370, 124);
            this.txtKids.Name = "txtKids";
            this.txtKids.Size = new System.Drawing.Size(144, 24);
            this.txtKids.TabIndex = 3;
            this.txtKids.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(367, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "No. of Kids";
            // 
            // txtGuest
            // 
            this.txtGuest.Location = new System.Drawing.Point(42, 124);
            this.txtGuest.Name = "txtGuest";
            this.txtGuest.Size = new System.Drawing.Size(144, 24);
            this.txtGuest.TabIndex = 1;
            this.txtGuest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "No. of VIP";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(648, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 44);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.CausesValidationChanged += new System.EventHandler(this.button3_CausesValidationChanged);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(42, 217);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(818, 24);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Date of event";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(377, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 44);
            this.button2.TabIndex = 10;
            this.button2.Text = "Clear dishes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 44);
            this.button1.TabIndex = 9;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(42, 170);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(818, 24);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 16);
            this.label11.TabIndex = 31;
            this.label11.Text = "Place of event";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(36, 35);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(824, 67);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtVip
            // 
            this.txtVip.Location = new System.Drawing.Point(206, 124);
            this.txtVip.Name = "txtVip";
            this.txtVip.Size = new System.Drawing.Size(144, 24);
            this.txtVip.TabIndex = 2;
            this.txtVip.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtVip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "No. of Guest";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(33, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "Name of Client";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 450);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(900, 398);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List of dish selected";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(894, 373);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnGuest,
            this.clmnDish,
            this.clmnPax,
            this.clmnPrice,
            this.clmnCategory});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(894, 373);
            this.dataGridView2.TabIndex = 16;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseDown);
            // 
            // clmnGuest
            // 
            this.clmnGuest.HeaderText = "Guest";
            this.clmnGuest.MaxInputLength = 500;
            this.clmnGuest.Name = "clmnGuest";
            this.clmnGuest.ReadOnly = true;
            this.clmnGuest.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmnDish
            // 
            this.clmnDish.HeaderText = "Dish Description";
            this.clmnDish.Name = "clmnDish";
            this.clmnDish.ReadOnly = true;
            this.clmnDish.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnDish.Width = 350;
            // 
            // clmnPax
            // 
            this.clmnPax.HeaderText = "Pax";
            this.clmnPax.Name = "clmnPax";
            this.clmnPax.ReadOnly = true;
            this.clmnPax.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clmnPrice
            // 
            this.clmnPrice.HeaderText = "Price";
            this.clmnPrice.Name = "clmnPrice";
            this.clmnPrice.ReadOnly = true;
            this.clmnPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnPrice.Width = 170;
            // 
            // clmnCategory
            // 
            this.clmnCategory.HeaderText = "Category";
            this.clmnCategory.Name = "clmnCategory";
            this.clmnCategory.ReadOnly = true;
            this.clmnCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmnCategory.Width = 130;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Action
            // 
            this.Action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeDishToolStripMenuItem});
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(144, 26);
            this.Action.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // removeDishToolStripMenuItem
            // 
            this.removeDishToolStripMenuItem.Name = "removeDishToolStripMenuItem";
            this.removeDishToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeDishToolStripMenuItem.Text = "Remove Dish";
            this.removeDishToolStripMenuItem.Click += new System.EventHandler(this.removeDishToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDishToGuestsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addDishToKidsToolStripMenuItem,
            this.addDishToCrewToolStripMenuItem,
            this.addDishToOthersToolStripMenuItem});
            this.contextMenuStrip1.Name = "Action";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // addDishToGuestsToolStripMenuItem
            // 
            this.addDishToGuestsToolStripMenuItem.Name = "addDishToGuestsToolStripMenuItem";
            this.addDishToGuestsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addDishToGuestsToolStripMenuItem.Text = "Add dish to Guests";
            this.addDishToGuestsToolStripMenuItem.Click += new System.EventHandler(this.addDishToGuestsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem1.Text = "Add dish to VIP";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // addDishToKidsToolStripMenuItem
            // 
            this.addDishToKidsToolStripMenuItem.Name = "addDishToKidsToolStripMenuItem";
            this.addDishToKidsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addDishToKidsToolStripMenuItem.Text = "Add dish to Kids";
            this.addDishToKidsToolStripMenuItem.Click += new System.EventHandler(this.addDishToKidsToolStripMenuItem_Click);
            // 
            // addDishToCrewToolStripMenuItem
            // 
            this.addDishToCrewToolStripMenuItem.Name = "addDishToCrewToolStripMenuItem";
            this.addDishToCrewToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addDishToCrewToolStripMenuItem.Text = "Add dish to Crew";
            this.addDishToCrewToolStripMenuItem.Click += new System.EventHandler(this.addDishToCrewToolStripMenuItem_Click);
            // 
            // addDishToOthersToolStripMenuItem
            // 
            this.addDishToOthersToolStripMenuItem.Name = "addDishToOthersToolStripMenuItem";
            this.addDishToOthersToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addDishToOthersToolStripMenuItem.Text = "Add dish to Others";
            this.addDishToOthersToolStripMenuItem.Click += new System.EventHandler(this.addDishToOthersToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1436, 860);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Event";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ImeModeChanged += new System.EventHandler(this.frmMenu_ImeModeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.Action.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNotif;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip Action;
        private System.Windows.Forms.ToolStripMenuItem removeDishToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.TextBox txtKids;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGuest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addDishToGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDishToKidsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCrew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem addDishToCrewToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOthers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem addDishToOthersToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGuest;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPax;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCategory;
    }
}