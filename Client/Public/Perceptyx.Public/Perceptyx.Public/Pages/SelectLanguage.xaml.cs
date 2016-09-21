using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perceptyx.Public.Data;

using Xamarin.Forms;

namespace Perceptyx.Public.Pages
{
    public partial class SelectLaguage : ContentPage
    {
        public SelectLaguage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            languageList.ItemsSource = LanguageSelectionModel.GetLanguages();
            
        }

        async void OnNextButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SampleIntro());
        }
    }
}
 