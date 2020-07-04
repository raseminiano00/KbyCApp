namespace Catering_Menu
{
    partial class frmCatering
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
            this.manageIngredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDishesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventReportyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPeriodToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseEventToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNotif = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Action = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seeEventsTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doneAllEventsOnGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wOBreakdownToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.Action.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageIngredientsToolStripMenuItem,
            this.manageDishesToolStripMenuItem,
            this.manageSuppliersToolStripMenuItem,
            this.asdToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.systemSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1025, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageIngredientsToolStripMenuItem
            // 
            this.manageIngredientsToolStripMenuItem.Name = "manageIngredientsToolStripMenuItem";
            this.manageIngredientsToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.manageIngredientsToolStripMenuItem.Text = "Manage ingredients";
            this.manageIngredientsToolStripMenuItem.Click += new System.EventHandler(this.manageIngredientsToolStripMenuItem_Click);
            // 
            // manageDishesToolStripMenuItem
            // 
            this.manageDishesToolStripMenuItem.Name = "manageDishesToolStripMenuItem";
            this.manageDishesToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.manageDishesToolStripMenuItem.Text = "Manage dishes";
            this.manageDishesToolStripMenuItem.Click += new System.EventHandler(this.manageDishesToolStripMenuItem_Click);
            // 
            // manageSuppliersToolStripMenuItem
            // 
            this.manageSuppliersToolStripMenuItem.Name = "manageSuppliersToolStripMenuItem";
            this.manageSuppliersToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.manageSuppliersToolStripMenuItem.Text = "Manage suppliers";
            this.manageSuppliersToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersToolStripMenuItem_Click);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.asdToolStripMenuItem.Text = "Dish Computation";
            this.asdToolStripMenuItem.Click += new System.EventHandler(this.asdToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventReportyToolStripMenuItem,
            this.purchaseOrderToolStripMenuItem1});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // eventReportyToolStripMenuItem
            // 
            this.eventReportyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byPeriodToolStripMenuItem1,
            this.chooseEventToolStripMenuItem1});
            this.eventReportyToolStripMenuItem.Name = "eventReportyToolStripMenuItem";
            this.eventReportyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.eventReportyToolStripMenuItem.Text = "Event Report";
            this.eventReportyToolStripMenuItem.Click += new System.EventHandler(this.eventReportyToolStripMenuItem_Click);
            // 
            // byPeriodToolStripMenuItem1
            // 
            this.byPeriodToolStripMenuItem1.Name = "byPeriodToolStripMenuItem1";
            this.byPeriodToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.byPeriodToolStripMenuItem1.Text = "By period";
            this.byPeriodToolStripMenuItem1.Click += new System.EventHandler(this.byPeriodToolStripMenuItem1_Click);
            // 
            // chooseEventToolStripMenuItem1
            // 
            this.chooseEventToolStripMenuItem1.Name = "chooseEventToolStripMenuItem1";
            this.chooseEventToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.chooseEventToolStripMenuItem1.Text = "Choose event";
            this.chooseEventToolStripMenuItem1.Click += new System.EventHandler(this.chooseEventToolStripMenuItem1_Click);
            // 
            // purchaseOrderToolStripMenuItem1
            // 
            this.purchaseOrderToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byPeriodToolStripMenuItem,
            this.chooseEventToolStripMenuItem});
            this.purchaseOrderToolStripMenuItem1.Name = "purchaseOrderToolStripMenuItem1";
            this.purchaseOrderToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.purchaseOrderToolStripMenuItem1.Text = "Purchase Order";
            this.purchaseOrderToolStripMenuItem1.Click += new System.EventHandler(this.purchaseOrderToolStripMenuItem1_Click);
            // 
            // byPeriodToolStripMenuItem
            // 
            this.byPeriodToolStripMenuItem.Name = "byPeriodToolStripMenuItem";
            this.byPeriodToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.byPeriodToolStripMenuItem.Text = "By period";
            this.byPeriodToolStripMenuItem.Click += new System.EventHandler(this.byPeriodToolStripMenuItem_Click);
            // 
            // chooseEventToolStripMenuItem
            // 
            this.chooseEventToolStripMenuItem.Name = "chooseEventToolStripMenuItem";
            this.chooseEventToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.chooseEventToolStripMenuItem.Text = "Choose event";
            this.chooseEventToolStripMenuItem.Click += new System.EventHandler(this.chooseEventToolStripMenuItem_Click);
            // 
            // systemSettingsToolStripMenuItem
            // 
            this.systemSettingsToolStripMenuItem.Name = "systemSettingsToolStripMenuItem";
            this.systemSettingsToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.systemSettingsToolStripMenuItem.Text = "System Settings";
            this.systemSettingsToolStripMenuItem.Click += new System.EventHandler(this.systemSettingsToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.lblNotif);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1025, 36);
            this.panel3.TabIndex = 15;
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1013, 297);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of schedule";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 272);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1007, 36);
            this.panel4.TabIndex = 39;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(311, 26);
            this.dateTimePicker1.TabIndex = 34;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Date of Event :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1007, 230);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 60);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 613);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1013, 275);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event details";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 250);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1001, 244);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 651);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1022, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Action
            // 
            this.Action.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seeEventsTodayToolStripMenuItem,
            this.addScheduleToolStripMenuItem,
            this.editScheduleToolStripMenuItem,
            this.changeStatusToolStripMenuItem,
            this.doneAllEventsOnGridToolStripMenuItem,
            this.generateReportsToolStripMenuItem});
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(196, 136);
            this.Action.Opening += new System.ComponentModel.CancelEventHandler(this.Action_Opening);
            // 
            // seeEventsTodayToolStripMenuItem
            // 
            this.seeEventsTodayToolStripMenuItem.Name = "seeEventsTodayToolStripMenuItem";
            this.seeEventsTodayToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.seeEventsTodayToolStripMenuItem.Text = "See events today";
            this.seeEventsTodayToolStripMenuItem.Click += new System.EventHandler(this.seeEventsTodayToolStripMenuItem_Click);
            // 
            // addScheduleToolStripMenuItem
            // 
            this.addScheduleToolStripMenuItem.Name = "addScheduleToolStripMenuItem";
            this.addScheduleToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addScheduleToolStripMenuItem.Text = "Add event";
            this.addScheduleToolStripMenuItem.Click += new System.EventHandler(this.addScheduleToolStripMenuItem_Click);
            // 
            // editScheduleToolStripMenuItem
            // 
            this.editScheduleToolStripMenuItem.Name = "editScheduleToolStripMenuItem";
            this.editScheduleToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.editScheduleToolStripMenuItem.Text = "Edit event";
            this.editScheduleToolStripMenuItem.Click += new System.EventHandler(this.editScheduleToolStripMenuItem_Click);
            // 
            // changeStatusToolStripMenuItem
            // 
            this.changeStatusToolStripMenuItem.Name = "changeStatusToolStripMenuItem";
            this.changeStatusToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.changeStatusToolStripMenuItem.Text = "ACTIVE/CANCEL event";
            this.changeStatusToolStripMenuItem.Click += new System.EventHandler(this.changeStatusToolStripMenuItem_Click);
            // 
            // doneAllEventsOnGridToolStripMenuItem
            // 
            this.doneAllEventsOnGridToolStripMenuItem.Name = "doneAllEventsOnGridToolStripMenuItem";
            this.doneAllEventsOnGridToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.doneAllEventsOnGridToolStripMenuItem.Text = "Done all events on grid";
            this.doneAllEventsOnGridToolStripMenuItem.Click += new System.EventHandler(this.doneAllEventsOnGridToolStripMenuItem_Click);
            // 
            // generateReportsToolStripMenuItem
            // 
            this.generateReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventSummaryToolStripMenuItem,
            this.purchaseOrderToolStripMenuItem});
            this.generateReportsToolStripMenuItem.Name = "generateReportsToolStripMenuItem";
            this.generateReportsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.generateReportsToolStripMenuItem.Text = "Generate Reports";
            this.generateReportsToolStripMenuItem.Click += new System.EventHandler(this.generateReportsToolStripMenuItem_Click);
            // 
            // eventSummaryToolStripMenuItem
            // 
            this.eventSummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wToolStripMenuItem,
            this.wOBreakdownToolStripMenuItem1});
            this.eventSummaryToolStripMenuItem.Name = "eventSummaryToolStripMenuItem";
            this.eventSummaryToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.eventSummaryToolStripMenuItem.Text = "Event summary";
            this.eventSummaryToolStripMenuItem.Click += new System.EventHandler(this.eventSummaryToolStripMenuItem_Click);
            // 
            // wToolStripMenuItem
            // 
            this.wToolStripMenuItem.Name = "wToolStripMenuItem";
            this.wToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.wToolStripMenuItem.Text = "W/ Breakdown";
            this.wToolStripMenuItem.Click += new System.EventHandler(this.wToolStripMenuItem_Click);
            // 
            // wOBreakdownToolStripMenuItem1
            // 
            this.wOBreakdownToolStripMenuItem1.Name = "wOBreakdownToolStripMenuItem1";
            this.wOBreakdownToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.wOBreakdownToolStripMenuItem1.Text = "W/O Breakdown";
            this.wOBreakdownToolStripMenuItem1.Click += new System.EventHandler(this.wOBreakdownToolStripMenuItem_Click);
            // 
            // purchaseOrderToolStripMenuItem
            // 
            this.purchaseOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedEventToolStripMenuItem});
            this.purchaseOrderToolStripMenuItem.Name = "purchaseOrderToolStripMenuItem";
            this.purchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.purchaseOrderToolStripMenuItem.Text = "Purchase Order";
            this.purchaseOrderToolStripMenuItem.Click += new System.EventHandler(this.purchaseOrderToolStripMenuItem_Click);
            // 
            // selectedEventToolStripMenuItem
            // 
            this.selectedEventToolStripMenuItem.Name = "selectedEventToolStripMenuItem";
            this.selectedEventToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectedEventToolStripMenuItem.Text = "Selected event";
            this.selectedEventToolStripMenuItem.Click += new System.EventHandler(this.selectedEventToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCatering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1025, 673);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCatering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K by Cunanan Events";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCatering_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.Action.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageIngredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDishesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNotif;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip Action;
        private System.Windows.Forms.ToolStripMenuItem addScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeStatusToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem seeEventsTodayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doneAllEventsOnGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wOBreakdownToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eventReportyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPeriodToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem systemSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPeriodToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chooseEventToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
    }
}