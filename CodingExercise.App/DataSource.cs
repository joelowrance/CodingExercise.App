using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodingExercise.App
{
    public class DataSource
    {

        public int[,] AsArray()
        {
            var rawData = Data();
            int[,] result = new int[20, 20];

            for (int i = 0; i < 20; i++)
            {
                var lineData = rawData[i].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Debug.Assert(lineData.Length == 20, "Unexpected length on line " + i);

                for (int j = 0; j < 20; j++)
                {
                    result[i, j] = int.Parse(lineData[j]);
                }
                
            }

            return result;
        }


        private List<string> Data()
        {
            var rawData = new List<string>();
            rawData.Add("08 49 81 52 22 24 32 67 24 21 78 16 86 19 04 88 04 20 20 01");
            rawData.Add("02 49 49 70 31 47 98 26 55 36 17 39 56 80 52 36 42 69 73 70");
            rawData.Add("22 99 31 95 16 32 81 20 58 23 53 05 00 81 08 68 16 36 35 54");
            rawData.Add("97 40 73 23 71 60 28 68 05 09 28 42 48 68 83 87 73 41 29 71");
            rawData.Add("38 17 55 04 51 99 64 02 66 75 22 96 35 05 97 57 38 72 78 83");
            rawData.Add("15 81 79 60 67 03 23 62 73 00 75 35 71 94 35 62 25 30 31 51");
            rawData.Add("00 18 14 11 63 45 67 12 99 76 31 31 89 47 99 20 39 23 90 54");
            rawData.Add("40 57 29 42 89 02 10 20 26 44 67 47 07 69 16 72 11 88 01 69");
            rawData.Add("00 60 93 69 41 44 26 95 97 20 15 55 05 28 07 03 24 34 74 16");
            rawData.Add("75 87 71 24 92 75 38 63 17 45 94 58 44 73 97 46 94 62 31 92");
            rawData.Add("04 17 40 68 36 33 40 94 78 35 03 88 44 92 57 33 72 99 49 33");
            rawData.Add("05 40 67 56 54 53 67 39 78 14 80 24 37 13 32 67 18 69 71 48");
            rawData.Add("07 98 53 01 22 78 59 63 96 00 04 00 44 86 16 46 08 82 48 61");
            rawData.Add("78 43 88 32 40 36 54 08 83 61 62 17 60 52 26 55 46 67 86 43");
            rawData.Add("52 69 30 56 40 84 70 40 14 33 16 54 21 17 26 12 29 59 81 52");
            rawData.Add("12 48 03 71 28 20 66 91 88 97 14 24 58 77 79 32 32 85 16 01");
            rawData.Add("50 04 49 37 66 35 18 66 34 34 09 36 51 04 33 63 40 74 23 89");
            rawData.Add("77 56 13 02 33 17 38 49 89 31 53 29 54 89 27 93 62 04 57 19");
            rawData.Add("91 62 36 36 13 12 64 94 63 33 56 85 17 55 98 53 76 36 05 67");
            rawData.Add("08 00 65 91 80 50 70 21 72 95 92 57 58 40 66 69 36 16 54 48");

            return rawData;
        }

    }
}