using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public AgendamentosUsuarioViewModel()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                var listaDB = dao.Lista;
                this.Lista.Clear();

                foreach (var itemDB in listaDB)
                    this.Lista.Add(itemDB);
            }
        }
    }
}
