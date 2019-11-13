
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TshirtsApp.models;
using Xamarin.Forms;

namespace TshirtsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ShirtItemPage : ContentPage
    {
        public ShirtItemPage()
        {  

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var shirtItem = new ShirtItem();

            BindingContext = shirtItem;
        }

        private async void Save_ClickedAsync(object sender, EventArgs e)
        {
            var shirtItem = (ShirtItem)BindingContext;
            await App.Database.SaveItemAsync(shirtItem);
            await Navigation.PopAsync();
        }

        private async void Delete_ClickedAsync(object sender, EventArgs e)
        {
            var shirtItem = (ShirtItem)BindingContext;
            await App.Database.DeleteItemAsync(shirtItem);
            await Navigation.PopAsync();

        }

        private async void Cancel_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
    } 
