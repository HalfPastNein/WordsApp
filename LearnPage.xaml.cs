using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LearnPage : Page
    {
        Word rWord;
        public LearnPage()
        {
            this.InitializeComponent();
            Word.GetWordsFromFile();
            rWord = Word.GetRandomWord();
            if (rWord!=null)
                this.RandomWordBlock.Text = rWord.TheWord;
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (rWord==null)
            {
                UpdateRandomWord();
                return;
            }
            if (this.AnswerBlock.Text.ToLower() == rWord.Meaning.ToLower())
            {
                Word.Words.Single(x => x.TheWord == rWord.TheWord).Score += 1;
                this.ResultStatusBlock.Text = "Correct!";
                this.ResultStatusBlock.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Word.Words.Single(x => x.TheWord == rWord.TheWord).Score -= 1;
                this.ResultStatusBlock.Text = "Wrong! Correct is: " + rWord.Meaning;
                this.ResultStatusBlock.Foreground = new SolidColorBrush(Colors.Red);
            }
            this.AnswerBlock.Text = "";
            this.UpdateRandomWord();
            
        }
        private void UpdateRandomWord()
        {
            var prevWord = rWord.TheWord;
            while (rWord.TheWord == prevWord)
            {
                rWord = Word.GetRandomWord();
            }
            this.RandomWordBlock.Text = rWord.TheWord;
            Word.WriteWordsToFile();
        }

        private void AnswerBlock_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                Button_Click(sender, e);
        }
    }
}
