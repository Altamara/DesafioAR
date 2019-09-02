using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Desafio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscricaoPage : ContentPage
    {
        public InscricaoPage(Evento evento)
        {
            this.BindingContext = evento;

            InitializeComponent();
        }

        private async void BtnInscricao_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaEvento());
        }
    }
}