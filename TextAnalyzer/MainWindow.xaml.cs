using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer
{
    public partial class MainWindow : Window
    {
        private const string FILTER = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        private readonly ITextAnalyzer textAnalyzer;
        private readonly ITextHandler hendler;

        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection().RegisterServices();
            using var builder = services.BuildServiceProvider();

            textAnalyzer = builder.GetRequiredService<ITextAnalyzer>();
            hendler = builder.GetRequiredService<ITextHandler>();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = FILTER;

            if (openFileDialog.ShowDialog() == true)
            {
                mainTextBox.Clear();
                mainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SpellchekBox_Checked(object sender, RoutedEventArgs e)
        {
            mainTextBox.SpellCheck.IsEnabled = true;
        }

        private void SpellchekBox_Unchecked(object sender, RoutedEventArgs e)
        {
            mainTextBox.SpellCheck.IsEnabled = false;
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            List<AnalyzeResults> resultsList = new List<AnalyzeResults>();
            analyzeGrid.ItemsSource = resultsList;
            string[] words = hendler.GetWords(mainTextBox.Text);

            if (keyWordTextBox.Text.Length > 0)
            {
                var result = textAnalyzer.Analyzer.WordAnalyze(words, keyWordTextBox.Text);

                resultsList.Add(result);
                textAnalyzer.AddResult(result);

                analyzeGrid.SelectAll();
            }

            if ((bool)allWordsCheckBox.IsChecked)
            {
                resultsList.AddRange(textAnalyzer.TextAnalyze(words));

            }

            wordsBlock.Text = "Words sum: " + words.Length.ToString();
            charsBlock.Text = "Chars sum: " + hendler.GetCharCount(words).ToString();
        }

        private void KeyWordTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
