using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAgendaContatos
{
    //Classe para conter os atributos e as propriedades do projeto
    class cl_Contato
    {
        //área dos atributos

        //criação dos campos
        private int codcontato;
        private string nome;
        private string telefone;
        private string celular;
        private string email;

        //criação das propriedades
        public int CodContato
        {
            get { return codcontato; }
            set { codcontato = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
