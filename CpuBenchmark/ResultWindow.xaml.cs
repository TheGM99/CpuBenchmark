using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Windows;
using CpuBenchmark.Models;

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
        Entry recentEntry;
        public ResultWindow()
        {
            InitializeComponent();

            var machine = mc.GetMachine(Environment.MachineName);
            var doc = mc.GetEntriesByMachine(Convert.ToInt32(machine.machineId));
            recentEntry = doc.entries[doc.entries.Count - 1];
            compare();
            foreach (var entry in doc.entries)
            {
                tempOne.Add(Convert.ToInt32(entry.timeScoreSingle));
                tempAll.Add(Convert.ToInt32(entry.timeScoreMulti));
                dates.Add(entry.performDate.ToString());
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
            foreach (var entry in allEntries.entries)
            {
                if (Convert.ToInt32(entry.timeScoreSingle) > Convert.ToInt32(recentEntry.timeScoreSingle)) betterThan++;
                else if (Convert.ToInt32(entry.timeScoreMulti) > Convert.ToInt32(recentEntry.timeScoreMulti)) betterThan++;
            }
            betterThan = Math.Round(betterThan/allEntries.entries.Count * 100);
            comparisonLabel.Content = "You did better than " + betterThan + "% of all entries !";
        }
    }
}
