using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            conexao.CreateTable<Agendamento>();
        }
    }
}
