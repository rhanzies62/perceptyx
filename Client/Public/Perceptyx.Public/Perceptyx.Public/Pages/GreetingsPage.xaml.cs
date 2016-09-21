using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Perceptyx.Public.Pages
{
    public partial class GreetingsPage : ContentPage
    {
        TapGestureRecognizer greetingTapped;
        public GreetingsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            greetingTapped = new TapGestureRecognizer();
            
            greeting.GestureRecognizers.Add(greetingTapped);
            greetingTapped.Tapped += (s, e) =>
            {
                Navigation.PushModalAsync(new Greetings2());
            };
        }

    }
}
