using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Perceptyx.Public.Pages
{
    public partial class Introduction2 : ContentPage
    {
        public Introduction2()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnNextButtonClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Introduction3());
        }
    }
}
