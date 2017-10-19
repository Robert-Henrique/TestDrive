using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;
        private List<Agendamento> lista;

        public List<Agendamento> Lista
        {
            get
            {
                return conexao.Table<Agendamento>().ToList();
            }

            private set { lista = value; }
        }


        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            conexao.Insert(agendamento);
        }
    }
}
