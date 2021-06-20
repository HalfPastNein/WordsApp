using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WordsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddWordPage : Page
    {
        public AddWordPage()
        {
            this.InitializeComponent();
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            Word tempWord = new Word();
            if (this.AddWordTextBox.Text == "" || this.AddMeaningTextBox.Text == "")
            {
                this.ErrorTextBlock.Text = "Please fill all required fields";
                return;
            }
            tempWord.TheWord = this.AddWordTextBox.Text;
            tempWord.Meaning = this.AddMeaningTextBox.Text;
            Word.Words.Add(tempWord);
            Word.WriteWordsToFile();
            this.ErrorTextBlock.Text = "Word added successfully";
            this.AddWordTextBox.Text = "";
            this.AddMeaningTextBox.Text = "";
            this.AddWordTextBox.Focus(FocusState.Programmatic);
        }

        private void addWordButton_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                AddWordButton_Click(sender, e);
        }
    }
}
