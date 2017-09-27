﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	public partial class AgendamentoView : ContentPage
	{
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        public AgendamentoView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Veiculo = veiculo;
            this.BindingContext = this;
		}
	}
}