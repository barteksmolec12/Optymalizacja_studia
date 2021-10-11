using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
	class Combination
	{

		public List<PairOfPoints> GetAllCombinations(List<Point> convexPoints)
		{
            int jCnt = 1;
            List<PairOfPoints> pairs = new List<PairOfPoints>();
            for (int i = 0; i <= convexPoints.Count; i++)
            {
              
                for (int j = jCnt; j < convexPoints.Count;j++)
                {
      
                   
                    Point p_1 = new Point(convexPoints[i].x, convexPoints[i].y, convexPoints[i].indexNr); //punkt 1
                    Point p_2 = new Point(convexPoints[j].x, convexPoints[j].y, convexPoints[j].indexNr); //punkt 2
                    double valueForSqrt = (Math.Pow((convexPoints[j].x - convexPoints[i].x), 2)) + (Math.Pow((convexPoints[j].y - convexPoints[i].y), 2));
                    double distancePoints= Math.Sqrt(valueForSqrt); //dystans pomiędzy punktem 1 a 2
                    PairOfPoints pp = new PairOfPoints(p_1,p_2);
                    pp.distance = distancePoints;
                    pairs.Add(pp);

            
                }

                jCnt++;


            }


            return pairs.OrderByDescending(o => o.distance).ToList(); 
		}

        public List<Point> FindPointsWithTheBiggestDistance(List<PairOfPoints> ppList,int k)
		{
            List<Point> finalPoints = new List<Point>();

            for (int i = 0; i <= ppList.Count; i++)
            {
				try
				{
                    bool firstPointExistInList = finalPoints.Any(item => item.indexNr == ppList[i].p1.indexNr);
                    if (firstPointExistInList == false) finalPoints.Add(ppList[i].p1);
                }

				catch
				{
					Console.WriteLine();
				}
                bool secondPointExistInList = finalPoints.Any(item => item.indexNr == ppList[i].p2.indexNr);
                if (secondPointExistInList == false) finalPoints.Add(ppList[i].p2);

                
                if (finalPoints.Count == k) break;
            }


            return finalPoints.OrderBy(o => o.indexNr).ToList(); 
        }

		public double CalculateSumOfDistance(List<PairOfPoints> parisPoints, List<Point> finalPoints)
		{
            int jCnt = 1;
            double sumOfDistance = 0;
           
            for (int i = 0; i <= finalPoints.Count; i++)
            {

                for (int j = jCnt; j < finalPoints.Count; j++)
                {

                    PairOfPoints ppObj = parisPoints.Where(pp => pp.p1.indexNr == finalPoints[i].indexNr &&  pp.p2.indexNr == finalPoints[j].indexNr).FirstOrDefault();
                    sumOfDistance = sumOfDistance + ppObj.distance;
                }

                jCnt++;


            }
            return Math.Round(sumOfDistance, 2);
		}
	}
}
