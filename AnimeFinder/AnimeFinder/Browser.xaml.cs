using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimeFinder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Browser : ContentPage
    {
        public Browser( int u)
        {
            InitializeComponent();
            getdata(u);
           
        }


        public async void getdata(int malid)
        { 
            try
            {
                HttpClient httpClient = new HttpClient();
                var url = "https://api.jikan.moe/v3/anime/" + malid.ToString() + "/characters_staff";

                var contents = await httpClient.GetStringAsync(url);
                var datas = JsonConvert.DeserializeObject<Applicationss>(contents);
                clist.ItemsSource = datas.characters;
                
                                     
            }

            catch(Exception s)
            {
                await DisplayAlert("Info", s.Message.ToString(), "Ok");
                
                
            }
           
      

        }

        private void clist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var si = (Characters)clist.SelectedItem;

        }
    }
}