using LiveCharts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace CpuBenchmark
{
    /// <summary>
    /// Interaction logic for StressWindow1.xaml
    /// </summary>
    public partial class StressWindow1 : Window
    {
        private bool isRunning = true;
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public string[] Labels { get; set; }

        private static PerformanceCounter cpuCounter { get; set; }

        public StressWindow1()
        {
            InitializeComponent();

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            caretesianChart.AxisY.Clear();

            caretesianChart.AxisY.Add(
            new Axis
            {
                MinValue = 0,
                MaxValue = 100
            });

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "CPU Usage",
                    Values = new ChartValues<int> { GetCpuUsage(), GetCpuUsage() },
                    PointGeometry = null
                }
            };
            YFormatter = value => value.ToString("C");
            DataContext = this;
        }

        private async void stressWindow_ContentRendered(object sender, EventArgs e)
        {
            var tasks = new List<Task>
            {
                new Task(() => RunStressTest()),
                new Task(() => RunTemp())
            };

            Parallel.ForEach(tasks, task =>
            {
                task.Start();
            });

            await Task.WhenAll(tasks);
        }

        private void RunStressTest()
        {
            while (isRunning)
            {
                Fannkuch.init(12, true);
            }
        }

        private void RunTemp()
        {
            while (isRunning)
            {
                System.Threading.Thread.Sleep(500);
                SeriesCollection[0].Values.Add(GetCpuUsage());
            }
        }

        private void stressWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                isRunning = false;
                var startWindow = new StartupWindow();
                startWindow.Show();
                this.Close();
            }
        }

        private static int GetCpuUsage()
        {
            return Convert.ToInt32(cpuCounter.NextValue());
        }
    }
}
