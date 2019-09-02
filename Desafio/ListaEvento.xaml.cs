using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desafio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEvento : ContentPage
    {
        static List<Evento> eventos;
        Boolean userAdmin = false;
        public Evento evento;


        public ListaEvento(bool _admin)
        {
            eventos = new List<Evento>();
            this.userAdmin = _admin;
            InitializeComponent();
            eventos.Add(new Evento { NomeEvento = "Cobol Day", LocalEvento = "Uberlândia", DataEvento = DateTime.Parse("01/01/2019", CultureInfo.InvariantCulture) });
            eventos.Add(new Evento { NomeEvento = "Material Design Day", LocalEvento = "Uberlândia", DataEvento = DateTime.Parse("01/01/2019", CultureInfo.InvariantCulture) });
            this.BindingContext = this;
            ListaEventos.ItemsSource = eventos;
        }

        public ListaEvento(Evento evento, bool _admin)
        {
            InitializeComponent();
            eventos.Add(evento);
            ListaEventos.ItemsSource = eventos;
            this.userAdmin = _admin;
            this.BindingContext = this;
        }


        public ListaEvento()
        {
            InitializeComponent();
            ListaEventos.ItemsSource = eventos;
            this.BindingContext = this;
        }



        private async void ListaEventos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var eventoTapped = (Evento)e.Item;
            await Navigation.PushAsync(new InscricaoPage(eventoTapped));
        }

        private void BtnNovo_Clicked(object sender, EventArgs e)
        {
            if (this.userAdmin == true)
            {
                Navigation.PushAsync(new CadastroEvento());
            }
            else
            {
                DisplayAlert("Alert", "Cadastro de novos eventos somente permitido para usuários com perfil de administrador!", "OK");
                return;
            }
        }


        private async void ListaEventos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var eventoSelect = (Evento)e.SelectedItem;
            await Navigation.PushAsync(new InscricaoPage(eventoSelect));
        }

    }
}