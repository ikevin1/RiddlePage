﻿using RiddleMe.Models;
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
    public partial class RiddleListPage : ContentPage
    {
        public RiddleListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()

        {

            base.OnAppearing();



            listView.ItemsSource = await App.Database.GetItemsAsync();

        }



        async void OnItemAdded(object sender, EventArgs e)

        {

            await Navigation.PushAsync(new RiddleItemPage

            {

                BindingContext = new RiddleItem()

            });

        }



        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)

        {

            if (e.SelectedItem != null)

            {

                await Navigation.PushAsync(new RiddleItemPage

                {

                    BindingContext = e.SelectedItem as RiddleItem

                });

            }

        }
    }
}