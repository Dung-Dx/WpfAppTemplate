using Microsoft.EntityFrameworkCore;
using WpfAppTemplate.Models;

namespace WpfAppTemplate.Helpers
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedQuan(modelBuilder);
            SeedLoaiDaiLy(modelBuilder);
            SeedDaiLy(modelBuilder);
        }

        private static void SeedQuan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quan>().HasData(
                new Quan { MaQuan = 1, TenQuan = "Quận 1" },
                new Quan { MaQuan = 2, TenQuan = "Quận 2" },
                new Quan { MaQuan = 3, TenQuan = "Quận 3" },
                new Quan { MaQuan = 4, TenQuan = "Quận 4" },
                new Quan { MaQuan = 5, TenQuan = "Quận 5" },
                new Quan { MaQuan = 6, TenQuan = "Quận 6" },
                new Quan { MaQuan = 7, TenQuan = "Quận 7" },
                new Quan { MaQuan = 8, TenQuan = "Quận 8" },
                new Quan { MaQuan = 9, TenQuan = "Quận 9" },
                new Quan { MaQuan = 10, TenQuan = "Quận 10" },
                new Quan { MaQuan = 11, TenQuan = "Quận 11" },
                new Quan { MaQuan = 12, TenQuan = "Quận 12" },
                new Quan { MaQuan = 13, TenQuan = "Quận Bình Thạnh" },
                new Quan { MaQuan = 14, TenQuan = "Quận Tân Bình" },
                new Quan { MaQuan = 15, TenQuan = "Quận Tân Phú" },
                new Quan { MaQuan = 16, TenQuan = "Quận Phú Nhuận" },
                new Quan { MaQuan = 17, TenQuan = "Quận Gò Vấp" },
                new Quan { MaQuan = 18, TenQuan = "Quận Thủ Đức" },
                new Quan { MaQuan = 19, TenQuan = "Huyện Củ Chi" },
                new Quan { MaQuan = 20, TenQuan = "Huyện Hóc Môn" }
            );
        }

        private static void SeedLoaiDaiLy(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiDaiLy>().HasData(
                new LoaiDaiLy { MaLoaiDaiLy = 1, TenLoaiDaiLy = "Đại lý loại 1", NoToiDa = 20000 },
                new LoaiDaiLy { MaLoaiDaiLy = 2, TenLoaiDaiLy = "Đại lý loại 2", NoToiDa = 50 }
            );
        }

        private static void SeedDaiLy(ModelBuilder modelBuilder)
        {
            var seedDate = new DateTime(2023, 1, 1);
            modelBuilder.Entity<DaiLy>().HasData(
                // 1-4: Original dai ly
                new
                {
                    MaDaiLy = 1,
                    TenDaiLy = "Đại lý Minh Phát",
                    MaLoaiDaiLy = 1,
                    MaQuan = 1,
                    DiaChi = "12 Nguyễn Huệ",
                    DienThoai = "0901234567",
                    Email = "MinhPhat@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-3),
                    TienNo = 5000000L
                },
                new
                {
                    MaDaiLy = 2,
                    TenDaiLy = "Đại lý Hoàng Gia",
                    MaLoaiDaiLy = 2,
                    MaQuan = 2,
                    DiaChi = "45 Lê Lợi",
                    DienThoai = "0912345678",
                    Email = "HoangGia@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-2),
                    TienNo = 3000000L
                },
                new
                {
                    MaDaiLy = 3,
                    TenDaiLy = "Đại lý Thịnh Vượng",
                    MaLoaiDaiLy = 1,
                    MaQuan = 3,
                    DiaChi = "78 Nguyễn Trãi",
                    DienThoai = "0923456789",
                    Email = "ThinhVuong@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-4),
                    TienNo = 7000000L
                },
                new
                {
                    MaDaiLy = 4,
                    TenDaiLy = "Đại lý Thành Công",
                    MaLoaiDaiLy = 2,
                    MaQuan = 4,
                    DiaChi = "32 Lý Tự Trọng",
                    DienThoai = "0934567890",
                    Email = "ThanhCong@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-1),
                    TienNo = 2000000L
                },
                // 5-14: Additional dai ly
                new
                {
                    MaDaiLy = 5,
                    TenDaiLy = "Đại lý Tân Tiến",
                    MaLoaiDaiLy = 1,
                    MaQuan = 5,
                    DiaChi = "56 Trần Hưng Đạo",
                    DienThoai = "0945678901",
                    Email = "TanTien@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-5),
                    TienNo = 8500000L
                },
                new
                {
                    MaDaiLy = 6,
                    TenDaiLy = "Đại lý Phát Đạt",
                    MaLoaiDaiLy = 2,
                    MaQuan = 6,
                    DiaChi = "123 Nguyễn Văn Cừ",
                    DienThoai = "0956789012",
                    Email = "PhatDat@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-6),
                    TienNo = 4200000L
                },
                new
                {
                    MaDaiLy = 7,
                    TenDaiLy = "Đại lý Kim Cương",
                    MaLoaiDaiLy = 1,
                    MaQuan = 7,
                    DiaChi = "87 Nguyễn Thị Minh Khai",
                    DienThoai = "0967890123",
                    Email = "KimCuong@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-7),
                    TienNo = 12000000L
                },
                new
                {
                    MaDaiLy = 8,
                    TenDaiLy = "Đại lý Hoàng Long",
                    MaLoaiDaiLy = 1,
                    MaQuan = 8,
                    DiaChi = "245 Hai Bà Trưng",
                    DienThoai = "0978901234",
                    Email = "HoangLong@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-2),
                    TienNo = 3500000L
                },
                new
                {
                    MaDaiLy = 9,
                    TenDaiLy = "Đại lý Bình Minh",
                    MaLoaiDaiLy = 2,
                    MaQuan = 9,
                    DiaChi = "67 Phan Đình Phùng",
                    DienThoai = "0989012345",
                    Email = "BinhMinh@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-3),
                    TienNo = 1800000L
                },
                new
                {
                    MaDaiLy = 10,
                    TenDaiLy = "Đại lý Trường Thịnh",
                    MaLoaiDaiLy = 2,
                    MaQuan = 10,
                    DiaChi = "34 Lê Thánh Tôn",
                    DienThoai = "0990123456",
                    Email = "TruongThinh@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-8),
                    TienNo = 6700000L
                },
                new
                {
                    MaDaiLy = 11,
                    TenDaiLy = "Đại lý Tấn Phát",
                    MaLoaiDaiLy = 1,
                    MaQuan = 11,
                    DiaChi = "189 Điện Biên Phủ",
                    DienThoai = "0901234567",
                    Email = "TanPhat@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-4),
                    TienNo = 15000000L
                },
                new
                {
                    MaDaiLy = 12,
                    TenDaiLy = "Đại lý Quang Minh",
                    MaLoaiDaiLy = 1,
                    MaQuan = 12,
                    DiaChi = "76 Võ Văn Tần",
                    DienThoai = "0912345678",
                    Email = "QuangMinh@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-9),
                    TienNo = 4300000L
                },
                new
                {
                    MaDaiLy = 13,
                    TenDaiLy = "Đại lý Hưng Thịnh",
                    MaLoaiDaiLy = 2,
                    MaQuan = 13,
                    DiaChi = "54 Cách Mạng Tháng 8",
                    DienThoai = "0923456789",
                    Email = "HungThinh@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-5),
                    TienNo = 2100000L
                },
                new
                {
                    MaDaiLy = 14,
                    TenDaiLy = "Đại lý Phú Quý",
                    MaLoaiDaiLy = 2,
                    MaQuan = 14,
                    DiaChi = "112 Nguyễn Du",
                    DienThoai = "0934567890",
                    Email = "PhuQuy@gmail.com",
                    NgayTiepNhan = seedDate.AddMonths(-10),
                    TienNo = 9800000L
                }
            );
        }
    }
}
