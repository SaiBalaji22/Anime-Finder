using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace AnimeFinder
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {  
        
        private HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
        }

        private async  void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
             try
            {
                ai.IsVisible = true;
                ai.IsRunning = true;
                string s = sbar.Text;
                string url = "https://api.jikan.moe/v3/search/anime?q="+s+"&limit=50";
               var content = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Applications>(content);
                animelist.ItemsSource = data.results;
                sbar.Text = "";
                ai.IsRunning = false;
                ai.IsVisible = false;
            }
            catch(Exception w)
            {
                await DisplayAlert("Info", w.Message.ToString(), "Ok");
            }
        }

        private async void animelist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var si = (Results)animelist.SelectedItem;
            
           await Navigation.PushAsync(new Browser(si.mal_id));
         
        }
    }
}
