﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        readonly AgendamentosUsuarioViewModel _viewModel;
        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this._viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this._viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendamento) =>
            {
                if (agendamento.Confirmado)
                    return;

                var reenviar = await DisplayAlert("Reenviar", "Deseja reenviar o agendamento?", "sim", "não");

                if (reenviar)
                {
                    AgendamentoService agendamentoService = new AgendamentoService();
                    await agendamentoService.EnviarAgendamento(agendamento);
                    this._viewModel.AtualizarLista();
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Agendamento>(this, "agendamentoSelecionado");
        }
    }
}