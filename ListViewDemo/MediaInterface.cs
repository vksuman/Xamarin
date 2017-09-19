using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListViewDemo
{
	public interface IMediaInterface
	{
		string GetLocalFilePath(string filename);
		string GetImage(string name);
	}
}
