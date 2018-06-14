using System;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public class acercaDePage : ContentPage
    {
        private Label ldevelopedby;
        private Label ldevelopername;
        private Label lyear;
        private Label ltrainigsr;
        private Label lratingvalor;
        private Slider srating;
        private StackLayout verticalStackLayout;

        //avanzado uso de Device.OpenUri
        private Label lmoreinfo;

        public acercaDePage()
        {
            ldevelopedby = new Label { Text = "Desarrollado por", FontSize = 15, HorizontalTextAlignment = TextAlignment.Center };
            ldevelopername = new Label { Text = "Eduardo Romero", FontSize = 12, HorizontalTextAlignment = TextAlignment.Center };
            lyear = new Label { Text = "D.W. Training S.C.", FontSize = 8, HorizontalTextAlignment = TextAlignment.Center };
            ltrainigsr = new Label { Text = "D.W. Training S.C.", FontSize = 12, HorizontalTextAlignment = TextAlignment.Center };
            lratingvalor = new Label { FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            srating = new Slider { Maximum = 5, Minimum = 0, Value = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
            //avanzado uso de Device.OpenUri
            lmoreinfo = new Label { Text = "Mas información", FontSize = 12, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.FromHex("#7A96EA") };
            verticalStackLayout = new StackLayout { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            Title = "Acerca de";
            if (Application.Current.Properties.ContainsKey("Rating"))
                srating.Value = (double)Application.Current.Properties["Rating"];
            lratingvalor.Text = srating.Value.ToString();
            verticalStackLayout.Children.Add(ldevelopedby);
            verticalStackLayout.Children.Add(ldevelopername);
            verticalStackLayout.Children.Add(lyear);
            verticalStackLayout.Children.Add(ltrainigsr);
            verticalStackLayout.Children.Add(srating);
            verticalStackLayout.Children.Add(lratingvalor);

            verticalStackLayout.Children.Add(lmoreinfo);
            var tapLbl = new TapGestureRecognizer();
            tapLbl.Tapped += (sender, args) =>
            {
                Device.OpenUri(new Uri("https://dwsoftware.mx/training.php"));
                lmoreinfo.TextColor = Color.Purple;
            };
            lmoreinfo.GestureRecognizers.Add(tapLbl);

            srating.ValueChanged += (sender, args) =>
            {
                double value = srating.Value;
                value = Math.Round(value * 2) / 2;
                lratingvalor.Text = value.ToString();
                Application.Current.Properties["Rating"] = value;
            };

            Content = verticalStackLayout;
        }
    }
}

