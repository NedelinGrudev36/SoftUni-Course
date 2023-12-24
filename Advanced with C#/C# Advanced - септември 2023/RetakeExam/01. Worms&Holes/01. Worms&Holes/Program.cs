using System;

namespace _01._Worms_Holes
{
    class WormHoleMatch
    {
        static void Main()
        {
            int[] worms = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] holes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> wormStack = new Stack<int>();
            Queue<int> holeQueue = new Queue<int>();
            foreach (int i in worms)
            {
                wormStack.Push(i);
            }
            foreach (int i in holes)
            { holeQueue.Enqueue(i); }

            int matchesCount = 0;
            int currentWorm;
            int currentHole;

            while (wormStack.Count > 0 && holeQueue.Count > 0)
            {
                currentWorm = wormStack.Peek();
                currentHole = holeQueue.Peek();

                if (currentWorm == currentHole)
                {
                    matchesCount++;
                    wormStack.Pop();
                    holeQueue.Dequeue();
                }
                else if (currentWorm >= 0)
                {
                    wormStack.Pop();
                    currentWorm -= 3;
                    wormStack.Push(currentWorm);
                    holeQueue.Dequeue();

                }
            }
            if (matchesCount == 0)
            {
                Console.WriteLine("There are no matches.");
            }
            else if (matchesCount > 0)
            {
                Console.WriteLine("Matches: {0}", matchesCount);
            }

            if (wormStack.Count == 0)
            {
                Console.WriteLine("Every worm found a suitable hole!");
            }
            else
            {
                Console.WriteLine("Worms left: {0}", string.Join(", ", wormStack));
            }

            if (holeQueue.Count == 0)
            {
                Console.WriteLine("Holes left: none");
            }
            else
            {
                Console.WriteLine("Holes left: {0}", string.Join(", ", holeQueue));
            }
        }
    }


}