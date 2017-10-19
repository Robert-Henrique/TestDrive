using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this.BindingContext = new AgendamentosUsuarioViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendamento) =>
            {
                var reenviar = await DisplayAlert("Reenviar", "Deseja reenviar o agendamento?", "sim", "não");

                if (reenviar)
                {

                }
            });
        }
    }
}