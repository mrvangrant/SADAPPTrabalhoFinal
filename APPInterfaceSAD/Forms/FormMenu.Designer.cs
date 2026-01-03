namespace APPInterfaceSAD.Forms
{
    partial class FormMenu
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
            this.labelMenu = new System.Windows.Forms.Label();
            this.buttonNavVeiculos = new System.Windows.Forms.Button();
            this.buttonNavRequisições = new System.Windows.Forms.Button();
            this.buttonNavInspeções = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Location = new System.Drawing.Point(127, 60);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(40, 16);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // buttonNavVeiculos
            // 
            this.buttonNavVeiculos.Location = new System.Drawing.Point(130, 121);
            this.buttonNavVeiculos.Name = "buttonNavVeiculos";
            this.buttonNavVeiculos.Size = new System.Drawing.Size(108, 23);
            this.buttonNavVeiculos.TabIndex = 1;
            this.buttonNavVeiculos.Text = "Veiculos";
            this.buttonNavVeiculos.UseVisualStyleBackColor = true;
            // 
            // buttonNavRequisições
            // 
            this.buttonNavRequisições.Location = new System.Drawing.Point(130, 177);
            this.buttonNavRequisições.Name = "buttonNavRequisições";
            this.buttonNavRequisições.Size = new System.Drawing.Size(108, 23);
            this.buttonNavRequisições.TabIndex = 2;
            this.buttonNavRequisições.Text = "Requisições";
            this.buttonNavRequisições.UseVisualStyleBackColor = true;
            // 
            // buttonNavInspeções
            // 
            this.buttonNavInspeções.Location = new System.Drawing.Point(130, 229);
            this.buttonNavInspeções.Name = "buttonNavInspeções";
            this.buttonNavInspeções.Size = new System.Drawing.Size(108, 23);
            this.buttonNavInspeções.TabIndex = 3;
            this.buttonNavInspeções.Text = "Inspeções";
            this.buttonNavInspeções.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 745);
            this.Controls.Add(this.buttonNavInspeções);
            this.Controls.Add(this.buttonNavRequisições);
            this.Controls.Add(this.buttonNavVeiculos);
            this.Controls.Add(this.labelMenu);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Button buttonNavVeiculos;
        private System.Windows.Forms.Button buttonNavRequisições;
        private System.Windows.Forms.Button buttonNavInspeções;
    }
}