using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
	 static class TxtConverter
	{
		public static List<Point> ReadAllPointsFromTxt(string pathToTxt)
		{
			List<Point> points = new List<Point>();
			string[] lines = File.ReadAllLines(pathToTxt);

			foreach (var line in lines)
			{
				string[] val = line.Split(',');
				if (val.Length > 1)
				{
					int index = Array.IndexOf(lines, line);
					Point p = new Point(Int16.Parse(val[0].Trim()), Int16.Parse(val[1].Trim()), index);
					points.Add(p);
				}

			}

			return points;
		}
	}
}
