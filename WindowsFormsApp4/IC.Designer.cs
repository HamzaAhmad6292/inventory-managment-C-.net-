namespace WindowsFormsApp4
{
    partial class IC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.ComboBox();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProjectDataSet26 = new WindowsFormsApp4.ProjectDataSet26();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Item_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete_ = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Cat_Box = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProjectDataSet27 = new WindowsFormsApp4.ProjectDataSet27();
            this.label12 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.nameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sizesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.nameTableAdapter = new WindowsFormsApp4.ProjectDataSet26TableAdapters.NameTableAdapter();
            this.sysdiagramsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sizesTableAdapter = new WindowsFormsApp4.ProjectDataSet26TableAdapters.sizesTableAdapter();
            this.companyTableAdapter = new WindowsFormsApp4.ProjectDataSet26TableAdapters.companyTableAdapter();
            this.clientTableAdapter = new WindowsFormsApp4.ProjectDataSet26TableAdapters.ClientTableAdapter();
            this.categoriesTableAdapter = new WindowsFormsApp4.ProjectDataSet27TableAdapters.categoriesTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysdiagramsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1456, 202);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.WhatsApp_Image_2022_07_29_at_12_073;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(344, 200);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.DataSource = this.clientBindingSource;
            this.textBox2.DisplayMember = "Client";
            this.textBox2.FormattingEnabled = true;
            this.textBox2.Location = new System.Drawing.Point(466, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(445, 28);
            this.textBox2.TabIndex = 16;
            this.textBox2.ValueMember = "Client";
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.ProjectDataSet26;
            // 
            // ProjectDataSet26
            // 
            this.ProjectDataSet26.DataSetName = "ProjectDataSet26";
            this.ProjectDataSet26.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.icons8_print_32;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(627, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 40);
            this.button5.TabIndex = 12;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date";
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.Refresh_64px;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(567, -2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 38);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Image = global::WindowsFormsApp4.Properties.Resources.close_48px1;
            this.button3.Location = new System.Drawing.Point(1102, -1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 39);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add_Item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(466, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 26);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client_name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "IC_Number";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(750, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_No,
            this.c2,
            this.S,
            this.Column1,
            this.C,
            this.Q,
            this.Delete_});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1456, 538);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Item_No
            // 
            this.Item_No.HeaderText = "No";
            this.Item_No.MinimumWidth = 8;
            this.Item_No.Name = "Item_No";
            this.Item_No.Width = 30;
            // 
            // c2
            // 
            this.c2.HeaderText = "Name";
            this.c2.MinimumWidth = 8;
            this.c2.Name = "c2";
            this.c2.Width = 150;
            // 
            // S
            // 
            this.S.HeaderText = "Size";
            this.S.MinimumWidth = 8;
            this.S.Name = "S";
            this.S.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Material";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // C
            // 
            this.C.HeaderText = "Company";
            this.C.MinimumWidth = 8;
            this.C.Name = "C";
            this.C.Width = 150;
            // 
            // Q
            // 
            this.Q.HeaderText = "Quantity";
            this.Q.MinimumWidth = 8;
            this.Q.Name = "Q";
            this.Q.Width = 150;
            // 
            // Delete_
            // 
            this.Delete_.HeaderText = "Delete";
            this.Delete_.MinimumWidth = 8;
            this.Delete_.Name = "Delete_";
            this.Delete_.Width = 30;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 683);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1456, 57);
            this.panel2.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.WhatsApp_Image_2022_07_27_at_1_20_07_PM;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 202);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Cat_Box);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.comboBox3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1184, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 481);
            this.panel3.TabIndex = 18;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // Cat_Box
            // 
            this.Cat_Box.DataSource = this.categoriesBindingSource;
            this.Cat_Box.DisplayMember = "Category";
            this.Cat_Box.FormattingEnabled = true;
            this.Cat_Box.Location = new System.Drawing.Point(112, 183);
            this.Cat_Box.Name = "Cat_Box";
            this.Cat_Box.Size = new System.Drawing.Size(148, 28);
            this.Cat_Box.TabIndex = 44;
            this.Cat_Box.ValueMember = "Category";
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "categories";
            this.categoriesBindingSource.DataSource = this.ProjectDataSet27;
            // 
            // ProjectDataSet27
            // 
            this.ProjectDataSet27.DataSetName = "ProjectDataSet27";
            this.ProjectDataSet27.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "Category";
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::WindowsFormsApp4.Properties.Resources.icons8_forward_642;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(-1, -1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 37);
            this.button8.TabIndex = 19;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.nameBindingSource;
            this.comboBox3.DisplayMember = "Name";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(112, 68);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(148, 28);
            this.comboBox3.TabIndex = 21;
            this.comboBox3.ValueMember = "Name";
            // 
            // nameBindingSource
            // 
            this.nameBindingSource.DataMember = "Name";
            this.nameBindingSource.DataSource = this.ProjectDataSet26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Company";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.companyBindingSource;
            this.comboBox2.DisplayMember = "Company";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(112, 240);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(148, 28);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.ValueMember = "Company";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataMember = "company";
            this.companyBindingSource.DataSource = this.ProjectDataSet26;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.sizesBindingSource;
            this.comboBox1.DisplayMember = "Size";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(112, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 28);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.ValueMember = "Size";
            // 
            // sizesBindingSource
            // 
            this.sizesBindingSource.DataMember = "sizes";
            this.sizesBindingSource.DataSource = this.ProjectDataSet26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Size";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 311);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(148, 26);
            this.textBox3.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Quantity";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Item_name";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Red;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(116, 391);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 45);
            this.button7.TabIndex = 12;
            this.button7.Text = "Enter";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // nameTableAdapter
            // 
            this.nameTableAdapter.ClearBeforeFill = true;
            // 
            // sysdiagramsBindingSource
            // 
            this.sysdiagramsBindingSource.DataMember = "sysdiagrams";
            this.sysdiagramsBindingSource.DataSource = this.ProjectDataSet26;
            // 
            // sizesTableAdapter
            // 
            this.sizesTableAdapter.ClearBeforeFill = true;
            // 
            // companyTableAdapter
            // 
            this.companyTableAdapter.ClearBeforeFill = true;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // IC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 740);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IC";
            this.Text = "IC_Form";
            this.Load += new System.EventHandler(this.IC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysdiagramsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewButtonColumn Delete_;
        private System.Windows.Forms.ComboBox Cat_Box;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ProjectDataSet26 ProjectDataSet26;
        private System.Windows.Forms.BindingSource nameBindingSource;
        private ProjectDataSet26TableAdapters.NameTableAdapter nameTableAdapter;
        private System.Windows.Forms.BindingSource sysdiagramsBindingSource;
        private System.Windows.Forms.BindingSource sizesBindingSource;
        private ProjectDataSet26TableAdapters.sizesTableAdapter sizesTableAdapter;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private ProjectDataSet26TableAdapters.companyTableAdapter companyTableAdapter;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private ProjectDataSet26TableAdapters.ClientTableAdapter clientTableAdapter;
        private ProjectDataSet27 ProjectDataSet27;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private ProjectDataSet27TableAdapters.categoriesTableAdapter categoriesTableAdapter;
    }
}