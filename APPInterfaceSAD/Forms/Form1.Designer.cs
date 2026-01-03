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
            this.dataGridViewVeiculos = new System.Windows.Forms.DataGridView();
            this.textBoxNomeVeiculo = new System.Windows.Forms.TextBox();
            this.textBoxLotação = new System.Windows.Forms.TextBox();
            this.textBoxTara = new System.Windows.Forms.TextBox();
            this.textBoxRua = new System.Windows.Forms.TextBox();
            this.cbClasse = new System.Windows.Forms.ComboBox();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxCP = new System.Windows.Forms.TextBox();
            this.labelNomeVeiculo = new System.Windows.Forms.Label();
            this.labelLot = new System.Windows.Forms.Label();
            this.labelTar = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelClasse = new System.Windows.Forms.Label();
            this.labelRua = new System.Windows.Forms.Label();
            this.labelCP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVeiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVeiculos
            // 
            this.dataGridViewVeiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVeiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVeiculos.Location = new System.Drawing.Point(26, 493);
            this.dataGridViewVeiculos.Name = "dataGridViewVeiculos";
            this.dataGridViewVeiculos.ReadOnly = true;
            this.dataGridViewVeiculos.RowHeadersWidth = 51;
            this.dataGridViewVeiculos.RowTemplate.Height = 24;
            this.dataGridViewVeiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVeiculos.Size = new System.Drawing.Size(1708, 231);
            this.dataGridViewVeiculos.TabIndex = 5;
            // 
            // textBoxNomeVeiculo
            // 
            this.textBoxNomeVeiculo.Location = new System.Drawing.Point(160, 31);
            this.textBoxNomeVeiculo.Name = "textBoxNomeVeiculo";
            this.textBoxNomeVeiculo.Size = new System.Drawing.Size(193, 22);
            this.textBoxNomeVeiculo.TabIndex = 6;
            this.textBoxNomeVeiculo.Text = "Nome do Veiculo";
            // 
            // textBoxLotação
            // 
            this.textBoxLotação.Location = new System.Drawing.Point(160, 81);
            this.textBoxLotação.Name = "textBoxLotação";
            this.textBoxLotação.Size = new System.Drawing.Size(193, 22);
            this.textBoxLotação.TabIndex = 7;
            this.textBoxLotação.Text = "Lotação";
            // 
            // textBoxTara
            // 
            this.textBoxTara.Location = new System.Drawing.Point(160, 129);
            this.textBoxTara.Name = "textBoxTara";
            this.textBoxTara.Size = new System.Drawing.Size(193, 22);
            this.textBoxTara.TabIndex = 8;
            this.textBoxTara.Text = "Tara";
            // 
            // textBoxRua
            // 
            this.textBoxRua.Location = new System.Drawing.Point(160, 338);
            this.textBoxRua.Name = "textBoxRua";
            this.textBoxRua.Size = new System.Drawing.Size(193, 22);
            this.textBoxRua.TabIndex = 10;
            this.textBoxRua.Text = "Rua";
            // 
            // cbClasse
            // 
            this.cbClasse.FormattingEnabled = true;
            this.cbClasse.Location = new System.Drawing.Point(160, 295);
            this.cbClasse.Name = "cbClasse";
            this.cbClasse.Size = new System.Drawing.Size(193, 24);
            this.cbClasse.TabIndex = 11;
            this.cbClasse.Text = "Classe";
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(160, 433);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(75, 23);
            this.buttonInserir.TabIndex = 15;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // btAtualizar
            // 
            this.btAtualizar.Location = new System.Drawing.Point(264, 433);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btAtualizar.TabIndex = 16;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.UseVisualStyleBackColor = true;
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Location = new System.Drawing.Point(160, 254);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(193, 24);
            this.cbEstado.TabIndex = 17;
            this.cbEstado.Text = "Estado";
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(160, 172);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(193, 22);
            this.textBoxModelo.TabIndex = 18;
            this.textBoxModelo.Text = "Modelo";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(160, 214);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(193, 22);
            this.textBoxMarca.TabIndex = 19;
            this.textBoxMarca.Text = "Marca";
            // 
            // textBoxCP
            // 
            this.textBoxCP.Location = new System.Drawing.Point(160, 384);
            this.textBoxCP.Name = "textBoxCP";
            this.textBoxCP.Size = new System.Drawing.Size(193, 22);
            this.textBoxCP.TabIndex = 20;
            this.textBoxCP.Text = "Localidade";
            // 
            // labelNomeVeiculo
            // 
            this.labelNomeVeiculo.AutoSize = true;
            this.labelNomeVeiculo.Location = new System.Drawing.Point(23, 34);
            this.labelNomeVeiculo.Name = "labelNomeVeiculo";
            this.labelNomeVeiculo.Size = new System.Drawing.Size(111, 16);
            this.labelNomeVeiculo.TabIndex = 21;
            this.labelNomeVeiculo.Text = "Nome do Veiculo";
            // 
            // labelLot
            // 
            this.labelLot.AutoSize = true;
            this.labelLot.Location = new System.Drawing.Point(26, 81);
            this.labelLot.Name = "labelLot";
            this.labelLot.Size = new System.Drawing.Size(56, 16);
            this.labelLot.TabIndex = 22;
            this.labelLot.Text = "Lotação";
            // 
            // labelTar
            // 
            this.labelTar.AutoSize = true;
            this.labelTar.Location = new System.Drawing.Point(26, 134);
            this.labelTar.Name = "labelTar";
            this.labelTar.Size = new System.Drawing.Size(36, 16);
            this.labelTar.TabIndex = 23;
            this.labelTar.Text = "Tara";
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(26, 175);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(53, 16);
            this.labelModel.TabIndex = 24;
            this.labelModel.Text = "Modelo";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(26, 219);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(45, 16);
            this.labelMarca.TabIndex = 25;
            this.labelMarca.Text = "Marca";
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(26, 254);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(50, 16);
            this.labelEstado.TabIndex = 26;
            this.labelEstado.Text = "Estado";
            // 
            // labelClasse
            // 
            this.labelClasse.AutoSize = true;
            this.labelClasse.Location = new System.Drawing.Point(26, 302);
            this.labelClasse.Name = "labelClasse";
            this.labelClasse.Size = new System.Drawing.Size(49, 16);
            this.labelClasse.TabIndex = 27;
            this.labelClasse.Text = "Classe";
            // 
            // labelRua
            // 
            this.labelRua.AutoSize = true;
            this.labelRua.Location = new System.Drawing.Point(26, 343);
            this.labelRua.Name = "labelRua";
            this.labelRua.Size = new System.Drawing.Size(32, 16);
            this.labelRua.TabIndex = 28;
            this.labelRua.Text = "Rua";
            // 
            // labelCP
            // 
            this.labelCP.AutoSize = true;
            this.labelCP.Location = new System.Drawing.Point(29, 389);
            this.labelCP.Name = "labelCP";
            this.labelCP.Size = new System.Drawing.Size(75, 16);
            this.labelCP.TabIndex = 29;
            this.labelCP.Text = "Localidade";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 736);
            this.Controls.Add(this.labelCP);
            this.Controls.Add(this.labelRua);
            this.Controls.Add(this.labelClasse);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.labelTar);
            this.Controls.Add(this.labelLot);
            this.Controls.Add(this.labelNomeVeiculo);
            this.Controls.Add(this.textBoxCP);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btAtualizar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.cbClasse);
            this.Controls.Add(this.textBoxRua);
            this.Controls.Add(this.textBoxTara);
            this.Controls.Add(this.textBoxLotação);
            this.Controls.Add(this.textBoxNomeVeiculo);
            this.Controls.Add(this.dataGridViewVeiculos);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVeiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewVeiculos;
        private System.Windows.Forms.TextBox textBoxNomeVeiculo;
        private System.Windows.Forms.TextBox textBoxLotação;
        private System.Windows.Forms.TextBox textBoxTara;
        private System.Windows.Forms.TextBox textBoxRua;
        private System.Windows.Forms.ComboBox cbClasse;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxCP;
        private System.Windows.Forms.Label labelNomeVeiculo;
        private System.Windows.Forms.Label labelLot;
        private System.Windows.Forms.Label labelTar;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label labelClasse;
        private System.Windows.Forms.Label labelRua;
        private System.Windows.Forms.Label labelCP;
    }
}

