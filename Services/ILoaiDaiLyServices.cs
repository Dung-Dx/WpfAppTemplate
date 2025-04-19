using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTemplate.Models;

namespace WpfAppTemplate.Services
{
    public interface ILoaiDaiLyServices
    {
        Task<LoaiDaiLy> GetLoaiDaiLyById(int id);
        Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLy();
        Task AddLoaiDaiLy(LoaiDaiLy loaiDaiLy);
        Task UpdateLoaiDaiLy(LoaiDaiLy loaiDaiLy);
        Task DeleteLoaiDaiLy(int id);
        Task<int> GenerateAvailableId();
    }
}
