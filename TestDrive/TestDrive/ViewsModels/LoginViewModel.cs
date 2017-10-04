using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewsModels
{
    public class LoginViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
            });
        }
    }
}
