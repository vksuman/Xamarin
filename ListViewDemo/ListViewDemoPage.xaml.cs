using Xamarin.Forms;

namespace ListViewDemo
{
	public partial class ListViewDemoPage : ContentPage
	{
		public ListViewDemoPage()
		{
			InitializeComponent();
		}
		void OnClicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new IntractiveListView());
		}
	}
}
