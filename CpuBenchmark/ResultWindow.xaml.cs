using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Bson;

namespace CpuBenchmark
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public SeriesCollection seriesCollection { get; set; }
        List<string> dates = new List<string>();
        ChartValues<int> tempOne = new ChartValues<int>();
        ChartValues<int> tempAll = new ChartValues<int>();
        MongoConnection mc = new MongoConnection();
        BsonDocument recentEntry;
        public ResultWindow()
        {
            InitializeComponent();

            var machine = mc.GetMachine(Environment.MachineName);
            var Entries = mc.GetEntriesByMachine(Convert.ToInt32(machine.GetElement("machineId").Value));
            recentEntry = Entries[Entries.Count - 1];
            compare();
            foreach (var entry in Entries)
            {
                tempOne.Add(Convert.ToInt32(entry.GetElement("timeScoreSingle").Value));
                tempAll.Add(Convert.ToInt32(entry.GetElement("timeScoreMulti").Value));
                dates.Add(entry.GetElement("performDate").Value.ToString());
            }
            caretesianChart.AxisY.Clear();

            caretesianChart.AxisY.Add(
            new Axis
            {
                MinValue = 0,
                MaxValue = 40
            });

            seriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Single Core",
                    Values = tempOne
                },
                new LineSeries
                {
                    Title = "All Cores",
                    Values = tempAll
                }
            };
            DataContext = this;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            var startupWindow = new StartupWindow();
            startupWindow.Show();
            this.Close();
        }

        private void compare()
        {
            var allEntries = mc.GetEntries();
            double betterThan = 0;
            foreach (var entry in allEntries)
            {
                if (Convert.ToInt32(entry.GetElement("timeScoreSingle").Value) > Convert.ToInt32(recentEntry.GetElement("timeScoreSingle").Value)) betterThan++;
                else if (Convert.ToInt32(entry.GetElement("timeScoreMulti").Value) > Convert.ToInt32(recentEntry.GetElement("timeScoreMulti").Value)) betterThan++;
            }
            betterThan = Math.Round(betterThan/allEntries.Count * 100);
            comparisonLabel.Content = "You did better than " + betterThan + "% of all entries !";
        }
    }
}
