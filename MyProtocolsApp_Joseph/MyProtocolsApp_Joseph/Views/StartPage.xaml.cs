﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProtocolsApp_Joseph.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
			LoadUserName();
		}

		private void LoadUserName() 
		{
			LblUserName.Text = GlobalObjects.MyLocalUser.Nombre.ToUpper();
		}

        private async void BtnUserManagment_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new UserManagementPage());
        }

        private async void BtnUserPasswordChange_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync (new UserPasswordChange());
        }

        private async void BtnProtocolManagment_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new ProtocolsListPage());
        }
    }
}