﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMWebClient.Core
{
   public class Helpers
    {

        public static Random diceRoll = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Rolls dice for comabt, spells, skills etc
        /// </summary>
        /// <param name="number">Number of dice to roll</param>
        /// <param name="minSize">Min size of dice</param>
        /// <param name="maxSize">Max Size of Dice</param>
        /// <returns></returns>
        public int dice(int number, int minSize, int maxSize)
        {
            int sum = 0;

            try
            {
                //Hack - something in update is passing in 0 for max size
                if (minSize == maxSize)
                {
                    maxSize += 1;
                }

                if (maxSize == 0)
                {
                    maxSize = minSize + 1;
                }
                //Hack

                for (int i = 0; i < number; i++)
                {
                    sum += diceRoll.Next(minSize, maxSize);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return sum;

        }

        
        /// <summary>
        /// Returns a random string.
        /// </summary>
        /// <param name="possible"></param>
        /// <returns></returns>
        public static String RandomString(params String[] possible)
        {
            return possible[diceRoll.Next(0, possible.Count())];
        } 
    }
}
