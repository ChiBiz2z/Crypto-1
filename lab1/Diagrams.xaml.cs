using lab1;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace lab1
{
    public partial class Diagrams : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public Diagrams(Dictionary<char, double> encryptArr)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Зашифрованный текст",
                    Values = new ChartValues<double>(encryptArr.Values.OrderByDescending(x => x).ToArray()),
                },
                new LineSeries
                {
                    Title = "Русский алфавит",
                    Values = new ChartValues<double>(AppConstants.RussianLanguageLettersFrequency.Values.ToArray())
                }
            };


            DataContext = this;
        }
    }
}
