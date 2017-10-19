using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewsModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista
        {
            get
            {
                return lista;
            }
            private set
            {
                lista = value;
                OnPropertyChanged();
            }
        }

        private Agendamento agendamentoSelecionado;

        public Agendamento AgendamentoSelecionado
        {
            get { return agendamentoSelecionado; }
            set
            {
                MessagingCenter.Send<Agendamento>(agendamentoSelecionado, "AgendamentoSelecionado");
                agendamentoSelecionado = value;
            }
        }


        public AgendamentosUsuarioViewModel()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                var listaDB = dao.Lista;

                var query = listaDB.OrderBy(l => l.DataAgendamento).ThenBy(l => l.HoraAgendamento);

                this.Lista.Clear();

                foreach (var itemDB in query)
                    this.Lista.Add(itemDB);
            }
        }
    }
}
