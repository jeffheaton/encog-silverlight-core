using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Encog;
using Encog.Util.Banchmark;
using System.Threading;
using Encog.Engine;

namespace SilverlightExample
{
    public partial class MainPage : UserControl, IStatusReportable
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void BackgroundThread()
        {
            EncogBenchmark benchmark = new EncogBenchmark(this);
            string result = benchmark.Process();
            Dispatcher.BeginInvoke(() => this.List.Items.Add("Final benchmark score(lower is better): " + result));
        }

        private void Hello_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(() => { this.Control.IsEnabled = false; });
            Thread thread = new Thread(new ThreadStart(BackgroundThread));
            thread.Start();

        }

        public void Report(int total, int current, string message)
        {
            Dispatcher.BeginInvoke(() => this.List.Items.Add(current + "/" + total + ":" + message));
        }
    }
}
