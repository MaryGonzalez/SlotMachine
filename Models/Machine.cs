using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AuthenticatedSlotMachineMVC.Models
{
    public class Machine
    {

        [Required(ErrorMessage = "Please enter a bet")]
        [Range(0, 10000000, ErrorMessage = "Place a bet greater than zero.")]
        public double? Deposit { get; set; }

        public string symbol1 { get; set; }
        public string symbol2 { get; set; }
        public string symbol3 { get; set; }


        //double runningTotal = 0;
        double depositVal = 0;

        public void Display()
        {
            Random rand = new Random();

            symbol1 = getImage(rand.Next(0, 5) + 1);
            symbol2 = getImage(rand.Next(0, 5) + 1);
            symbol3 = getImage(rand.Next(0, 5) + 1);

        }


        private string getImage(int symbol)
        {
            string image;

            if (symbol == 1)
                image = "1_Number7.bmp";
            else if (symbol == 2)
                image = "2_Banana.bmp";
            else if (symbol == 3)
                image = "3_Cherry.bmp";
            else if (symbol == 4)
                image = "4_Grapes.bmp";
            else if (symbol == 5)
                image = "5_Orange.bmp";
            else
                image = "6_Watermelon.bmp";

            return image;
        }
           


        public double? CheckWinner()
        {
            double prize = 0;
            double totalWin = 0;

            
                if (symbol1 == symbol2 && symbol2 == symbol3)
                {
                    prize = Deposit.Value * 5;
                }
                else if (symbol1 == symbol2 || symbol1 == symbol3 || symbol2 == symbol3)
                {
                    prize = Deposit.Value * 2;
                }
                else
                {
                    prize = Deposit.Value * 1;
                }
                        
            return totalWin += prize;
           

        }


        public double? TotalInserted()
        {
           double runningTotal = 0;
         
            if (Deposit.HasValue)
                depositVal = Deposit.Value;

            double totalInserted = depositVal + runningTotal;

            return totalInserted;
        }

    }
}