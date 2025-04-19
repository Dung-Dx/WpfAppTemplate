using System.Windows;
using WpfAppTemplate.ViewModels;

namespace WpfAppTemplate.Views
{
    /// <summary>
    /// Interaction logic for CapNhatDaiLyWindow.xaml
    /// </summary>
    public partial class CapNhatDaiLyWindow : Window
    {
        public CapNhatDaiLyWindow(CapNhatDaiLyViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
