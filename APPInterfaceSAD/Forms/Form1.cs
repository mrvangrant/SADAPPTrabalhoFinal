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
            this.buttonInserir.Click += buttonInserir_Click;
            this.btAtualizar.Click += btAtualizar_Click;
            this.dataGridViewVeiculos.SelectionChanged += dataGridViewVeiculos_SelectionChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                var classes = _veiculos.ObterClasses();
                cbClasse.DisplayMember = "DesClasse";
                cbClasse.ValueMember = "Cid";
                cbClasse.DataSource = classes;

                cbEstado.Items.Clear();
                cbEstado.Items.AddRange(new object[] { "Operacional", "Oficina", "Abatido" });
                cbEstado.SelectedIndex = 0;
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

            // reflect modelo and marca names
            textBoxModelo.Text = rowView["Modelo"] as string ?? "";
            textBoxMarca.Text = rowView["Marca"] as string ?? "";
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

            var nomeMarca = textBoxMarca.Text?.Trim();
            var nomeModelo = textBoxModelo.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nomeMarca))
            {
                MessageBox.Show(this, "Brand name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMarca.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(nomeModelo))
            {
                MessageBox.Show(this, "Model name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxModelo.Focus();
                return;
            }

            int maId, modId;
            try
            {
                maId = _veiculos.EnsureMarcaAuto(nomeMarca);
                modId = _veiculos.EnsureModeloAuto(nomeModelo, maId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to resolve brand/model: " + ex.Message, "Error",
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
                ModID = modId,
                CPCP = 1,
                CP = null,
            };

            if (string.IsNullOrWhiteSpace(v.NomeVeiculo) || v.Cid <= 0 || v.ModID <= 0)
            {
                MessageBox.Show(this, "Fill required fields (Nome, Classe, Modelo).", "Validation",
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
            int cid = cbClasse.SelectedValue is int cidVal ? cidVal : 0;

            var nomeMarca = textBoxMarca.Text?.Trim();
            var nomeModelo = textBoxModelo.Text?.Trim();
            if (string.IsNullOrWhiteSpace(nomeMarca))
            {
                MessageBox.Show(this, "Brand name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMarca.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(nomeModelo))
            {
                MessageBox.Show(this, "Model name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxModelo.Focus();
                return;
            }

            int maId, modId;
            try
            {
                maId = _veiculos.EnsureMarcaAuto(nomeMarca);
                modId = _veiculos.EnsureModeloAuto(nomeModelo, maId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Failed to resolve brand/model: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cpcp = 1;
            int? cp = null;

            if (string.IsNullOrWhiteSpace(nomeVeiculo))
            {
                MessageBox.Show(this, "Vehicle name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNomeVeiculo.Focus();
                return;
            }
            if (cid <= 0)
            {
                MessageBox.Show(this, "Select a classe.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbClasse.DroppedDown = true;
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

                textBoxNomeVeiculo.Clear();
                textBoxLotação.Clear();
                textBoxTara.Clear();
                textBoxRua.Clear();
                textBoxModelo.Clear();
                textBoxMarca.Clear();
                cbClasse.SelectedIndex = -1;
                cbEstado.SelectedIndex = 0;

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
    }
}