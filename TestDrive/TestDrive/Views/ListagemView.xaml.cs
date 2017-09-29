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

        public ListagemView()
        {
            InitializeComponent();
            this.viewModel = new ListagemViewModel();
            this.BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
            (veiculo) =>
            {
                Navigation.PushAsync(new DetalheView(veiculo));
            });

            await this.viewModel.GetVeiculos();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
