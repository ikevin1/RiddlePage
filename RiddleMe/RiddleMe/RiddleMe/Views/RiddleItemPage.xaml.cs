using RiddleMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiddleMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RiddleItemPage : ContentPage
    {
        public RiddleItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)

        {

            var riddleItem = (RiddleItem)BindingContext;

            await App.Database.SaveItemAsync(riddleItem);

            await Navigation.PopAsync();

        }



        async void OnDeleteClicked(object sender, EventArgs e)

        {

            var riddleItem = (RiddleItem)BindingContext;

            await App.Database.DeleteItemAsync(riddleItem);

            await Navigation.PopAsync();

        }



        async void OnCancelClicked(object sender, EventArgs e)

        {

            await Navigation.PopAsync();

        }
    }
}