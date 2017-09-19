using Xamarin.Forms;
using System.IO;
using DSA.ListViewDemo;
using ListViewDemo;
using System;
using Foundation;

[assembly: Dependency(typeof(MediaInterface))]
namespace DSA.ListViewDemo
{
	public class MediaInterface : IMediaInterface
	{
		public string GetLocalFilePath(string filename)
		{
			string docfolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docfolder, "..", "Library", "Databases");
			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}
			string dbPath = Path.Combine(libFolder, filename);
			CopyDatabaseIfNotExists(dbPath);
			return dbPath;
		}

		private static void CopyDatabaseIfNotExists(string dbPath)
		{
			if (!File.Exists(dbPath))
			{
				var existingDb = NSBundle.MainBundle.PathForResource("DSAMobileDB", "sqlite");
				File.Copy(existingDb, dbPath);
			}
		}

		public string GetImage(string name)
		{
			return name + ".png";
		}
	}
}
