using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WordsApp
{
    public sealed partial class WordsTablePage : Page
    {
        
        public WordsTablePage()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<Word> WordsToTable { get { return Word.Words; } }
    }
}
