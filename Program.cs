using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFiles
{
	class Program
	{
		static int theFileCount = 0;
		static void Main(string[] args)
		{
			string aPath = Console.ReadLine();
			Console.WriteLine(Scan(aPath, (f) => Console.WriteLine(f)));
			Console.ReadLine();
		}
		
		public static int Scan(string thePath, Action<string> theAction)
		{
			try
			{
				if (File.Exists(thePath))
				{
					if (FileCount == 0)
						FileCount = Directory.GetFiles(thePath).Length;
					foreach (string aDirectory in Directory.GetDirectories(thePath))
					{
						FileCount += Directory.GetFiles(aDirectory).Length;
						if (Directory.GetDirectories(aDirectory).Length > 0)
						{
							Scan(aDirectory, theAction);
						}
					}
				}
			}
			catch 
			{
			}	
			return FileCount;
		}
				
		public static int FileCount { get { return theFileCount; } set { theFileCount = value; } }
	}
}
