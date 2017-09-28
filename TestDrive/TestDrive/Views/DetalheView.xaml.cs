using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}",  Veiculo.AR_CONDICIONADO);
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.MP3_PLAYER);
            }
        }

        bool temFreioABS;
        public bool TemFreioABS
        {
            get
            {
                return temFreioABS;
            }

            set
            {
                temFreioABS = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temArCondicionado;
        public bool TemArCondicionado
        {
            get
            {
                return temArCondicionado;
            }

            set
            {
                temArCondicionado = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temMP3Player;
        public bool TemMP3Player
        {
            get
            {
                return temMP3Player;
            }

            set
            {
                temMP3Player = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return string.Format("Valor total: R$ {0}", 
                    Veiculo.Preco 
                    + (TemFreioABS ? Veiculo.FREIO_ABS : 0)
                    + (TemArCondicionado ? Veiculo.AR_CONDICIONADO : 0)
                    + (TemMP3Player ? Veiculo.MP3_PLAYER : 0));
            }
        }

        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}