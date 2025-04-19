using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppTemplate.Commands;
using WpfAppTemplate.Models;
using WpfAppTemplate.Services;
using WpfAppTemplate.Views;

namespace WpfAppTemplate.ViewModels
{
    public class CapNhatDaiLyViewModel : INotifyPropertyChanged
    {
        private readonly IDaiLyServices _daiLyService;
        private readonly IQuanServices _quanService;
        private readonly ILoaiDaiLyServices _loaiDaiLyService;
        private readonly int _daiLyId;

        public CapNhatDaiLyViewModel(
            IDaiLyServices daiLyService,
            IQuanServices quanService,
            ILoaiDaiLyServices loaiDaiLyService,
            int dailyId)
        {
            _daiLyService = daiLyService;
            _quanService = quanService;
            _loaiDaiLyService = loaiDaiLyService;
            _daiLyId = dailyId;

            CloseWindowCommand = new RelayCommand(CloseWindow);
            CapNhatDaiLyCommand = new RelayCommand(async () => await CapNhatDaiLy());

            _ = LoadDataAsync();
        }

        public event EventHandler? DataChanged;

        //Binding
        private string _maDaiLy = string.Empty;
        public string MaDaiLy
        {
            get => _maDaiLy;
            set
            {
                _maDaiLy = value;
                OnPropertyChanged();
            }
        }

        private string _tenDaiLy = string.Empty;
        public string TenDaiLy
        {
            get => _tenDaiLy;
            set
            {
                _tenDaiLy = value;
                OnPropertyChanged();
            }
        }

        private string _soDienThoai = string.Empty;
        public string SoDienThoai
        {
            get => _soDienThoai;
            set
            {
                _soDienThoai = value;
                OnPropertyChanged();
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private DateTime _ngayTiepNhan;
        public DateTime NgayTiepNhan
        {
            get => _ngayTiepNhan;
            set
            {
                _ngayTiepNhan = value;
                OnPropertyChanged();
            }
        }

        private string _diaChi = string.Empty;
        public string DiaChi
        {
            get => _diaChi;
            set
            {
                _diaChi = value;
                OnPropertyChanged();
            }
        }

        private LoaiDaiLy _selectedLoaiDaiLy = new();
        public LoaiDaiLy SelectedLoaiDaiLy
        {
            get => _selectedLoaiDaiLy;
            set
            {
                _selectedLoaiDaiLy = value;
                OnPropertyChanged();
            }
        }

        private Quan _selectedQuan = new();
        public Quan SelectedQuan
        {
            get => _selectedQuan;
            set
            {
                _selectedQuan = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LoaiDaiLy> _loaiDaiLies = [];
        public ObservableCollection<LoaiDaiLy> LoaiDaiLies
        {
            get => _loaiDaiLies;
            set
            {
                _loaiDaiLies = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Quan> _quans = [];
        public ObservableCollection<Quan> Quans
        {
            get => _quans;
            set
            {
                _quans = value;
                OnPropertyChanged();
            }
        }

        //Command
        public ICommand CloseWindowCommand { get; }
        public ICommand CapNhatDaiLyCommand { get; }

        private async Task LoadDataAsync()
        {
            var listLoaiDaiLy = await _loaiDaiLyService.GetAllLoaiDaiLy();
            var listQuan = await _quanService.GetAllQuan();

            LoaiDaiLies.Clear();
            Quans.Clear();
            LoaiDaiLies = [.. listLoaiDaiLy];
            Quans = [.. listQuan];

            // Load the DaiLy data
            try
            {
                var daiLy = await _daiLyService.GetDaiLyById(_daiLyId);
                MaDaiLy = daiLy.MaDaiLy.ToString();
                TenDaiLy = daiLy.TenDaiLy;
                SoDienThoai = daiLy.DienThoai;
                Email = daiLy.Email;
                DiaChi = daiLy.DiaChi;
                NgayTiepNhan = daiLy.NgayTiepNhan;

                // Set selected values
                SelectedLoaiDaiLy = LoaiDaiLies.FirstOrDefault(l => l.MaLoaiDaiLy == daiLy.MaLoaiDaiLy) ??
                                    new LoaiDaiLy();
                SelectedQuan = Quans.FirstOrDefault(q => q.MaQuan == daiLy.MaQuan) ?? new Quan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu đại lý: {ex.Message}", "Lỗi", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }


        private void CloseWindow()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
            Application.Current.Windows.OfType<CapNhatDaiLyWindow>().FirstOrDefault()?.Close();
        }

        private async Task CapNhatDaiLy()
        {
            if (string.IsNullOrWhiteSpace(TenDaiLy))
            {
                MessageBox.Show("Tên đại lý không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(SelectedLoaiDaiLy.TenLoaiDaiLy) || string.IsNullOrEmpty(SelectedQuan.TenQuan))
            {
                MessageBox.Show("Vui lòng chọn loại đại lý và quận!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var existingDaiLy = await _daiLyService.GetDaiLyById(_daiLyId);
                existingDaiLy.TenDaiLy = TenDaiLy;
                existingDaiLy.DienThoai = SoDienThoai;
                existingDaiLy.Email = Email;
                existingDaiLy.DiaChi = DiaChi;
                existingDaiLy.NgayTiepNhan = NgayTiepNhan;
                existingDaiLy.MaLoaiDaiLy = SelectedLoaiDaiLy.MaLoaiDaiLy;
                existingDaiLy.MaQuan = SelectedQuan.MaQuan;
                existingDaiLy.LoaiDaiLy = SelectedLoaiDaiLy;
                existingDaiLy.Quan = SelectedQuan;

                await _daiLyService.UpdateDaiLy(existingDaiLy);
                MessageBox.Show("Cập nhật đại lý thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SHIT", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
