using System;
using System.Collections.Generic;

namespace RandomMap
{
    class Program
    {
        static int n, m, k;
        //----------------------------------------------

        static int[,] intitialArr;

        static int[,] foundCountryArr;

        static void Main(string[] args)
        {
            GetParams();
            intitialArr = InitArray(n, m, k);
            foundCountryArr = CopyArray(intitialArr);

            int countryCount = 0;

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (foundCountryArr[x, y] != -1)
                    {
                        ParseCountry(intitialArr[x, y], x, y);
                        countryCount = countryCount + 1;
                    }
                }
            }

            Console.WriteLine("Country count; " + countryCount);
        }

        private static void GetParams()
        {
            Console.WriteLine("Enter Value for N: ");
            var nn = Console.ReadLine();
            n = Convert.ToInt32(nn);

            Console.WriteLine("Enter Value for M: ");
            var mm = Console.ReadLine();
            m = Convert.ToInt32(mm);

            Console.WriteLine("Enter Value for K: ");
            var kk = Console.ReadLine();
            k = Convert.ToInt32(kk);

            intitialArr = new int[n,m];
        }

        private static int[,] InitArray(int n, int m, int maxVal)
        {
            for(var i = 0; i < n; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    intitialArr[i, j] = RandomizeMatrix(maxVal);
                }
            }

            return intitialArr;
        }

        private static int[,] CopyArray(int[,] a)
        {
            int[,] copy = (int[,])a.Clone();
   

            return copy;
        }

        private static void ParseCountry(int countryN, int x, int y)
        {
            CheckRIGHT(countryN, x, y);

            CheckLEFT(countryN, x, y);

            CheckUP(countryN, x, y);

            CheckDOWN(countryN, x, y);
        }

        private static void CheckUP(int countryN, int x, int y)
        {
            int newX = x;
            int newY = y - 1;

            if (CheckCell(newX, newY))
            {
                if (intitialArr[newX, newY] == countryN)
                {
                    foundCountryArr[x, y] = -1;
                    ParseCountry(countryN, newX, newY);
                }
            }
        }

        private static void CheckDOWN(int countryN, int x, int y)
        {
            int newX = x;
            int newY = y + 1;

            if (CheckCell(newX, newY))
            {
                if (intitialArr[newX, newY] == countryN)
                {
                    foundCountryArr[x, y] = -1;
                    ParseCountry(countryN, newX, newY);
                }
            }
        }

        private static void CheckRIGHT(int countryN, int x, int y)
        {
            int newX = x + 1;
            int newY = y;

            if (CheckCell(newX, newY))
            {
                if (intitialArr[newX, newY] == countryN)
                {
                    foundCountryArr[x, y] = -1;
                    ParseCountry(countryN, newX, newY);
                }
            }
        }

        private static void CheckLEFT(int countryN, int x, int y)
        {
            int newX = x - 1;
            int newY = y;

            if (CheckCell(newX, newY))
            {
                if (intitialArr[newX, newY] == countryN)
                {
                    foundCountryArr[x, y] = -1;
                    ParseCountry(countryN, newX, newY);
                }
            }
        }

        private static bool CheckCell(int x, int y)
        {
            if (x < n && x >= 0 && y < m && y >= 0)
            {
                return true;
            }
            return false;
        }

        private static int RandomizeMatrix(int k)
        {
            Random rnd = new Random();
            return rnd.Next(0, k + 1);
        }

        private static void Print()
        {

        }
    }
}
