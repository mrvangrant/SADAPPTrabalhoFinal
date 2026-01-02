using APPInterfaceSAD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPInterfaceSAD
{
    public partial class Form1 : Form
    {
        private readonly IClienteService _service;

        public Form1()
        {
            InitializeComponent();
            // Use in-memory service for trial without SQL
            _service = new InMemoryClienteService();
            // To switch back to SQL later, replace with:
            // _service = new ClienteService();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Populate contact types for quick testing
            cbTipoContacto.Items.Clear();
            cbTipoContacto.Items.AddRange(new object[] { "Email", "Telefone", "Telemóvel" });
            if (cbTipoContacto.Items.Count > 0)
                cbTipoContacto.SelectedIndex = 0;

            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                var table = _service.ObterClientes();
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load clients: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            var nome = textBox1.Text?.Trim();
            var nif = textBoxNIF.Text?.Trim();
            var tipo = cbTipoContacto.SelectedItem as string;
            var valor = textBoxContacto.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show(this, "Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(nif))
            {
                MessageBox.Show(this, "NIF is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNIF.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tipo))
            {
                MessageBox.Show(this, "Select a contact type.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTipoContacto.DroppedDown = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show(this, "Contact value is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxContacto.Focus();
                return;
            }

            try
            {
                _service.InserirClienteContacto(nome, nif, tipo, valor);
                ClearInputs();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Insert failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBoxNIF.Clear();
            textBoxContacto.Clear();
            if (cbTipoContacto.Items.Count > 0)
                cbTipoContacto.SelectedIndex = 0;
            textBox1.Focus();
        }
    }
}