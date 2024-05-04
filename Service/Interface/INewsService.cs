using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface INewsService
    {
        Task<List<NewsDTO>> GetAll();
        Task<bool> Create(NewsDTO news);
        Task<bool> Update(NewsDTO news);
        Task<bool> Delete(Guid id);
    }
}
