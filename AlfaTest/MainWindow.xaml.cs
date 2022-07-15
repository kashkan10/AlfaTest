using System;
using System.Diagnostics;
using System.Windows;

namespace AlfaTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Manager manager;
        private const string pathToFiles = @"..\..\..\Files\";
        private const string inputFilePath = pathToFiles + "data.xml";

        public MainWindow()
        {
            InitializeComponent();
            manager = new Manager(inputFilePath);
        }

        private async void ParseWithDeserialize(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await manager.ParseAsync(new DeserializeParser<Channel>());
        }

        private async void ParseWithXPath(object sender, RoutedEventArgs e)
        {
            textBlock.Text = await manager.ParseAsync(new XPathParser());
        }

        private async void WriteToTxt(object sender, RoutedEventArgs e)
        {
            await manager.WriteAsync(new TxtWriter(pathToFiles)).ContinueWith(x => GoToDirectory(pathToFiles + "output.txt"));
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            manager.ClearText();
            textBlock.Text = "";
        }

        private void GoToFilesDirectory(object sender, RoutedEventArgs e)
        {
            GoToDirectory(pathToFiles);
        }

        private void GoToDirectory(string path)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "explorer",
                    Arguments = System.IO.Path.Combine(Environment.CurrentDirectory, path)
                }
            };

            process.Start();
        }
    }
}