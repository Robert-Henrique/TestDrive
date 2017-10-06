using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewsModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListagemView : ContentPage
    {
        public  ListagemViewModel viewModel { get; set; }
        readonly Usuario usuario;

        public ListagemView(Usuario usuario)
        {
            InitializeComponent();
            this.viewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            await this.viewModel.GetVeiculos();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
            (veiculo) =>
            {
                Navigation.PushAsync(new DetalheView(veiculo, usuario));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
