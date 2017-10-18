﻿using System;
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
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos", (usuario) =>
            {
                this.Detail = new AgendamentosUsuarioView();
                this.IsPresented = false;
            });
        }
    }
}