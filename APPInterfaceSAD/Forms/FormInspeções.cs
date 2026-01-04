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
                comboBoxInspMat.ValueMember = "MaterialID";
                comboBoxInspMat.DataSource = materiais;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Falha ao carregar listas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadGrid();
        }

        private void LoadGrid()
        {
            try
            {
                var dt = _service.ObterInspecoes();
                dataGridViewInsp.AutoGenerateColumns = false;
                dataGridViewInsp.Columns.Clear();

                dataGridViewInsp.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "InspID",
                    HeaderText = "ID",
                    Name = "colInspID",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });
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
                int newId = _service.InserirInspecao(dataInsp, vid, mat);
                MessageBox.Show(this, $"Inspeção registada com ID {newId}.", "Sucesso",
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
