using RiddleMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RiddleMe.Views
{
    public class RiddleListPageCS : ContentPage
    {
        ListView listView;

        public RiddleListPageCS()

        {

            Title = "Riddle";



            var toolbarItem = new ToolbarItem

            {

                Text = "+",

                IconImageSource = Device.RuntimePlatform == Device.iOS ? null : "Cross.jpg"

            };

            toolbarItem.Clicked += async (sender, e) =>

            {

                await Navigation.PushAsync(new RiddleItemPageCS

                {

                    BindingContext = new RiddleItem()

                });

            };

            ToolbarItems.Add(toolbarItem);



            listView = new ListView

            {

                Margin = new Thickness(20),

                ItemTemplate = new DataTemplate(() =>

                {

                    var label = new Label

                    {

                        VerticalTextAlignment = TextAlignment.Center,

                        HorizontalOptions = LayoutOptions.StartAndExpand

                    };

                    label.SetBinding(Label.TextProperty, "Name");



                    var tick = new Image

                    {

                        Source = ImageSource.FromFile("Check.jpg"),

                        HorizontalOptions = LayoutOptions.End

                    };

                    tick.SetBinding(VisualElement.IsVisibleProperty, "Done");



                    var stackLayout = new StackLayout

                    {

                        Margin = new Thickness(20, 0, 0, 0),

                        Orientation = StackOrientation.Horizontal,

                        HorizontalOptions = LayoutOptions.FillAndExpand,

                        Children = { label, tick }

                    };



                    return new ViewCell { View = stackLayout };

                })

            };

            listView.ItemSelected += async (sender, e) =>

            {



                if (e.SelectedItem != null)

                {

                    await Navigation.PushAsync(new RiddleItemPageCS

                    {

                        BindingContext = e.SelectedItem as RiddleItem

                    });

                }

            };



            Content = listView;

        }



        protected override async void OnAppearing()

        {

            base.OnAppearing();



            listView.ItemsSource = await App.Database.GetItemsAsync();

        }
    }
}
