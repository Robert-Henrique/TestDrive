using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestDrive.ViewsModels;

namespace TestDrive.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", async (agendamento) =>
            {
                var confirma = await DisplayAlert("Salvar Agendamento", "Deseja mesmo enviar o agendamento?", "Sim", "Não");

                if (confirma)
                {
                    string mensagem = string.Format("Nome: {0} Fone: {1} E-mail: {2} Data Agendamento: {3} Hora Agendamento: {4}", agendamento.Nome, agendamento.Fone, agendamento.Email, agendamento.DataAgendamento.ToString("dd/MM/yyyy"), agendamento.HoraAgendamento);
                    DisplayAlert("Agendamento", mensagem, "Ok");
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}