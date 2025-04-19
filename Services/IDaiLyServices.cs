using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTemplate.Models;

namespace WpfAppTemplate.Services
{
    public interface IDaiLyServices
    {
        Task<IEnumerable<DaiLy>> GetAllDaiLy();
        Task DeleteDaiLy(int id);
        Task AddDaiLy(DaiLy daiLy);
        Task<int> GenerateAvailableId();
        Task<DaiLy> GetDaiLyById(int id);
        Task UpdateDaiLy(DaiLy daiLy);
    }
}
