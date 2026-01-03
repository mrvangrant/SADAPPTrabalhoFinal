using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPInterfaceSAD.Forms
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();

            // Wire navigation buttons
            buttonNavVeiculos.Click += ButtonNavVeiculos_Click;
            buttonNavRequisições.Click += ButtonNavRequisições_Click;
            buttonNavInspeções.Click += ButtonNavInspeções_Click;
        }

        private void ButtonNavVeiculos_Click(object sender, EventArgs e)
        {
            var f = new APPInterfaceSAD.Form1();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void ButtonNavRequisições_Click(object sender, EventArgs e)
        {
            var f = new FormRequisições();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void ButtonNavInspeções_Click(object sender, EventArgs e)
        {
            var f = new FormInspeções();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }
    }
}
