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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            this.IsBusy = false;

            BtnLogin.Clicked += BtnLogin_Clicked;
        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string matricula = logMatricula.Text.Trim();
            string email = logEmail.Text.Trim();
            string senha = logSenha.Text.Trim();

            /*usuario Admin 
             * matricula = 1000
             * senha = 1000admin
             * email = admin@everis.com
             * 
             */

            var admin = false;

            if (matricula == "1000" &&  email == "admin@everis.com" && senha == "1000admin")
            {
                admin = true;
            }
            else
            {
                admin = false;
            }

            this.IsBusy = true;
            await Atraso(2000);
            Application.Current.MainPage = new NavigationPage(new ListaEvento(admin));

        }

        async Task Atraso(int valor)
        {
            await Task.Delay(valor);
        }

    }

 
}