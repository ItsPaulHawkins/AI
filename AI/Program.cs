using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alec: Hello! I'm Alec, your personal assistant.");
            string input = Console.ReadLine();
            string[] splitInput = input.Split(' ');
            bool found = false;
            int place = 0;
            while (found == false)
            {
                if(splitInput[place] == "images" || splitInput[place] == "image" || splitInput[place] == "Image" || splitInput[place] == "Images" || splitInput[place] == "picture" || splitInput[place] == "pictures" || splitInput[place] == "Pictures" || splitInput[place] == "picture")
                {
                    found = true;
                    string image = splitInput[place + 2];
                    findImage(image);
                }else
                {
                    place++;
                }
            }


        }
        public static void Sleep(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
        public static string findImage(string image)
        {
            Console.WriteLine(image);
            Console.ReadLine();

            return image;
        }
    }
}
