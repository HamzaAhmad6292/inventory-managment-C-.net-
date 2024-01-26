namespace WindowsFormsApp4
{
    partial class Quotation
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.ComboBox();
            this.ProjectDataSet26 = new WindowsFormsApp4.ProjectDataSet26();
            this.ProjectDataSet26BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientTableAdapter = new WindowsFormsApp4.ProjectDataSet26TableAdapters.ClientTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantity";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client";
            // 
            // textBox2
            // 
            this.textBox2.DataSource = this.clientBindingSource;
            this.textBox2.DisplayMember = "Client";
            this.textBox2.FormattingEnabled = true;
            this.textBox2.Location = new System.Drawing.Point(130, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 28);
            this.textBox2.TabIndex = 5;
            this.textBox2.ValueMember = "Client";
            // 
            // ProjectDataSet26
            // 
            this.ProjectDataSet26.DataSetName = "ProjectDataSet26";
            this.ProjectDataSet26.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProjectDataSet26BindingSource
            // 
            this.ProjectDataSet26BindingSource.DataSource = this.ProjectDataSet26;
            this.ProjectDataSet26BindingSource.Position = 0;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "Client";
            this.clientBindingSource.DataSource = this.ProjectDataSet26BindingSource;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // Quotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 165);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Quotation";
            this.Text = "Quote";
            this.Load += new System.EventHandler(this.Quotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectDataSet26BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox textBox2;
        private System.Windows.Forms.BindingSource ProjectDataSet26BindingSource;
        private ProjectDataSet26 ProjectDataSet26;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private ProjectDataSet26TableAdapters.ClientTableAdapter clientTableAdapter;
    }
}