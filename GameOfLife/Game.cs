using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Game
    {
        private World world;
        private ConsoleDisplay consoleDisplay;

        public Game(World world, ConsoleDisplay consoleDisplay)
        {
            this.world = world;
            this.consoleDisplay = consoleDisplay;
        }

        public void Start()
        { 
            CancellationTokenSource cts = new CancellationTokenSource();

            var kbTask = Task.Run(() =>
            {
                KeyboardInputTaks(cts);
            });

            Task.Run(() => UpdateAndDisplayGameOfLife(), cts.Token);
            kbTask.Wait();
        }

        private void KeyboardInputTaks(CancellationTokenSource cts)
        {
            while (true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key.ToString() == "X")
                {
                    cts.Cancel();
                    break;
                }

                ShiftGrid(userInput);
                UserInputPatterns(userInput);
            }
        }

        private void UserInputPatterns(ConsoleKeyInfo userInput)
        {
            
            int shiftX = consoleDisplay.GetShiftX();
            int shiftY = consoleDisplay.GetShiftY();
            if (userInput.Key == ConsoleKey.D1)
            {
                List<Location> glider = new List<Location>() { new Location(0, 0), new Location(2, 0), new Location(2, 1), new Location(1, 1), new Location(1, 2) };
                world.SetLivingCellsAtLocations(AddLocationIncrements(glider));
            }

            if (userInput.Key == ConsoleKey.D2)
            {
                List<Location> block = new List<Location>() { new Location(0, 0), new Location(0, 1), new Location(1, 1), new Location(1, 0) };
                world.SetLivingCellsAtLocations(AddLocationIncrements(block));
            }

            if (userInput.Key == ConsoleKey.D3)
            {
                List<Location> alternator = new List<Location>() { new Location(0, 0), new Location(0, 1), new Location(0, 2)};
                world.SetLivingCellsAtLocations(AddLocationIncrements(alternator));
            }
        }

        private List<Location> AddLocationIncrements(List<Location> pattern)
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                pattern[i] = new Location(pattern[i].X + consoleDisplay.GetShiftX(),
                                          pattern[i].Y + consoleDisplay.GetShiftY());
            }
            return pattern;
        }

        private void ShiftGrid(ConsoleKeyInfo userInput)
        {
            if (userInput.Key.ToString() == "DownArrow")
            {
                consoleDisplay.IncrementShiftX();
            }
            else if (userInput.Key.ToString() == "UpArrow")
            {
                consoleDisplay.DecrementShiftX();
            }
            else if (userInput.Key.ToString() == "RightArrow")
            {
                consoleDisplay.IncrementShiftY();
            }
            else if (userInput.Key.ToString() == "LeftArrow")
            {
                this.consoleDisplay.DecrementShiftY();
            }
        }

        void UpdateAndDisplayGameOfLife()
        {
            while (true)
            {
                consoleDisplay.GetStringGrid(world);
                consoleDisplay.DisplayWorld();
                world.Tick();
                Thread.Sleep(800);
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game(new World(), new ConsoleDisplay());
            game.Start();
        }
    }
}
