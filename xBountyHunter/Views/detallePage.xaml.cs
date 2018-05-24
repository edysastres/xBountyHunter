using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xBountyHunter.Views
{
    public partial class detallePage : ContentPage
    {
        Models.mFugitivos Fugitivo = new Models.mFugitivos();

        public detallePage(Models.mFugitivos fugitivo)
        {
            InitializeComponent();
            Fugitivo = fugitivo;
            Title = Fugitivo.Name;
        }
    }
}
