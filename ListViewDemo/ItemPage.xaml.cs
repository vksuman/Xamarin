using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ListViewDemo
{
	public partial class ItemPage : ContentPage
	{
		public ItemPage(string item)
		{
			InitializeComponent();
			itemlabel.Text = item;
		}
	}
}
