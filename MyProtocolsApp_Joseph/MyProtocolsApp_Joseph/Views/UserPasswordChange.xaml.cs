using MyProtocolsApp_Joseph.Models;
using MyProtocolsApp_Joseph.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MyProtocolsApp_Joseph.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPasswordChange : ContentPage
    {
        UserViewModel viewModel;
        public UserPasswordChange()
        {
            InitializeComponent();
        }

        private async void BtnModify_Clicked(object sender, EventArgs e)
        {
            //if (ValidacionPassword())
            //{
            //    UserDTO BackUpLocalUser  = new UserDTO();
            //    BackUpLocalUser = GlobalObjects.MyLocalUser;

            //    try
            //    {
            //        GlobalObjects.MyLocalUser.Contrasenia = TxtPassword.Text.Trim();
            //        var answer = await DisplayAlert("???","Are  you sure to continue updating Password info?", "Yes", "No");
            //        if (answer)
            //        {
            //            bool R = await viewModel.UpdatePasswordUser(GlobalObjects.MyLocalUser);
            //            if (R)
            //            {
            //                await DisplayAlert(":)", "Password User Updated!", "OK");
            //                await Navigation.PopAsync();
            //            }
            //            else 
            //            {
            //                await DisplayAlert(":(", "Something went wrong...", "OK");
            //                await Navigation.PopAsync();
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        GlobalObjects.MyLocalUser = BackUpLocalUser;
            //        throw;
            //    }
            //}
        }

        private bool ValidacionPassword() 
        {
            bool R = false;

            if (TxtPassword.Text != null && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                R = true;
            }
            else 
            {
                if (TxtPassword.Text == null || string.IsNullOrEmpty(TxtPassword.Text.Trim()))
                {
                    DisplayAlert("Validation Failed","The Password es required","OK");
                    TxtPassword.Focus();
                    return false;
                }

            }

            return R;
        }

        private async  void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}