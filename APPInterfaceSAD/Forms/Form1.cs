using APPInterfaceSAD.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using APPInterfaceSAD.Models;

namespace APPInterfaceSAD
{
    public partial class Form1 : Form
    {
        private readonly VeiculoService _veiculos = new VeiculoService();

        public Form1()
        {
            InitializeComponent();

            // Wire up button handlers if not already wired in designer
            this.buttonInserir.Click += buttonInserir_Click;
            this.btAtualizar.Click += btAtualizar_Click;
            this.dataGridViewVeiculos.SelectionChanged += dataGridViewVeiculos_SelectionChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Populate combos from database
            try
            {
                // Classes
                var classes = _veiculos.ObterClasses();
                cbClasse.DisplayMember = "DesClasse";
                cbClasse.ValueMember = "Cid";
                cbClasse.DataSource = classes;

                // Estado options (static or could be fetched from DB if you add a table)
                cbEstado.Items.Clear();
                cbEstado.Items.AddRange(new object[] { "Operacional", "Oficina", "Abatido" });
                cbEstado.SelectedIndex =0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load combos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                dataGridViewVeiculos.DataSource = _veiculos.ObterVeiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to load vehicles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Populate inputs when a row is selected
        private void dataGridViewVeiculos_SelectionChanged(object sender, EventArgs e)
        {
            var rowView = dataGridViewVeiculos.CurrentRow?.DataBoundItem as DataRowView;
            if (rowView == null) return;

            textBoxNomeVeiculo.Text = rowView["NomeVeiculo"] as string ?? "";
            textBoxLotação.Text = (rowView["lotacao"] is int l) ? l.ToString() : "";
            textBoxTara.Text = (rowView["tara"] is int t) ? t.ToString() : "";
            textBoxRua.Text = rowView["Rua"] as string ?? "";

            var estado = rowView["Estado"] as string ?? "";
            var idx = cbEstado.FindStringExact(estado);
            cbEstado.SelectedIndex = idx >= 0 ? idx : 0;

            // Now that CP is in the grid, reflect it into the textbox
            textBoxCP.Text = (rowView["CP"] is int cpVal) ? cpVal.ToString() : "";
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewVeiculos.CurrentRow == null)
            {
                MessageBox.Show(this, "Select a vehicle row to update.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract Vid from the bound grid (expects column named "Vid")
            var row = dataGridViewVeiculos.CurrentRow.DataBoundItem as DataRowView;
            if (row == null || !(row["Vid"] is int vid) || vid <= 0)
            {
                MessageBox.Show(this, "Cannot determine selected vehicle ID.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var v = new Veiculo
            {
                Vid = vid,
                NomeVeiculo = textBoxNomeVeiculo.Text?.Trim(),
                Lotacao = ParseNullableInt(textBoxLotação.Text),
                Tara = ParseNullableInt(textBoxTara.Text),
                Rua = textBoxRua.Text?.Trim(),
                Estado = cbEstado.Text?.Trim(),
                Cid = cbClasse.SelectedValue is int cidVal ? cidVal : 0,
                ModID = 1,                // replace when you add a Modelo selector
                CPCP = ParseNullableInt(textBoxCP.Text) ?? 0,
                CP = ParseNullableInt(textBoxCP.Text),
            };

            if (string.IsNullOrWhiteSpace(v.NomeVeiculo) || v.Cid <= 0 || v.CPCP <= 0)
            {
                MessageBox.Show(this, "Fill required fields (Nome, Classe, Código Postal).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _veiculos.AtualizarVeiculo(v);
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Update failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            var nomeVeiculo = textBoxNomeVeiculo.Text?.Trim();
            int? lotacao = ParseNullableInt(textBoxLotação.Text);
            int? tara = ParseNullableInt(textBoxTara.Text);
            string estado = cbEstado.Text?.Trim();
            string rua = textBoxRua.Text?.Trim();

            int cid = cbClasse.SelectedValue is int cidVal ? cidVal :0;

            // Get postal code from new textbox
            int? cp = ParseNullableInt(textBoxCP.Text);
            int cpcp = cp ??0; // required FK to CodigoPostal.CP

            // UI currently has no model selector; placeholder until added
            int modId =1;

            if (string.IsNullOrWhiteSpace(nomeVeiculo))
            {
                MessageBox.Show(this, "Vehicle name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNomeVeiculo.Focus();
                return;
            }
            if (cid <=0)
            {
                MessageBox.Show(this, "Select a classe.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClasse.DroppedDown = true;
                return;
            }
            if (cpcp <=0)
            {
                MessageBox.Show(this, "Enter um código postal válido.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCP.Focus();
                return;
            }

            try
            {
                var veiculo = new Veiculo
                {
                    NomeVeiculo = nomeVeiculo,
                    Lotacao = lotacao,
                    Tara = tara,
                    CP = cp,
                    Rua = rua,
                    Estado = estado,
                    Cid = cid,
                    ModID = modId,
                    CPCP = cpcp
                };

                int newId = _veiculos.InserirVeiculo(veiculo);
                MessageBox.Show(this, $"Inserted vehicle with ID {newId}.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear inputs
                textBoxNomeVeiculo.Clear();
                textBoxLotação.Clear();
                textBoxTara.Clear();
                textBoxRua.Clear();
                textBoxCP.Clear();
                cbClasse.SelectedIndex = -1;
                cbEstado.SelectedIndex =0;

                // Refresh data
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Insert failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int? ParseNullableInt(string s)
        {
            if (int.TryParse(s, out var n)) return n;
            return null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // keep handler present to satisfy designer; implement if needed
        }

        private void buttonInserir_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNomeVeiculo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}