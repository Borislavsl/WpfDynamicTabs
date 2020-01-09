using System.Windows;
using DynamicTabs.ViewModels;
using Models;

namespace DynamicTabs
{    
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel(new TabItemsProvider());
        }
    }
}
