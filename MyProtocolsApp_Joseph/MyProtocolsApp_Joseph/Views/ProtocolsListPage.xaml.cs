using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProtocolsApp_Joseph.ViewModels;

namespace MyProtocolsApp_Joseph.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProtocolsListPage : ContentPage
    {
        ProtocolViewModel protocolViewModel;
        public ProtocolsListPage()
        {
            InitializeComponent();
            BindingContext = protocolViewModel = new ProtocolViewModel();
            loadProtocolList();
        }

        private async void loadProtocolList() 
        {
            LvList.ItemsSource = await protocolViewModel.GetProtocolsAsync(GlobalObjects.MyLocalUser.IDUsuario);

        }

    }
}