using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Security.Cryptography;
using System.Data;

namespace ProjetoAgendaContatos
{
    //classe contendo os métodos do projeto
    class cl_ControleContato
    {
        cl_Conexao c = new cl_Conexao();

        public string cadastrar(cl_Contato cont) //metodo criado para cadastrar o contato
        {
            try //criação do try catch para caso ocorrer algum erro na execução
            {
                //criação de uma variável com a sintaxe do código SQL de INSERT
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbcontato (nome, telefone, celular, email) " +
                     "VALUES ('" + cont.Nome + "','" + cont.Telefone + "', '" + cont.Celular + "', '" + cont.Email + "')", c.con);

                //conexão com o banco
                c.conectar();

                //erro
                //executar a variável alterada sql
                cmd.ExecuteNonQuery();
                //desconectar do banco
                c.desconectar();
                //retorna uma mensagem para indicar o fim da execução
                return ("Cadastrado com sucesso!");

            }
            catch (MySqlException e)
            {
                //caso de erro irá retornar o erro em uma messagebox
                return (e.ToString());
            }
        }

        public string alterar(cl_Contato cont) //metodo criado para alterar o contato
        {
            try //criação do try catch para caso ocorrer algum erro na execução
            {
                //criação de uma variável com a sintaxe do código SQL de UPDATE
                string sql = "UPDATE tbcontato SET NOME = '" + cont.Nome + "' ,  " + "telefone = '" + cont.Telefone + "', celular = '" + cont.Celular + "', email = '" + cont.Email + "' WHERE codcontato = " + cont.CodContato + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con); 

                //conexão com o banco
                c.conectar();
                //executar a variável alterada sql
                cmd.ExecuteNonQuery();
                //desconectar do banco
                c.desconectar();

                //retorna uma mensagem para indicar o fim da execução
                return ("Alterado com sucesso!");
            }
            catch (MySqlException e) 
            {
                //caso de erro irá retornar o erro em uma messagebox
                return (e.ToString());
            }
        }

        public string deletar(cl_Contato cont) //metodo criado para deletar o contato
        {
            try //criação do try catch para caso ocorrer algum erro na execução
            {
                //criação de uma variável com a sintaxe do código SQL de DELETE
                string sql = "DELETE FROM tbcontato WHERE codcontato = " + cont.CodContato + ";";

                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //conexão com o banco
                c.conectar();
                //executar a variável alterada sql
                cmd.ExecuteNonQuery();
                //desconectar do banco
                c.desconectar();

                //retorna uma mensagem para indicar o fim da execução
                return ("Deletado com sucesso!");
            }
            catch (MySqlException e)
            {
                //caso de erro irá retornar o erro em uma messagebox
                return (e.ToString());
            }
        }

        public  cl_Contato buscar(int codigo) //metodo criado para deletar o contato
        {
            cl_Contato cont = new cl_Contato();
            try //criação do try catch para caso ocorrer algum erro na execução
            {
                //criação de uma variável com a sintaxe do código SQL de SELECT
                string sql = "SELECT * FROM tbcontato where codcontato = " + codigo + ";";

                //conexão com o banco
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                c.conectar();

                //leitura do banco
                MySqlDataReader objDados = cmd.ExecuteReader();
                

                if (!objDados.HasRows)
                {
                    //return ("Código não encontrado!");
                    return null;
                }
                else
                {
                    //coloca os dados da busca nas variaveis
                    objDados.Read();
                    cont.CodContato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = (objDados["nome"]).ToString();
                    cont.Telefone = (objDados["telefone"]).ToString();
                    cont.Celular = (objDados["celular"]).ToString();
                    cont.Email = (objDados["email"]).ToString();

                    objDados.Close();
                    return cont;
                }
            }
            catch (MySqlException e)
            {
                //caso de erro irá retornar o erro em uma messagebox
                throw (e);
            }
            finally //finalizar a ação (conexão com o banco)
            {
                c.desconectar();
            }
        }

        public DataTable PreencherTodos() //metodo criado para aparecer todos os dados no datagridview
        {
            //criação da variavel sql com o comando em SQL para ser executado
            string slq = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "Celular as 'Celular', email as 'Email' FROM tbcontato ;" ;

            MySqlCommand cmd = new MySqlCommand(slq, c.con);

            //conectando no banco
            c.conectar();

            //instanciando o MySaqlDataAdapter com o cmd instanciado de parametro
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            //instanciando outra metodo
            DataTable contato = new DataTable();

            //mostrando as linhas da tabela contato
            da.Fill(contato);
            //desconectando do banco
            c.desconectar();

            //retornando a variavel do banco
            return contato;
        }

        public DataTable pesquisaCodigo(int codigo)
        {
            string sql = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "celular as 'Celular', email as 'Email' FROM tbcontato WHERE codcontato = '" + codigo + "'; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }
        public DataTable pesquisaNome(string nome)
        {
            string sql = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "celular as 'Celular', email as 'Email' FROM tbcontato WHERE nome = '" + nome + "'; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaTelefone(string telefone)
        {
            string sql = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "celular as 'Celular', email as 'Email' FROM tbcontato WHERE telefone = '" + telefone + "'; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaCelular(string celular)
        {
            string sql = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "celular as 'Celular', email as 'Email' FROM tbcontato WHERE celular = '" + celular + "'; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }
        public DataTable pesquisaEmail(string email)
        {
            string sql = "SELECT codcontato as 'Código', nome as 'Nome', telefone as 'Telefone', " + "celular as 'Celular', email as 'Email' FROM tbcontato WHERE email = '" + email + "'; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;
        }
    }
}
