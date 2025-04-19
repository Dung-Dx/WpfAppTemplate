using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTemplate.Models;

namespace WpfAppTemplate.Services
{
    public interface IQuanServices
    {
        Task<Quan> GetQuanById(int id);
        Task<IEnumerable<Quan>> GetAllQuan();
        Task AddQuan(Quan quan);
        Task UpdateQuan(Quan quan);
        Task DeleteQuan(int id);
        Task<int> GetSoLuongDaiLyTrongQuan(int id);
        Task<int> GenerateAvailableId();
    }
}
