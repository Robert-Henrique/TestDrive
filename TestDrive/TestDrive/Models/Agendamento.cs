using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Agendamento
    {
        public string Nome { get; private set; }
        public string Fone { get; private set; }
        public string Email { get; private set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }

        DateTime dataAgendamento = DateTime.Now;
        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }
            set
            {
                dataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento { get; set; }

        public Agendamento(string nome, string fone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Fone = fone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }
    }
}
