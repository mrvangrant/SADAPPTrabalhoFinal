using System;
using System.Data;
using System.Windows.Forms;
using APPInterfaceSAD.Services;

namespace APPInterfaceSAD.Forms
{
    public partial class FormRequisições : Form
    {
        private readonly RequisicoesService _service = new RequisicoesService();

        public FormRequisições()
        {
            InitializeComponent();

            // Wire buttons
            buttonReqInserir.Click += buttonReqInserir_Click;

            // Improve grid readability and size (use designer's dataGridView1)
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dataGridView1.Location = new System.Drawing.Point(20, 420);
            dataGridView1.Size = new System.Drawing.Size(1200, 280);
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Bind combos (Veículo, Condutor, Oficial)
            try
            {
                var veiculos = _service.ObterVeiculosLite();
                comboBox1.DisplayMember = "NomeVeiculo";
                comboBox1.ValueMember = "Vid";
                comboBox1.DataSource = veiculos;

                var condutores = _service.ObterCondutores();
                comboBox2.DisplayMember = "NomeCondutor";
                comboBox2.ValueMember = "CondutorID";
                comboBox2.DataSource = condutores;

                var oficiais = _service.ObterOficiais();
                comboBox3.DisplayMember = "NomeOficial";
                comboBox3.ValueMember = "OficialID";
                comboBox3.DataSource = oficiais;
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
                var dt = _service.ObterRequisicoes();

                // Use friendly headers
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ReqID",
                    HeaderText = "ID da Requisição",
                    Name = "colReqID",
                    ReadOnly = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "DataReq",
                    HeaderText = "Data da Requisição",
                    Name = "colDataReq",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd HH:mm" }
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Veiculo",
                    HeaderText = "Veículo",
                    Name = "colVeiculo",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Condutor",
                    HeaderText = "Condutor",
                    Name = "colCondutor",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Oficial",
                    HeaderText = "Oficial Responsável",
                    Name = "colOficial",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });

                // Optional: hide raw IDs
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Vid",
                    HeaderText = "Vid",
                    Name = "colVid",
                    Visible = false
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CondutorID",
                    HeaderText = "CondutorID",
                    Name = "colCondutorID",
                    Visible = false
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OficialID",
                    HeaderText = "OficialID",
                    Name = "colOficialID",
                    Visible = false
                });

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Falha ao carregar: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReqInserir_Click(object sender, EventArgs e)
        {
            DateTime? dataReq = dateTimePicker1.Value;
            int vid = comboBox1.SelectedValue is int v ? v : 0;
            int cond = comboBox2.SelectedValue is int c ? c : 0;
            int ofic = comboBox3.SelectedValue is int o ? o : 0;

            if (vid <= 0 || cond <= 0 || ofic <= 0)
            {
                MessageBox.Show(this, "Selecione Veículo, Condutor e Oficial.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int newId = _service.InserirRequisicao(dataReq, cond, vid, ofic);
                MessageBox.Show(this, $"Requisição inserida com ID {newId}.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Inserção falhou: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
