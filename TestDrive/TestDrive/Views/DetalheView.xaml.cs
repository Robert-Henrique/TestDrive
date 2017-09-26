using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestDrive.Views
{
	public partial class DetalheView : ContentPage
	{
        public Veiculo Veiculo { get; set; }

        public DetalheView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Title = veiculo.Nome;
            this.Veiculo = veiculo;
		}

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}