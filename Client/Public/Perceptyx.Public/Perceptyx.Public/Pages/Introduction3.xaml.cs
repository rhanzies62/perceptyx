using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Perceptyx.Public.Pages
{
    public partial class Introduction3 : ContentPage
    {
        public Introduction3()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        async void OnReturnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnBeginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Instruction());
        }
    }
}
