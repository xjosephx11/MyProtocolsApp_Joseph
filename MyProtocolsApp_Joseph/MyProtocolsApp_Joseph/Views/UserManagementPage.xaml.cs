using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProtocolsApp_Joseph.ViewModels;
using MyProtocolsApp_Joseph.Models;

namespace MyProtocolsApp_Joseph.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserManagementPage : ContentPage
    {
        UserViewModel viewModel;

        public UserManagementPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            TxtID.Text = GlobalObjects.MyLocalUser.IDUsuario.ToString();
            TxtEmail.Text = GlobalObjects.MyLocalUser.Correo;
            TxtName.Text = GlobalObjects.MyLocalUser.Nombre;
            TxtPhoneNumber.Text = GlobalObjects.MyLocalUser.Telefono;
            TxtBackUpEmail.Text = GlobalObjects.MyLocalUser.CorreoRespaldo;
            TxtAddress.Text = GlobalObjects.MyLocalUser.Direccion;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            //primero hacemos validacion de campos requeridos
            if (ValidateFields())
            {
                //sacar un respaldo del usuario global tal y como esta en este momento
                //por si algo  sale mal en el proceso de update, reversar los cambios
                UserDTO BackUpLocalUser = new UserDTO();    
                BackUpLocalUser = GlobalObjects.MyLocalUser;

                try
                {
                    GlobalObjects.MyLocalUser.Nombre = TxtName.Text.Trim();
                    GlobalObjects.MyLocalUser.CorreoRespaldo = TxtBackUpEmail.Text.Trim();
                    GlobalObjects.MyLocalUser.Telefono = TxtPhoneNumber.Text.Trim();
                    GlobalObjects.MyLocalUser.Direccion= TxtAddress.Text.Trim();

                    var answer = await DisplayAlert("???","Are you sure to continue updating user info?","Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);
                        if (R)
                        {
                            await DisplayAlert(":)", "User Updated!!", "ok");
                            await Navigation.PopAsync();
                        }
                        else 
                        {
                            await DisplayAlert(":(", "Something went wrong...", "ok");
                            await Navigation.PopAsync();
                        }
                    }
                }
                catch (Exception)
                {
                    //si  algosale mal reversamos los cambios
                    GlobalObjects.MyLocalUser = BackUpLocalUser;
                    throw;
                }
                finally 
                { 

                } 
            }
        }
        private bool ValidateFields() 
        {
            bool R = false;

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                //en este caso estan todos los datos requeridos
                R = true;
            }
            else 
            {
                //si falta algun dato obligatorio
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The name is required","ok");
                    TxtName.Focus();
                    return false;
                }
                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The BackUp-Email is required", "ok");
                    TxtBackUpEmail.Focus();
                    return false;
                }
                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validation Failed", "The Number Phone is required", "ok");
                    TxtPhoneNumber.Focus();
                    return false;
                }

            }

            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}