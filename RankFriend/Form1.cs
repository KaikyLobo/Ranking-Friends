using RankingAmigos.Modelos;
using RankingAmigos.Servicos;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RankFriend
{
    public partial class Form1 : Form
    {
        private readonly AmigoServico servico = new AmigoServico();

        public Form1()
        {
            InitializeComponent();
            ConfigurarTabela();
            CarregarAmigos();
            KeyPreview = true;
        }

        private void ConfigurarTabela()
        {
            dgvAmigos.ReadOnly = true;
            dgvAmigos.AllowUserToAddRows = false;
            dgvAmigos.AllowUserToDeleteRows = false;
            dgvAmigos.MultiSelect = false;
            dgvAmigos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAmigos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarAmigos()
        {
            try
            {
                dgvAmigos.DataSource = null;
                dgvAmigos.DataSource = servico.Listar();

                if (dgvAmigos.Columns.Count > 0)
                {
                    dgvAmigos.Columns["Id"].Visible = false;
                    dgvAmigos.Columns["Nome"].HeaderText = "Nome";
                    dgvAmigos.Columns["Posicao"].HeaderText = "Posição";
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Não foi possível conectar ao banco de dados. Verifique se o MySQL está em execução.",
                    "Erro de banco de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            erroProvider.Clear();

            string nome = txtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                erroProvider.SetError(txtNome, "Informe o nome do amigo.");
                valido = false;
            }
            else if (nome.Length > 100)
            {
                erroProvider.SetError(txtNome, "O nome deve ter no máximo 100 caracteres.");
                valido = false;
            }

            return valido;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                servico.Adicionar(
                    txtNome.Text,
                    (int)nudPosicao.Value
                );

                MessageBox.Show(
                    "Amigo adicionado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();
                CarregarAmigos();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Não foi possível acessar o banco de dados. Verifique se o MySQL está em execução.",
                    "Erro de banco de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao adicionar o amigo.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                if (dgvAmigos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um amigo.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Amigo amigo = (Amigo)dgvAmigos.CurrentRow.DataBoundItem;

                amigo.Nome = txtNome.Text;
                amigo.Posicao = (int)nudPosicao.Value;

                servico.Atualizar(amigo);

                MessageBox.Show(
                    "Amigo atualizado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimparCampos();
                CarregarAmigos();
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Não foi possível acessar o banco de dados. Verifique se o MySQL está em execução.",
                    "Erro de banco de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao atualizar o amigo.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAmigos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Selecione um amigo.",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Amigo amigo = (Amigo)dgvAmigos.CurrentRow.DataBoundItem;

                DialogResult resultado = MessageBox.Show(
                    "Deseja realmente excluir este amigo?",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    servico.Excluir(amigo.Id);

                    MessageBox.Show(
                        "Amigo excluído com sucesso.",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimparCampos();
                    CarregarAmigos();
                }
            }
            catch (RegraNegocioException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Não foi possível acessar o banco de dados. Verifique se o MySQL está em execução.",
                    "Erro de banco de dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ocorreu um erro ao excluir o amigo.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvAmigos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Amigo amigo =
                    (Amigo)dgvAmigos.Rows[e.RowIndex].DataBoundItem;

                txtNome.Text = amigo.Nome;
                nudPosicao.Value = amigo.Posicao;

                erroProvider.Clear();
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            nudPosicao.Value = 1;
            erroProvider.Clear();
            txtNome.Focus();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && (txtNome.Focused || nudPosicao.Focused))
            {
                e.SuppressKeyPress = true;
                btnAdicionar.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnEditar.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete && dgvAmigos.Focused)
            {
                btnExcluir.PerformClick();
            }
        }
    }
}