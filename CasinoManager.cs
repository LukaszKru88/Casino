using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    class CasinoManager
    {
        private FileManager _fileManager;
        private CroupierUnpacker _croupierUnpacker;
        private CroupierRandomizer _croupierRandomizer;
        private CroupierEasyGame _croupierEasyGame;
        private CroupierHardGame _croupierHardGame;
        private string[] lines;
        private string[] deck;
        private string line;

        public CasinoManager()
        {
            _fileManager = new FileManager();
        }

        public void Run()
        {
            string action;

            do
            {
                PrintManiMenu();
                action = SelectAction();

                switch(action)
                {
                    case "1":
                        Task_1(action);
                        break;
                    case "2":
                        Task_2(action);
                        break;
                    case "3":
                        Task_3(action);
                        break;
                    case "4":
                        Task_4(action);
                        break;
                    case "5":
                        Task_5(action);
                        break;
                    case "all":
                        Task_1("1");
                        Task_2("2");
                        Task_3("3");
                        Task_4("4");
                        Task_5("5");
                        break;
                    case "0":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown command");
                        Console.ReadKey();
                        break;
                }
            }
            while (action != "0");
        }

        private void PrintManiMenu()
        {
            Console.Clear();
            Console.WriteLine("1 - Copy deck to file");
            Console.WriteLine("2 - Unpack the deck");
            Console.WriteLine("3 - Unpack the decks and  get random 10 cards");
            Console.WriteLine("4 - Play an easy card game");
            Console.WriteLine("5 - Play a hard card game");
            Console.WriteLine("all - Perform all tasks in sequence");
            Console.WriteLine("-----------------------");
            Console.WriteLine("0 - Exit");
        }

        private string SelectAction()
        {
            Console.WriteLine();
            Console.Write("Which command do you wish to run? ");
            string action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
            {
                return "-1";
            }
            return action;
        }

        private void Task_1(string action)
        {
            Console.Clear();
            lines = _fileManager.ReadAllFile();
            _fileManager.SaveToFile(lines, action);
            Console.WriteLine("The deck was copied to file.");
            Console.ReadKey();
        }

        private void Task_2(string action)
        {
            Console.Clear();
            line = _fileManager.ReadFristLineFromFile();
            _croupierUnpacker = new CroupierUnpacker();
            deck = _croupierUnpacker.UnpackTheDeck(line);
            line = _fileManager.PrepareFileToSave(deck);
            _fileManager.SaveToFile(line, action);
            Console.WriteLine("The deck was unpacked and stored in file.");
            Console.ReadKey();
        }

        private void Task_3(string action)
        {
            Console.Clear();
            lines = _fileManager.ReadAllFile();
            _croupierRandomizer = new CroupierRandomizer();
            deck = _croupierRandomizer.RandomizeTheDeck(lines);
            line = _fileManager.PrepareFileToSave(deck);
            _fileManager.SaveToFile(line, action);
            Console.WriteLine("The deck was randomized and stored in file.");
            Console.ReadKey();
        }

        private void Task_4(string action)
        {
            Console.Clear();
            line = _fileManager.ReadFristLineFromFile();
            _croupierEasyGame = new CroupierEasyGame();
            deck = _croupierEasyGame.PlayEasyGame(line);
            _fileManager.SaveToFile(deck, action);
            Console.WriteLine("The easy game finished and the results were stored in file.");
            Console.ReadKey();
        }

        private void Task_5(string action)
        {
            Console.Clear();
            _croupierHardGame = new CroupierHardGame();
            deck = _croupierHardGame.PlayHardGame();
            _fileManager.SaveToFile(deck, action);
            Console.WriteLine("The hard game finished and the results were stored in file.");
            Console.ReadKey();
        }
    }
}
