using SQLite;
namespace ListViewDemo
{
	public class Instruments
	{
		[PrimaryKey]
		public int ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
	}
}
