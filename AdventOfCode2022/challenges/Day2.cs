using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.challenges
{
    internal class Day2
    {
        public void Run()
        {
            string? filePath = @"C:\Users\KM\source\repos\AdventOfCode2022\inputs\day2Input.txt";

            ProcessFile(filePath);



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        void ProcessFile(string filePath)
        {
            var totalPoints = 0;
            var totalPointsP2 = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var opponent = line[0];
                    var me = ConvertMeToOpponent(line[2]);

                    var won = CheckIfWon(me, opponent);
                    var shapePoints = GetShapePoints(me);
                    var roundPoints = won ? 6 : me == opponent ? 3 : 0;

                    totalPoints += roundPoints + shapePoints;

                    // Part 2
                    var correctShape = ChooseCorrectShape(opponent, line[2]);
                    var wonP2 = CheckIfWon(correctShape, opponent);
                    var shapePointsP2 = GetShapePoints(correctShape);
                    var roundPointsP2 = wonP2 ? 6 : correctShape == opponent ? 3 : 0;

                    totalPointsP2 += roundPointsP2 + shapePointsP2;
                }
            }



            Console.WriteLine($"total poitns: {totalPoints}");
            Console.WriteLine($"total poitns part2: {totalPointsP2}");
        }

        private char ChooseCorrectShape(char opponent, char instruction)
        {
            if (instruction == 'Y')
                return opponent;

            if (instruction == 'X')
                return opponent switch
                {
                    'A' => 'C',
                    'B' => 'A',
                    'C' => 'B'
                };

            if (instruction == 'Z')
                return opponent switch
                {
                    'C' => 'A',
                    'A' => 'B',
                    'B' => 'C'
                };

            throw new NotSupportedException();
        }

        private int GetShapePoints(char shape) =>
            shape switch
            {
                'A' => 1,
                'B' => 2,
                'C' => 3,
                _ => throw new NotImplementedException()
            };

        private bool CheckIfWon(char me, char opponent)
        {
            if ((me == 'A' && opponent == 'C') ||
                (me == 'B' && opponent == 'A') ||
                (me == 'C' && opponent == 'B'))
                return true;

            return false;
        }

        private char ConvertMeToOpponent(char me) =>
            me switch
            {
                'X' => 'A',
                'Y' => 'B',
                'Z' => 'C',
                _ => throw new NotImplementedException()
            };

    }
}
