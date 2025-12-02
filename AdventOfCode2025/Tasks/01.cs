using AdventOfCode2025.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Tasks
{
    public class _01
    {
        private int currentPosition = 50;
        private int numberOfZeros = 0;
        private int numberOfLandedZeros = 0;

        public _01()
        {
            Action handler = RunProcess;
            MenuHelper.AddMenu(nameof(_01), handler);
        }

        public void RunProcess()
        {
            var inputString = InputReader.ReadMultiple();
            foreach (var item in inputString)
            {
                ProcessInput(item);
            }
            Console.WriteLine($"Result: \n\tTotal zeroes: {numberOfZeros} \n\tLanded zeroes: {numberOfLandedZeros}");
            return;
        }

        private void ProcessInput(string input)
        {
            if (input == null) return;
            char direction = input[0];
            int magnitude = int.MinValue;
            magnitude = int.Parse(input[1..input.Length]);
            if (magnitude == int.MinValue)
            {
                Console.WriteLine("magnitude error: magnitude = " + magnitude);
                return;
            }
            if (direction == 'R')
            {
                Turn(Right(magnitude));
                return;
            }
            Turn(Left(magnitude));
            return;
        }

        private int Right(int magnitude)
        {
            if (magnitude == 0) { return magnitude; }
            numberOfZeros += (int)(magnitude / 100);
            return magnitude %= 100;
        }

        private int Left(int magnitude)
        {
            if (magnitude == 0) { return magnitude; }
            numberOfZeros += (int)(magnitude / 100);
            return -(magnitude %= 100);
        }
        private void Turn(int magnitude)
        {
            if (magnitude != 0)
            {
                if (currentPosition + magnitude >= 100 || (currentPosition > 0 && currentPosition + magnitude <= 0))
                {
                    numberOfZeros++;
                }
                currentPosition += (100 + magnitude);
            }
            currentPosition %= 100;
            if (currentPosition == 0)
                numberOfLandedZeros++;
            Console.WriteLine("Current position: " + currentPosition + ".\tCurrent number of zeros: " + numberOfZeros);
        }
    }
}
