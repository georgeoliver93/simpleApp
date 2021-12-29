using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace simpleApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class simpleApp : ContentPage
    {
        RestService _restService;
        public simpleApp()
        {
            InitializeComponent();
            _restService = new RestService();
        }
        public void addAllInput(object sender, EventArgs e)
        {
            // Total.Text = Fnumber.Text + Snumber.Text;
           Total.Text = (Convert.ToInt16(Fnumber.Text) + Convert.ToInt16(Snumber.Text)).ToString();
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            List<Repository> repositories = await _restService.GetRepositoriesAsync(Constants.GitHubReposEndpoint);
            collectionView.ItemsSource = repositories;
        }
    }
}