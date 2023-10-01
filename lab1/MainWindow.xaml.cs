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
    }
}
