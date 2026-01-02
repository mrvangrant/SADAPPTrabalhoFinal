namespace APPInterfaceSAD
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxNIF = new System.Windows.Forms.TextBox();
            this.cbTipoContacto = new System.Windows.Forms.ComboBox();
            this.textBoxContacto = new System.Windows.Forms.TextBox();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Nome do cliente";
            // 
            // textBoxNIF
            // 
            this.textBoxNIF.Location = new System.Drawing.Point(94, 79);
            this.textBoxNIF.Name = "textBoxNIF";
            this.textBoxNIF.Size = new System.Drawing.Size(210, 22);
            this.textBoxNIF.TabIndex = 1;
            this.textBoxNIF.Text = "NIF";
            // 
            // cbTipoContacto
            // 
            this.cbTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoContacto.FormattingEnabled = true;
            this.cbTipoContacto.Location = new System.Drawing.Point(94, 122);
            this.cbTipoContacto.Name = "cbTipoContacto";
            this.cbTipoContacto.Size = new System.Drawing.Size(210, 24);
            this.cbTipoContacto.TabIndex = 2;
            // 
            // textBoxContacto
            // 
            this.textBoxContacto.Location = new System.Drawing.Point(94, 170);
            this.textBoxContacto.Name = "textBoxContacto";
            this.textBoxContacto.Size = new System.Drawing.Size(210, 22);
            this.textBoxContacto.TabIndex = 3;
            this.textBoxContacto.Text = "Contacto";
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(94, 211);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(115, 23);
            this.buttonInserir.TabIndex = 4;
            this.buttonInserir.Text = "Inserir Cliente";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(94, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1207, 464);
            this.dataGridView1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 736);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.textBoxContacto);
            this.Controls.Add(this.cbTipoContacto);
            this.Controls.Add(this.textBoxNIF);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxNIF;
        private System.Windows.Forms.ComboBox cbTipoContacto;
        private System.Windows.Forms.TextBox textBoxContacto;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

