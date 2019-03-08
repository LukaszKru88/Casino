using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    class FileManager
    {
        private string inFilePath = "E:/Qki-Dev/Corealate 2/Files/InData.txt";
        private string outFilePath;

        public string[] ReadAllFile()
        {
            string[] lines = File.ReadAllLines(inFilePath);
            return lines;
        }

        public string ReadFristLineFromFile()
        {
            string line = "";
            try
            {
                line = File.ReadLines(inFilePath).First();
            }
            catch (Exception)
            {
                line = "Task 2 impossible – improper CardDeck in the first line";
            }
 
            return line;
        }

        public void SaveToFile(string[] lines, string action)
        {
            outFilePath = SelectSavePath(action);
            File.WriteAllLines(outFilePath, lines);
        }

        public void SaveToFile(string line, string action)
        {
            outFilePath = SelectSavePath(action);
            File.WriteAllText(outFilePath, line);
        }

        private string SelectSavePath(string action)
        {
            switch (action)
            {
                case "1":
                    outFilePath = "E:/Qki-Dev/Corealate 2/Files/OutData-1.txt";
                    break;
                case "2":
                    outFilePath = "E:/Qki-Dev/Corealate 2/Files/OutData-2.txt";
                    break;
                case "3":
                    outFilePath = "E:/Qki-Dev/Corealate 2/Files/OutData-3.txt";
                    break;
                case "4":
                    outFilePath = "E:/Qki-Dev/Corealate 2/Files/OutData-4.txt";
                    break;
            }

            return outFilePath;
        }

        public string PrepareFileToSave(string[] unpackDeck)
        {
            string line = "";
            for(int i = 0; i < unpackDeck.Length; i++)
            {
                line += unpackDeck[i] + ", ";
            }
            return line;
        }
    }
}
