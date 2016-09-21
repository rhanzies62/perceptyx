using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Perceptyx.Public.Pages
{
    public partial class Greetings2 : ContentPage
    {
        public Greetings2()
        {
            InitializeComponent();
        }
        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void OnNextButtonClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new NavigationPage(new Introduction1());
            });
        }
    }
}
