using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!int.TryParse(textBox.Text, out int value) || value > 32)
                ceaserKeyInput.Text = value > 32 ? "32" : "1";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
            => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        private void CeaserRadioButton_Checked(object sender, RoutedEventArgs e)
            => ceaserKeyInput.IsEnabled = true;

        private void CeaserRadioButton_UnChecked(object sender, RoutedEventArgs e)
            => ceaserKeyInput.IsEnabled = false;

        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ceaserEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new CeaserEncoder(int.Parse(ceaserKeyInput.Text)).Encrypt(inputTextBox.Text);
            }
        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ceaserEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new CeaserEncoder(int.Parse(ceaserKeyInput.Text)).Decrypt(inputTextBox.Text);
            }
        }

        private void Frequency_Button_Click(object sender, RoutedEventArgs e)
        {
            //todo change to normal update
            textFrequency.ItemsSource = null;
            languageFrequency.ItemsSource = null;
            languageFrequency.Items.Clear();
            textFrequency.Items.Clear();
            var freq = new Dictionary<char, double>(AppConstants.RussianAlphabet.Length);
            var text = inputTextBox.Text.ToLower();
            foreach (var c in AppConstants.RussianAlphabet.ToLower())
                freq[c] = 0;

            foreach (var letter in text)
            {
                if (AppConstants.RussianAlphabet.ToLower().Contains(letter.ToString()))
                {
                    var counter = text.Count(ch => ch == letter);
                    freq[letter] = Math.Round(((double)counter / text.Length) * 100, 2);
                }
            }

            languageFrequency.ItemsSource = AppConstants.RussianLanguageLettersFrequency;
            textFrequency.ItemsSource = freq.OrderByDescending(x => x.Value);
        }
    }
}
