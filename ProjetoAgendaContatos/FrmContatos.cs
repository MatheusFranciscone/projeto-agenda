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
    public partial class FrmContatos : Form
    {
        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();
        

        public FrmContatos()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            txtCelular.Clear();
            txtCodigo.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }

        public void Dark()
        {
            this.BackColor = Color.FromArgb(54, 54, 54);
            txtCodigo.BackColor = Color.FromArgb(54, 54, 54);
            txtNome.BackColor = Color.FromArgb(54, 54, 54);
            txtTelefone.BackColor = Color.FromArgb(54, 54, 54);
            txtCelular.BackColor = Color.FromArgb(54, 54, 54);
            txtEmail.BackColor = Color.FromArgb(54, 54, 54);
            txtCodigo.ForeColor = Color.White;
            txtNome.ForeColor = Color.White;
            txtTelefone.ForeColor = Color.White;
            txtCelular.ForeColor = Color.White;
            txtEmail.ForeColor = Color.White;
            lblCodigo.ForeColor = Color.White;
            lblNome.ForeColor = Color.White;
            lblTelefone.ForeColor = Color.White;
            lblCelular.ForeColor = Color.White;
            lblEmail.ForeColor = Color.White;
            lblTexto.ForeColor = Color.White;
            btnAlterar.BackColor = Color.FromArgb(112, 128, 144);
            btnCadastrar.BackColor = Color.FromArgb(112, 128, 144);
            btnExcluir.BackColor = Color.FromArgb(112, 128, 144);
            btnConsulta.BackColor = Color.FromArgb(112, 128, 144);
            btnPesquisar.BackColor = Color.FromArgb(112, 128, 144);
            btnDarkMode.Visible = false;
            btnWhiteMode.Visible = true;
            txtNome.Focus();
        }

        public void Light()
        {
            this.BackColor = Color.White;
            txtCodigo.BackColor = Color.White;
            txtNome.BackColor = Color.White;
            txtTelefone.BackColor = Color.White;
            txtCelular.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtCodigo.ForeColor = Color.Black;
            txtNome.ForeColor = Color.Black;
            txtTelefone.ForeColor = Color.Black;
            txtCelular.ForeColor = Color.Black;
            txtEmail.ForeColor = Color.Black;
            lblCodigo.ForeColor = Color.Black;
            lblNome.ForeColor = Color.Black;
            lblTelefone.ForeColor = Color.Black;
            lblCelular.ForeColor = Color.Black;
            lblEmail.ForeColor = Color.Black;
            lblTexto.ForeColor = Color.Black;
            btnAlterar.BackColor = Color.Red;
            btnCadastrar.BackColor = Color.Red;
            btnExcluir.BackColor = Color.Red;
            btnConsulta.BackColor = Color.Red;
            btnPesquisar.BackColor = Color.Red;
            btnDarkMode.Visible = true;
            btnWhiteMode.Visible = false;
            txtNome.Focus();
        }

        private void frmContatos_Load(object sender, EventArgs e)
        {
                cl_Conexao c = new cl_Conexao();
                MessageBox.Show(c.conectar());
                txtNome.Focus();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if ( txtNome.Text == "" || txtTelefone.Text == "" || txtCelular.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Digite as informações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //atribuição dos valores que o usuário digita para as variáveis
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont)); //executa o método cadastrar da classe cl_ControleContato
                Limpar(); //executa o método para limpar os campos e colocar o foco no textbox nome
            }
           
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNome.Text == "" && txtTelefone.Text == "" && txtCelular.Text == "" && txtEmail.Text == "")
            {
                MessageBox.Show("Digite os dados para poder alterá-los!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //atribuição dos valores que o usuário digita para as variáveis
                cont.CodContato = int.Parse(txtCodigo.Text);
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.alterar(cont)); //executa o método alterar da classe cl_ControleContato
                Limpar(); //executa o método para limpar os campos e colocar o foco no textbox nome
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNome.Text == "" && txtTelefone.Text == "" && txtCelular.Text == ""  && txtEmail.Text == "")
            {
                MessageBox.Show("Digite pelo menos o código para poder excluir!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //atribuição dos valores que o usuário digita para as variáveis
                cont.CodContato = int.Parse(txtCodigo.Text);
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.deletar(cont)); //executa o método deletar da classe cl_ControleContato
                Limpar(); //executa o método para limpar os campos e colocar o foco no textbox nome
            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Digite o código para fazer a busca!");
            }
            else
            {
                try
                {
                    cont = controle.buscar(int.Parse(txtCodigo.Text)); //chamada do método com o código inserido no textbox
                    if (cont is null) //se não existir nenhum código no banco informado
                    {
                        MessageBox.Show("Dados não encontrados!");
                        Limpar();
                    }
                    else //ira atribuir as variaveis com os dados salvos e aparecera nos textboxs
                    {
                        txtCodigo.Text = cont.CodContato.ToString();
                        txtNome.Text = cont.Nome;
                        txtTelefone.Text = cont.Telefone;
                        txtCelular.Text = cont.Celular;
                        txtEmail.Text = cont.Email;
                    }
                }
                catch (Exception ex) //caso houver algum erro irá informar
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        //validação para não ocorrer erro nos campos
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmContatos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ao clicar no enter você desce de textbox
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            Dark();
        }

        private void btnWhiteMode_Click(object sender, EventArgs e)
        {
            Light();
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmConsulta consulta = new FrmConsulta();
            consulta.Show();
            this.Hide();
        }
    }
}
