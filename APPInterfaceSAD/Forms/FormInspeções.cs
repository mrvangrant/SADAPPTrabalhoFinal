using System;
using System.Data;
using System.Windows.Forms;
using APPInterfaceSAD.Services;

namespace APPInterfaceSAD.Forms
{
    public partial class FormInspeções : Form
    {
        private readonly InspeçõesService _service = new InspeçõesService();

        public FormInspeções()
        {
            InitializeComponent();

            // Wire actions
            buttonRegInsp.Click += buttonRegInsp_Click;
            comboBoxInspVehi.SelectedValueChanged += comboBoxInspVehi_SelectedValueChanged;

            // Grid setup
            dataGridViewInsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewInsp.ReadOnly = true;
            dataGridViewInsp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Bind combos
            try
            {
                var veiculos = _service.ObterVeiculosLite();
                comboBoxInspVehi.DisplayMember = "NomeVeiculo";
                comboBoxInspVehi.ValueMember = "Vid";
                comboBoxInspVehi.DataSource = veiculos;

                var materiais = _service.ObterMateriais();
                comboBoxInspMat.DisplayMember = "DescMat";
                comboBoxInspMat.ValueMember = "MatID"; // composite PK uses MatID
                comboBoxInspMat.DataSource = materiais;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Falha ao carregar listas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void comboBoxInspVehi_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                int vid = comboBoxInspVehi.SelectedValue is int v ? v : 0;
                string veiculoNome = (comboBoxInspVehi.Text ?? string.Empty).Trim();

                var dt = (vid > 0)
                    ? _service.ObterInspecoesPorVeiculo(vid)
                    : new DataTable();

                // Fallbacks: ensure Veiculo (and Vid) columns exist for binding
                if (dt != null)
                {
                    if (!dt.Columns.Contains("Veiculo"))
                        dt.Columns.Add("Veiculo", typeof(string));
                    if (!dt.Columns.Contains("Vid"))
                        dt.Columns.Add("Vid", typeof(int));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Veiculo"] == DBNull.Value || string.IsNullOrWhiteSpace(Convert.ToString(row["Veiculo"])))
                            row["Veiculo"] = veiculoNome;
                        if (row["Vid"] == DBNull.Value || (row["Vid"] is int rvid && rvid == 0))
                            row["Vid"] = vid;
                    }
                }

                dataGridViewInsp.AutoGenerateColumns = false;
                dataGridViewInsp.Columns.Clear();

                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DataInsp",
                    HeaderText = "Data",
                    Name = "colData",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }
                });
                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Veiculo",
                    HeaderText = "Veículo",
                    Name = "colVeiculo",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Material",
                    HeaderText = "Material",
                    Name = "colMaterial",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Vid",
                    HeaderText = "Vid",
                    Name = "colVid",
                    Visible = false
                });
                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MatID",
                    HeaderText = "MatID",
                    Name = "colMatID",
                    Visible = false
                });

                dataGridViewInsp.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Falha ao carregar inspeções: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegInsp_Click(object sender, EventArgs e)
        {
            var dataInsp = dateTimePickerInsp.Value;
            int vid = comboBoxInspVehi.SelectedValue is int v ? v : 0;
            int mat = comboBoxInspMat.SelectedValue is int m ? m : 0;

            if (vid <= 0 || mat <= 0)
            {
                MessageBox.Show(this, "Selecione Veículo e Material.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _service.InserirInspecao(dataInsp, vid, mat);
                MessageBox.Show(this,
                    $"Inspeção registada para Vid={vid}, MatID={mat}.",
                    "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Registo falhou: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
