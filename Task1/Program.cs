using System;
using System.Collections.Generic;


namespace Task1
{
	
	public class Program
	{
		static void Main(string[] args)
		{
			string pathTxt = AppDomain.CurrentDomain.BaseDirectory;
			int k = 4;
	
			try
			{
				pathTxt = pathTxt + args[0].Trim();
				k = Int16.Parse(args[1].Trim());
			}
			catch
			{
				Console.WriteLine("Parametry zostały wprowadzone nieprawidlowo ! ");
				Console.WriteLine("Prawidlowy format to np. Task1.exe punkty.txt 4");
				Console.ReadLine();
				return;
			
			}

			
		
		
			// ------------- odczytaj punkty z txt i załaduj do listy -----------------
			List<Point> points = TxtConverter.ReadAllPointsFromTxt(pathTxt);
			if ((k >= points.Count) || (k==1)) {
				Console.WriteLine("Parametr k jest nieprawidlowy ! ");
				Console.ReadLine();
				return;
			}
			//-----------------obliczenie odległosci dla wszystkich kombinacji ---------
			Combination comObj = new Combination();
			List<PairOfPoints> pPoints = comObj.GetAllCombinations(points);


			//---znalezeienie k-punktów, które mają największe odleglości pomiędzy sobą--
			List<Point> finalPoints = comObj.FindPointsWithTheBiggestDistance(pPoints, k);

			//------------- wyliczenie sumy odległości dla k-punktów -------------------
			double sumOFDistance = sumOFDistance = comObj.CalculateSumOfDistance(pPoints, finalPoints);

			//------------------------------- WYNIK -----------------------------------

			string listOfIndex = "";
			for (int i = 0; i < finalPoints.Count; i++)
			{
				listOfIndex = listOfIndex + (finalPoints[i].indexNr).ToString();
				if (i != finalPoints.Count - 1) listOfIndex = listOfIndex + ", ";
			}
		
			Console.WriteLine(sumOFDistance);
			Console.WriteLine(listOfIndex);
			Console.ReadLine();
			

		}
	}

}
