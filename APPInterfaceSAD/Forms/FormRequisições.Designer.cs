namespace APPInterfaceSAD.Forms
{
    partial class FormRequisições
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
            this.labelReq = new System.Windows.Forms.Label();
            this.labelReqVeiculo = new System.Windows.Forms.Label();
            this.labelReqCond = new System.Windows.Forms.Label();
            this.labelReqOficial = new System.Windows.Forms.Label();
            this.labelReqData = new System.Windows.Forms.Label();
            this.buttonReqInserir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReq
            // 
            this.labelReq.AutoSize = true;
            this.labelReq.Location = new System.Drawing.Point(259, 90);
            this.labelReq.Name = "labelReq";
            this.labelReq.Size = new System.Drawing.Size(83, 16);
            this.labelReq.TabIndex = 0;
            this.labelReq.Text = "Requisições";
            // 
            // labelReqVeiculo
            // 
            this.labelReqVeiculo.AutoSize = true;
            this.labelReqVeiculo.Location = new System.Drawing.Point(140, 168);
            this.labelReqVeiculo.Name = "labelReqVeiculo";
            this.labelReqVeiculo.Size = new System.Drawing.Size(52, 16);
            this.labelReqVeiculo.TabIndex = 1;
            this.labelReqVeiculo.Text = "Veiculo";
            // 
            // labelReqCond
            // 
            this.labelReqCond.AutoSize = true;
            this.labelReqCond.Location = new System.Drawing.Point(143, 220);
            this.labelReqCond.Name = "labelReqCond";
            this.labelReqCond.Size = new System.Drawing.Size(61, 16);
            this.labelReqCond.TabIndex = 2;
            this.labelReqCond.Text = "Condutor";
            // 
            // labelReqOficial
            // 
            this.labelReqOficial.AutoSize = true;
            this.labelReqOficial.Location = new System.Drawing.Point(143, 267);
            this.labelReqOficial.Name = "labelReqOficial";
            this.labelReqOficial.Size = new System.Drawing.Size(44, 16);
            this.labelReqOficial.TabIndex = 3;
            this.labelReqOficial.Text = "Oficial";
            // 
            // labelReqData
            // 
            this.labelReqData.AutoSize = true;
            this.labelReqData.Location = new System.Drawing.Point(146, 324);
            this.labelReqData.Name = "labelReqData";
            this.labelReqData.Size = new System.Drawing.Size(36, 16);
            this.labelReqData.TabIndex = 4;
            this.labelReqData.Text = "Data";
            // 
            // buttonReqInserir
            // 
            this.buttonReqInserir.Location = new System.Drawing.Point(212, 380);
            this.buttonReqInserir.Name = "buttonReqInserir";
            this.buttonReqInserir.Size = new System.Drawing.Size(153, 23);
            this.buttonReqInserir.TabIndex = 5;
            this.buttonReqInserir.Text = "Inserir Requisição";
            this.buttonReqInserir.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(116, 543);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(711, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(262, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(262, 220);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(262, 267);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(262, 324);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // FormRequisições
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 736);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonReqInserir);
            this.Controls.Add(this.labelReqData);
            this.Controls.Add(this.labelReqOficial);
            this.Controls.Add(this.labelReqCond);
            this.Controls.Add(this.labelReqVeiculo);
            this.Controls.Add(this.labelReq);
            this.Name = "FormRequisições";
            this.Text = "FormRequisições";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReq;
        private System.Windows.Forms.Label labelReqVeiculo;
        private System.Windows.Forms.Label labelReqCond;
        private System.Windows.Forms.Label labelReqOficial;
        private System.Windows.Forms.Label labelReqData;
        private System.Windows.Forms.Button buttonReqInserir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}