using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksLaundryLib
{
    public class ClassLib
    {

        //Do not delete or edit this method, you can only modify the block
        public int GetMaximumPairOfSocks(int noOfWashes, int[] cleanPile, int[] dirtyPile)
        {
            //You can edit from here down
            var maximumPairsOfSocks = 0;
            var unMatchedSocksInCleanPile = GetUnmatchedSocks(cleanPile);
            var pairsOfMatchingSocksInCleanPile = (cleanPile.Length - unMatchedSocksInCleanPile.Length) / 2;
            var matchingSocksFromDirtyPile = GetMatchingPairOfSocksFromDirtyPile(unMatchedSocksInCleanPile, dirtyPile);
            var pairsFromDirtyPile = GetMatchingPairs(dirtyPile);

            if (pairsOfMatchingSocksInCleanPile != 0)
            {
                maximumPairsOfSocks += pairsOfMatchingSocksInCleanPile;
            }
            
            if(matchingSocksFromDirtyPile.Length <= noOfWashes)
            {
                maximumPairsOfSocks += matchingSocksFromDirtyPile.Length;
            }

            if(dirtyPile.Length == noOfWashes)
            {
                maximumPairsOfSocks += pairsFromDirtyPile;
            }

            return maximumPairsOfSocks;
        }


        private int GetMatchingPairs(int[] sockPile)
        {
            var socksPairs = new Dictionary<int, int>();
            int pairs = 0;

            for (int i = 0; i < sockPile.Length; i++)
            {
                int randomSock = sockPile[i];
                if (socksPairs.ContainsKey(randomSock))
                {
                    socksPairs[randomSock]++;

                    if (socksPairs[randomSock] == 2)
                    {
                        pairs++;
                        socksPairs[randomSock] = 0;
                    }

                }
                else
                {
                    socksPairs[randomSock] = 1;
                }
            }
            return pairs;
        }

        private int[] GetUnmatchedSocks(int[] sockPile)
        {
            var socksPairs = new Dictionary<int, int>();
            int pairs = 0;

            for (int i = 0; i < sockPile.Length; i++)
            {
                int randomSock = sockPile[i];
                if (socksPairs.ContainsKey(randomSock))
                {
                    socksPairs[randomSock]++;
                    int numIndex = Array.IndexOf(sockPile, randomSock);
                    sockPile = sockPile.Where((val, idx) => idx != numIndex).ToArray();

                    if (socksPairs[randomSock] == 2)
                    {
                        pairs++;
                        socksPairs[randomSock] = 0; 
                        numIndex = Array.IndexOf(sockPile, randomSock);
                        sockPile = sockPile.Where((val, idx) => idx != numIndex).ToArray();
                    }

                }
                else
                {
                    socksPairs[randomSock] = 1;
                }
            }
            return sockPile;
        }

        private int[] GetMatchingPairOfSocksFromDirtyPile(int[] unmatchedCleanPile, int[] dirtyPile)
        {
            var listOfDirtyMatchedSock = new List<int>();
            for (int i = 0; i < unmatchedCleanPile.Length; i++)
            {
                var randomLeftHandSock = unmatchedCleanPile[i];

                for (int j = 0; j < dirtyPile.Length; j++)
                {
                    var randomRightHandSock = dirtyPile[j];

                    if (randomLeftHandSock == randomRightHandSock)
                    {
                        listOfDirtyMatchedSock.Add(randomRightHandSock);
                    }
                }
            }

            return listOfDirtyMatchedSock.ToArray();
        }
    }
}
