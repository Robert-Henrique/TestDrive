using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentosUsuarioView : ContentPage
	{
		public AgendamentosUsuarioView()
		{
			InitializeComponent ();

            this.listViewAgendamentos.ItemsSource = new List<Agendamento>
            {
                new Agendamento("João da Silva", "1234-5678", "joao@alura.com.br", "Astra 2.0", 17000),
                new Agendamento("Robert Henrique", "1234-5678", "joao@alura.com.br", "Celta ", 37000),
            };
		}
	}
}