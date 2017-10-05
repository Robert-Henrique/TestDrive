using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewsModels
{
    public class MasterViewModel
    {

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }
        
        private bool editando = false;
        public bool Editando
        {
            get { return editando = false; }
            private set { editando = value; }
        }

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarPerfilCommand { get; private set; }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;

            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            SalvarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });
        }
    }
}
