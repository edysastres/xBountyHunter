using System;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class agregarFugitivo : ContentPage
    {
        StackLayout verticalStackLayout;
        StackLayout horizontalStackLayout;
        Button bagregar;
        Button bcancelar;
        Entry enewname;

        public agregarFugitivo()
        {
            verticalStackLayout = new StackLayout { Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.FillAndExpand };
            horizontalStackLayout = new StackLayout { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center };

            enewname = new Entry { TextColor = Color.Black, BackgroundColor = Color.FromHex("#D3D3D3"), HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.Center };
            bagregar = new Button { Text = "AGREGAR", BorderColor = Color.Black, BorderWidth = 1 };
            bcancelar = new Button { Text = "CANCELAR", BorderColor = Color.Black, BorderWidth = 1 };

            verticalStackLayout.Children.Add(enewname);
            verticalStackLayout.Children.Add(horizontalStackLayout);

            horizontalStackLayout.Children.Add(bagregar);
            horizontalStackLayout.Children.Add(bcancelar);

            Content = verticalStackLayout;
        }
    }
}

