using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaContatos
{
    public partial class FrmConsulta : Form
    {

        public FrmConsulta()
        {
            InitializeComponent();
        }
        public void preset()
        {
            cbOpcoes.SelectedIndex = -1;
            txtOpcao.Clear();
            dgvContatos.Columns.Clear();
            lblOpcao.Text = "Opção: ";
            txtOpcao.Focus();
        }

        public void Dark()
        {
            this.BackColor = Color.FromArgb(54, 54, 54);
            txtOpcao.BackColor = Color.FromArgb(54, 54, 54);
            cbOpcoes.BackColor = Color.FromArgb(54, 54, 54);
            lblEscolha.ForeColor = Color.White;
            lblOpcao.ForeColor = Color.White;
            lblTexto.ForeColor = Color.White;
            btnBuscar.BackColor = Color.FromArgb(112, 128, 144);
            btnLimpar.BackColor = Color.FromArgb(112, 128, 144);
            cbOpcoes.ForeColor = Color.White;
            btnListarTodos.BackColor = Color.FromArgb(112, 128, 144);
            btnRelatorio.BackColor = Color.FromArgb(112, 128, 144);
            btnVoltar.BackColor = Color.FromArgb(112, 128, 144);
            dgvContatos.BackgroundColor = Color.FromArgb(112, 128, 144);
            txtOpcao.ForeColor = Color.White;
            btnDarkMode.Visible = false;
            btnWhiteMode.Visible = true;
            cbOpcoes.Focus();
        }

        public void Light()
        {
            this.BackColor = Color.White;
            txtOpcao.BackColor = Color.White;
            cbOpcoes.BackColor = Color.White;
            lblEscolha.ForeColor = Color.Black;
            lblOpcao.ForeColor = Color.Black;
            lblTexto.ForeColor = Color.Black;
            btnBuscar.BackColor = Color.Red;
            btnLimpar.BackColor = Color.Red;
            cbOpcoes.ForeColor= Color.Black;
            btnListarTodos.BackColor = Color.Red;
            btnRelatorio.BackColor = Color.Red;
            btnVoltar.BackColor = Color.Red;
            dgvContatos.BackgroundColor = Color.White;
            txtOpcao.ForeColor = Color.Black;
            btnDarkMode.Visible = true;
            btnWhiteMode.Visible = false;
            cbOpcoes.Focus();
        }

        FrmContatos cont = new FrmContatos();

        cl_ControleContato controle = new cl_ControleContato();

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            cl_Conexao c = new cl_Conexao();
            c.conectar();
            preset();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcoes.SelectedIndex == 0)
            {
                try
                {
                    int codigo = Convert.ToInt32(txtOpcao.Text);

                    dgvContatos.DataSource = controle.pesquisaCodigo(codigo);
                }
                catch
                {
                    MessageBox.Show("Digite um valor inteiro para o código!");
                    txtOpcao.Clear();
                    txtOpcao.Focus();
                }
            }
            else if (cbOpcoes.SelectedIndex == 1)
            {
                try
                {
                    string nome = txtOpcao.Text;

                    dgvContatos.DataSource = controle.pesquisaNome(nome);
                }
                catch
                {
                    MessageBox.Show("Digite um valor para o nome!");
                    txtOpcao.Clear();
                    txtOpcao.Focus();
                }
            }
            else if (cbOpcoes.SelectedIndex == 2)
            {
                try
                {
                    string telefone = txtOpcao.Text;

                    dgvContatos.DataSource = controle.pesquisaTelefone(telefone);
                }
                catch
                {
                    MessageBox.Show("Digite um valor para o telefone!");
                    txtOpcao.Clear();
                    txtOpcao.Focus();
                }
            }
            else if (cbOpcoes.SelectedIndex == 3)
            {
                try
                {
                    string celular = txtOpcao.Text;

                    dgvContatos.DataSource = controle.pesquisaCelular(celular);
                }
                catch
                {
                    MessageBox.Show("Digite um valor para o celular!");
                    txtOpcao.Clear();
                    txtOpcao.Focus();
                }
            }
            else
            {
                try
                {
                    string email = txtOpcao.Text;

                    dgvContatos.DataSource = controle.pesquisaEmail(email);
                }
                catch
                {
                    MessageBox.Show("Digite um valor para o E-mail!");
                    txtOpcao.Clear();
                    txtOpcao.Focus();
                }
            }
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbOpcoes.SelectedIndex < 0)
            {
                txtOpcao.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcao.Text = "";
            }
            else
            {
                txtOpcao.Enabled = true;
                lblOpcao.Text = "Digite o " + cbOpcoes.Text + ": ";
                txtOpcao.Clear();
                txtOpcao.Focus();
            }
        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {   
            //atribuição aos dados do DataGridView o método PreencherTodos()
            dgvContatos.DataSource = controle.PreencherTodos();
        }

        private void txtOpcao_TextChanged(object sender, EventArgs e)
        {
            if (txtOpcao.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmContatos cont = new FrmContatos();
            cont.Show();
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            preset();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            FrmRelatorio rel = new FrmRelatorio();
            rel.ShowDialog();
        }

        private void btnWhiteMode_Click(object sender, EventArgs e)
        {
            Light();
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            Dark();
        }
    }
}
