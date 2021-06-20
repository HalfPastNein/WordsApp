using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsApp
{
    public class Word
    {
        public string TheWord { get; set; }
        public string Meaning { get; set; }
        public int Score { get; set; }
        public static ObservableCollection<Word> Words { get; } = new ObservableCollection<Word>();
        public static Word GetRandomWord()
        {
            var size = Word.Words.Count;
            if (size == 0)
                return null;
            var r = new Random();
            int randomIndex = r.Next(0, size);
            return Word.Words[randomIndex];
        }
        public static void GetWordsFromFile()
        {
            Words.Clear();
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            var fileName = "words.txt";
            var fullPathToFile = storageFolder.Path + "\\" + fileName;
            if (!File.Exists(fullPathToFile))
                return;

            var wordsFromFile = File.ReadAllText(fullPathToFile);
            var lines = wordsFromFile.Split('\n');
            for (var i=0; i<lines.Length-1; i++)
            {
                var currentWordInfo = lines[i].Split(',');
                Word tempWord = new Word();
                tempWord.TheWord = currentWordInfo[0];
                tempWord.Meaning = currentWordInfo[1];
                tempWord.Score = int.Parse(currentWordInfo[2]);
                Words.Add(tempWord);
            }
            


        }
        public static void WriteWordsToFile()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            
            var fileName = "words.txt";
            var fullPathToFile = storageFolder.Path + "\\" + fileName;

            if (File.Exists(fullPathToFile))
            {
                File.Delete(fullPathToFile);
            }

            string writeToFile="";
            foreach (var word in Words)
                writeToFile += word.TheWord + "," + word.Meaning + "," + word.Score.ToString() + '\n';

            File.WriteAllText(fullPathToFile, writeToFile);
        }
    }
}
