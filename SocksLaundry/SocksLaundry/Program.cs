using System;
using SocksLaundryLib;

namespace SocksLaundry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SocksLaundry");
            var classLib = new ClassLib();
            int noOfWashes = 2;
            int[] cleanPile = new int[] { 1, 2, 1, 1 };
            int[] dirtyPile = new int[] { 1, 4, 3, 2, 4 };
            int maximumNoOfSocks = classLib.GetMaximumPairOfSocks(noOfWashes, cleanPile, dirtyPile);
            Console.WriteLine("---------------- Maximum Number of Socks --------------- \n{0}", maximumNoOfSocks);
        }
    }
}
