using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            listViewVeiculos.ItemsSource = new string[]
            {
                "Azera v6",
                "Fiesta 2.0",
                "HB20 S"
            };
		}
	}
}
