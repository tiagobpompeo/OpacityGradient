using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Opacity
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

           
        }

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {
            ScrollViewCustomRenderer scrollView = sender as ScrollViewCustomRenderer;
            double scrollingSpace = scrollView.ContentSize.Height - scrollView.Height;
            MyLabel.Opacity = 1 - e.ScrollY / scrollingSpace;
        }
    }
}
