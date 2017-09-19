using System;
using System.Globalization;
using Xamarin.Forms;

namespace ListViewDemo
{
public class FileNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string name = (string)value;
			return DependencyService.Get<IMediaInterface>().GetImage(name);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
