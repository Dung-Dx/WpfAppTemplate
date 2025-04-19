using WpfAppTemplate.ViewModels;
using System.Windows;

namespace WpfAppTemplate.Views
{
    public partial class HoSoDaiLyWinDow : Window
    {
        public HoSoDaiLyWinDow(HoSoDaiLyViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
