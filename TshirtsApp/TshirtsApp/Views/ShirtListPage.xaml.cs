using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TshirtsApp.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShirtListPage : ContentPage
    {
        public List<ShirtItem> ShirtOrder { get; set; }

        public ShirtListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ShirtOrder = await App.Database.GetItemsAsync();
            BindingContext = this;
        }
        private async void OnItemAdded(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new ShirtItemPage());


            BindingContext = new ShirtItem();
        }

      
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ShirtItemPage
                {
                    BindingContext = e.SelectedItem as ShirtItem
                });
            }
        }
    } 
}
    
