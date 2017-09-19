using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewDemo
{
	public partial class IntractiveListView : ContentPage
	{
		public IntractiveListView()
		{
			InitializeComponent();
		}

		void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
			Navigation.PushAsync(new ItemPage(((Instruments)e.SelectedItem).Name));
			//comment out if you want to keep selections
			ListView lst = (ListView)sender;
			lst.SelectedItem = null;
		}

		async void OnRefresh(object sender, EventArgs e)
		{
			var list = (ListView)sender;
			list.ItemsSource = await App.Database.GetInstrumentsAsync();
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}


		void OnMore(object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
		}

		void OnDelete(object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
		}
		async Task<ScrollView> MyGrid()
		{
			StackLayout stackall = new StackLayout() { Padding = new Thickness(5, 5, 5, 5), Orientation = StackOrientation.Horizontal };
			var instruments = await App.Database.GetInstrumentsAsync();
			foreach (var rec in instruments)
			{
				Grid grid = new Grid();
				Image image = new Image();
				image.BindingContext = rec;
				image.SetBinding(Image.SourceProperty, new Binding("Name", BindingMode.Default, new FileNameConverter(), null));
				grid.Children.Add(image);
				stackall.Children.Add(grid);
			}

			var scrollView = new ScrollView
			{
				Content = stackall,
				Orientation = ScrollOrientation.Horizontal
			};
			return scrollView;
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			listdemo.ItemsSource = await App.Database.GetInstrumentsAsync();
			listdemo.Footer = await MyGrid();
		}
	}
}
