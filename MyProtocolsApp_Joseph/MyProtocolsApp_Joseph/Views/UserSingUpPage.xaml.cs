using MyProtocolsApp_Joseph.ViewModels;
using MyProtocolsApp_Joseph.Models;
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
    public partial class UserSingUpPage : ContentPage
    {
        UserViewModel viewModel;

        public UserSingUpPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadUserRolesAsync();
           
        }
        //fujcion que permite  la carga de los roles de usuario
        private async void LoadUserRolesAsync() 
        {
            PkrUserRole.ItemsSource = await viewModel.GerUserRolesAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker
            UserRole selectedUserRole = PkrUserRole.SelectedItem as UserRole;

            bool R = await viewModel.AddUserAsync(TxtEmail.Text.Trim(),
                                                  TxtPassword.Text.Trim(),
                                                  TxtEmail.Text.Trim(),
                                                  TxtBackUpEmail.Text.Trim(),
                                                  TxtPhoneNumber.Text.Trim(),
                                                  TxtAddress.Text.Trim(),
                                                  selectedUserRole.UserRoleId);
            if (R)
            {
                await DisplayAlert(":)", "User created ok", "Linda perro!!");
                await Navigation.PopAsync();
            }
            else 
            {
                await DisplayAlert(":(", "Something went wrong...", "fea perro!!");
            }
        }
    }
}