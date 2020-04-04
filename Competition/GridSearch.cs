using System;
using System.Collections.Generic;

namespace Competition
{
    class GridSearch
    {
        public static List<string> input11 = new List<string>(){
            "9505",
            "3845",
            "3530"
        };
        
        private static List<string> input12 = new List<string>()
        {
            "7283455864",
            "6731158619",
            "8988242643",
            "3830589324",
            "2229505813",
            "5633845374",
            "6473530293",
            "7053106601",
            "0834282956",
            "4607924137"
        };


        public static void Run(string[] args)
        {
            var result = gridSearch(input11.ToArray(), input12.ToArray());
        }

        // Complete the gridSearch function below.
        static string gridSearch(string[] G, string[] P) {
            for(var i = 0; i < P.Length; i++){
                for(var j = 0; j < P.Length; j++){
                    if(G[j / G[0].Length][j % G.Length] != P[i / P[0].Length][i % P.Length]){
                        break;
                    }
                    else{
                        if(j / G[0].Length == G.Length && j % G.Length == 0){
                            return "YES";
                        }
                    }
                }
            }
            return "NO";
        }

    }
}
