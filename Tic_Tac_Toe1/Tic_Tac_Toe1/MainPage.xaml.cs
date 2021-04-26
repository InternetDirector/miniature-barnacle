using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tic_Tac_Toe1
{
    public partial class MainPage : ContentPage
    {
        public int x = 0;
        public byte n = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("О разработчике", "Шишкин Д.Ю, либо же", "ОK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Game());
        }
    }
}
