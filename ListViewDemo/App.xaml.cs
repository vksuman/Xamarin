using Xamarin.Forms;

namespace ListViewDemo
{
	public partial class App : Application
	{
		static SitesDatabase database;
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new ListViewDemoPage());
		}

		public static SitesDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new SitesDatabase(DependencyService.Get<IMediaInterface>().GetLocalFilePath("DSAMobileDB.sqlite"));
				}
				return database;
			}
		}
		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
