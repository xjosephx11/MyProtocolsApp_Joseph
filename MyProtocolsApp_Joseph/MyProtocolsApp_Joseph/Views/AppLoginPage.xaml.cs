using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyProtocolsApp_Joseph.ViewModels;
using Acr.UserDialogs;

namespace MyProtocolsApp_Joseph.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLoginPage : ContentPage
    {
        //se realiza el anclaje entre esta vista y el vm que le da la
        //funcionalidad

        UserViewModel viewModel;
        public AppLoginPage()
        {
            InitializeComponent();

            //esto vicula la vista con el vm y ademas crea la instancia del objeto
            this.BindingContext = viewModel = new UserViewModel();
        }

        private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwShowPassword.IsToggled)
            {
                TxtPassword.IsPassword = false;
            }
            else 
            {
                TxtPassword.IsPassword = true;
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //validacion del ingreso del usuario a la app

            if (TxtUserName.Text != null && !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
                TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                //si hay info en los cuadros de texto de email y password se procede
                try
                {
                    //hacemos una animacion de espera
                    UserDialogs.Instance.ShowLoading("Checking User Access...");
                    await Task.Delay(2000);

                    string username = TxtUserName.Text.Trim();
                    string password = TxtPassword.Text.Trim();

                    bool R = await viewModel.UserAccessValidation(username, password);
                    if (R)
                    {
                        //si la validacion es correcta se permite el ingreso al sistema
                        //igual que en progra 5 vamos a tener un usuario global
                        //todo: crear el objheto se usuario global

                        await Navigation.PushAsync(new StartPage());
                        return;
                    }
                    else
                    {
                        //algo salio mal
                        await DisplayAlert("User Access Denied", "Username or Password are incorrect", "ok");
                        return;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {
                    //apagamos la animacion de carga
                    UserDialogs.Instance.HideLoading();
                }
            }
            else 
            {
                //si no digito datos indicarle al usuario el requerimiento

                await DisplayAlert("Data required","Username and Password are required","ok");
            }
        }

        private async void BtnSingUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserSingUpPage());
        }
    }
}