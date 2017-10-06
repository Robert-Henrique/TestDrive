using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using TestDrive.ViewsModels;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; private set; }
        public Usuario Usuario { get; private set; }

        public DetalheView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.Usuario = usuario;
            this.BindingContext = new DetalheViewModel(veiculo); ;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (veiculo) =>
            {
                Navigation.PushAsync(new AgendamentoView(this.Veiculo, this.Usuario));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}