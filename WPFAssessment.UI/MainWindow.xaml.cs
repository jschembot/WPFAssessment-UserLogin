using System;
using System.Threading.Tasks;
using System.Windows;
using WPFAssessment.UI.ViewModel;

namespace WPFAssessment.UI
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
            Loaded += MainWindow_LoadedAsync;
        }

        private async void MainWindow_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

    }
}
