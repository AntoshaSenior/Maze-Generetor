using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeneretorLabyrinth;


namespace ConsoleApp1
{
    internal class Labyrinth
    {
        static void Main(string[] args)
        {
            ClassLabyrinth Gen = new ClassLabyrinth(25,50);

            Gen.Start();
            Gen.NewIntOflabyrinth(); Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Gen.PrintLabyrinth();
        }
    }
}
