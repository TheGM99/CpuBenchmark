using CpuBenchmark.Models;
using System;
using System.Management;
using System.Threading.Tasks;
using System.Windows;


namespace CpuBenchmark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int machId;
        private string PC = Environment.MachineName;
        private string OS = GetOsName();
        private string CPU = GetProcessorName();
        private int MEM = GetRAM();
        private int scoreOne;
        private int scoreAll;
        private MongoConnection mc = new MongoConnection();

        public MainWindow()
        {
            InitializeComponent();
            pcText.Content = PC;
            osText.Content = OS;
            cpuText.Content = CPU;
            memText.Content = MEM + " GB";

        }

        private async void Window_Loaded(object sender, EventArgs e)
        {
            var machine = mc.GetMachine(PC);
            if (machine == null)
            {
                machId = mc.GetLastMachineId();
                Machine temp = new Machine();
                temp.machineId = ++machId;
                temp.machineName = PC;
                temp.operatingSystem = OS;
                temp.CPU = CPU;
                temp.memSize = MEM;
                mc.AddMachine(temp);
            }
            else machId = Convert.ToInt32(machine.GetElement("machineId").Value);
            await Task.Run(() => RunTests(11));

            Thinking(false);
        }

        private void RunTests(int n)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Fannkuch.init(n,true);
            watch.Stop();
            Application.Current.Dispatcher.Invoke(() =>{
                scoreAll = Convert.ToInt32(Math.Ceiling(watch.Elapsed.TotalSeconds));
                scoreTextAll.Content =  scoreAll + " s";
            });

            watch.Restart();
            Fannkuch.init(n,false);
            watch.Stop();

            Application.Current.Dispatcher.Invoke(() => {
                scoreOne = Convert.ToInt32(Math.Ceiling(watch.Elapsed.TotalSeconds));
                scoreTextSingle.Content = scoreOne + " s";
            });

            var res = new Entry();
            res.entryId = mc.GetLastEntryId() + 1;
            res.machineId = machId;

            res.timeScoreSingle = scoreOne;
            res.timeScoreMulti = scoreAll;

            res.performDate = DateTime.Now;
            mc.AddEntry(res);
        }
        private static string GetOsName()
        {
            ManagementObjectSearcher mosOS = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            string osName = null;

            foreach (ManagementObject moOS in mosOS.Get())
            {
                if (moOS["Caption"] != null)
                {
                    osName = moOS["Caption"].ToString();

                }

            }

            return osName;
        }
        private static string GetProcessorName()
        {
            ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            string procName = null;

            foreach (ManagementObject moProcessor in mosProcessor.Get())
            {
                if (moProcessor["name"] != null)
                {
                    procName = moProcessor["name"].ToString();

                }

            }

            return procName;
        }
        private static int GetRAM()
        {
            ManagementObjectSearcher mosMEM = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            double memSize = 0;

            foreach (ManagementObject moMEM in mosMEM.Get())
            {
                if (moMEM["TotalPhysicalMemory"] != null)
                {
                    memSize = Convert.ToDouble(moMEM["TotalPhysicalMemory"]);
                    memSize = memSize / 1073741824;
                }

            }

            return Convert.ToInt32(memSize);
        }

        private async void RunAgain(object sender, RoutedEventArgs e)
        {
            Thinking(true);

            await Task.Run(() => RunTests(11));

            Thinking(false);
        }

        private void Thinking(bool isThinking)
        {
            if (isThinking)
            {
                progBar.Visibility = Visibility.Visible;
                scoreLabelSingle.Visibility = Visibility.Collapsed;
                scoreLabelAll.Visibility = Visibility.Collapsed;
                scoreTextSingle.Visibility = Visibility.Collapsed;
                scoreTextAll.Visibility = Visibility.Collapsed;

                runButton.IsEnabled = false;
                compareButton.IsEnabled = false;
            }
            else
            {
                progBar.Visibility = Visibility.Collapsed;
                scoreLabelSingle.Visibility = Visibility.Visible;
                scoreLabelAll.Visibility = Visibility.Visible;
                scoreTextSingle.Visibility = Visibility.Visible;
                scoreTextAll.Visibility = Visibility.Visible;

                runButton.IsEnabled = true;
                compareButton.IsEnabled = true;
            }
        }

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            var resultWindow = new ResultWindow();
            resultWindow.Show();
            this.Close();
        }
    }
}
