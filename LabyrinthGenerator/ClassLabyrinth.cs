using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneretorLabyrinth
{
    public class ClassLabyrinth
    {
        public char[,] labyrinth;
        int Gorizontal, Vertical,QuantityMove = 0;
        int[,] RandomMove;
        public ClassLabyrinth(int Gorizontal,int Vertical)
        {
            this.Gorizontal = Gorizontal;
            this.Vertical = Vertical;
            RandomMove = new int[Gorizontal * Vertical,4];
        }

        //Метод используется для началы работы всего класса для начала генерации необходимо только создать 
        //экземпляр класса и вызвать один метод и передать ему параметры высоты и ширины масива.

        // Создания масива из стен
        public void Start()
        {
           labyrinth = new char[Gorizontal, Vertical];
            for (int i = 0;i < Gorizontal; i++)
                for (int j = 0;j < Vertical; j++) { labyrinth[i, j] = '#'; }
            StartingPoint(labyrinth);
        }

        //выбор точки старта генерации лабиринта
        private void StartingPoint(char[,] labyrinth)
        {
            Random rnd = new Random();
            int StartGorizontal = rnd.Next(1,labyrinth.GetLength(0) - 1);
            int StartVertical = rnd.Next(1,labyrinth.GetLength (1) - 1);
            labyrinth[StartGorizontal, StartVertical] = '+';
            PrintLabyrinth();
            FindLegalMove();
        }

        //Метод для поиска возможных ходов
        private void FindLegalMove()
        {
            int FirstRndMoveX = 0;
            int FirstRndMoveY = 0;
            int SecondRndMoveX = 0;
            int SecondRndMoveY = 0;
            for (int i = 0; i < Gorizontal; i++)
            {
                for(int j = 0; j < Vertical; j++)
                {
                    if (labyrinth[i,j] == '+')
                    {
                        //Условие для поиска индексов для движения пути лабиринта вниз
                        if(i + 1 < labyrinth.GetLength(0) - 1 & i + 2 < labyrinth.GetLength(0) - 1)
                        {
                            if (labyrinth[i + 1, j] == '#' & labyrinth[i + 2, j] == '#')
                            {
                                RandomMove[FirstRndMoveX, 0] = j; FirstRndMoveX++;
                                RandomMove[FirstRndMoveY, 1] = i + 1; FirstRndMoveY++;
                                RandomMove[SecondRndMoveX, 2] = j; SecondRndMoveX++;
                                RandomMove[SecondRndMoveY, 3] = i + 2; SecondRndMoveY++;
                                QuantityMove++;
                            }
                        }
                        //Условие для поиска индексов для движения пути лабиринта вверх
                        if (i - 1 > 0 & i - 2 > 0)
                        {
                            if (labyrinth[i - 1, j] == '#' & labyrinth[i - 2, j] == '#')
                            {
                                RandomMove[FirstRndMoveX, 0] = j; FirstRndMoveX++;
                                RandomMove[FirstRndMoveY, 1] = i - 1; FirstRndMoveY++;
                                RandomMove[SecondRndMoveX, 2] = j; SecondRndMoveX++;
                                RandomMove[SecondRndMoveY, 3] = i - 2; SecondRndMoveY++;
                                QuantityMove++;
                            }
                        }
                        //Условие для поиска индексов для движения пути лабиринта влево
                        if (j - 1 > 0 & j - 2 > 0)
                        {
                            if (labyrinth[i, j - 1] == '#' & labyrinth[i, j - 2] == '#')
                            {
                                RandomMove[FirstRndMoveX, 0] = j - 1; FirstRndMoveX++;
                                RandomMove[FirstRndMoveY, 1] = i; FirstRndMoveY++;
                                RandomMove[SecondRndMoveX, 2] = j - 2; SecondRndMoveX++;
                                RandomMove[SecondRndMoveY, 3] = i; SecondRndMoveY++;
                                QuantityMove++;
                            }
                        }
                        //Условие для поиска индексов для движения пути лабиринта вправо
                        if (j + 1 < labyrinth.GetLength(1) - 1 & j + 2 < labyrinth.GetLength(1) - 1)
                        {
                            if (labyrinth[i, j + 1] == '#' & labyrinth[i, j + 2] == '#')
                            {
                                RandomMove[FirstRndMoveX, 0] = j + 1; FirstRndMoveX++;
                                RandomMove[FirstRndMoveY, 1] = i; FirstRndMoveY++;
                                RandomMove[SecondRndMoveX, 2] = j + 2; SecondRndMoveX++;
                                RandomMove[SecondRndMoveY, 3] = i; SecondRndMoveY++;
                                QuantityMove++;
                            }
                        }
                    }
                }
            }
            Generation();
        }

        //Метод для выбора дальнейшей генерации лабиринта
        private void Generation()
        {
            if (RandomMove[0, 0] == 0)
                return;
            Random rnd = new Random();
            int NeedElem = rnd.Next(0, QuantityMove);
            labyrinth[RandomMove[NeedElem, 1],RandomMove[NeedElem,0]] = ' ';
            labyrinth[RandomMove[NeedElem, 3], RandomMove[NeedElem, 2]] = '+';
            QuantityMove = 0;
            AllZero();
            Console.Clear();
            PrintLabyrinth();
            FindLegalMove();
        }
        private void AllZero()
        {
            for (int i = 0; i < RandomMove.GetLength(0); i++)
            {
                for(int j = 0; j < RandomMove.GetLength(1); j++)
                {
                    RandomMove[i, j] = 0;
                }
            }
        }

        //Метод используется только для вывода уже сгинерированного лабиринта или для его
        //промежуточных результатов.
        public void PrintLabyrinth()
        {
            for (int i = 0;i < labyrinth.GetLength(0);i++)
            {
                for(int j = 0;j < labyrinth.GetLength(1); j++)
                    Console.Write(labyrinth[i,j]);
                Console.WriteLine();
            }
        }

        public void NewIntOflabyrinth()
        {
            Console.Clear();
            for (int i = 0;i < labyrinth.GetLength(0);i++)
            {
                for (int j = 0;j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == '#')
                        labyrinth[i, j] = '█';
                    if (labyrinth[i,j] == '+' | labyrinth[i,j] ==' ')
                        labyrinth[i,j] = '░';
                }
            }
        }
    }
}
