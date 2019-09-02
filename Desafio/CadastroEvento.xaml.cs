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
    public partial class CadastroEvento : ContentPage
    {

        Evento Evento = new Evento();
        
        public CadastroEvento()
        {
            this.BindingContext = this;
            InitializeComponent();
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaEvento(true));
        }

        private async void BtnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (eventName != null && eventLocal != null && eventData != null)
            {

                string nome = eventName.Text.Trim();
                string local = eventLocal.Text.Trim();
                string data = eventData.Text.Trim();
                string hora = eventHorario.Text.Trim();

                Evento.NomeEvento = nome;
                Evento.LocalEvento = local;
                Evento.DataEvento = DateTime.ParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                await Navigation.PushAsync(new ListaEvento(Evento, true));

            } else
            {
                return;
            }
               
           
        }
    }
}