using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using lab1.Encryption;

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

        private void IntKeyInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!int.TryParse(textBox.Text, out int value) || value > 32)
                CaesarKeyInput.Text = value > 32 ? "32" : "1";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
            => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        => e.Handled = new Regex("[^a-zA-Zа-яА-Я]+").IsMatch(e.Text);

        private void CeaserRadioButton_Checked(object sender, RoutedEventArgs e)
            => CaesarKeyInput.IsEnabled = true;

        private void CeaserRadioButton_UnChecked(object sender, RoutedEventArgs e)
            => CaesarKeyInput.IsEnabled = false;

        private void TrithemiusRadioButton_Checked(object sender, RoutedEventArgs e)
            => TrithemiusKeyInput.IsEnabled = true;

        private void TrithemiusRadioButton_UnChecked(object sender, RoutedEventArgs e)
            => TrithemiusKeyInput.IsEnabled = false;


        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaesarEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new CeaserEncoder(int.Parse(CaesarKeyInput.Text)).Encrypt(InputTextBox.Text);
            }
            if (TrithemiusEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new TrithemiusEncoder(TrithemiusKeyInput.Text).Encrypt(InputTextBox.Text);
            }
            if (MonoEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new MonoEncoder().Encrypt(InputTextBox.Text);
            }
        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CaesarEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new CeaserEncoder(int.Parse(CaesarKeyInput.Text)).Decrypt(InputTextBox.Text);
            }
            if (TrithemiusEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new TrithemiusEncoder(TrithemiusKeyInput.Text).Decrypt(InputTextBox.Text);
            }
            if (MonoEncoding.IsChecked == true)
            {
                outPutTextBox.Text = new MonoEncoder().Decrypt(InputTextBox.Text);
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
            var text = InputTextBox.Text.ToLower();
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

        private void Graphic_Button_Click(object sender, RoutedEventArgs e)
        {
            var freq = new Dictionary<char, double>(AppConstants.RussianAlphabet.Length);
            var text = InputTextBox.Text.ToLower();
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
            new Diagrams(freq).Show();
        }
    }
}
