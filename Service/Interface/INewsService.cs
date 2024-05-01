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
        Task<bool> Create(string title, string description, string image, DateTime date, string source, Guid teamId);
        Task<bool> Update(Guid id, string title, string description, string image, DateTime date, string source, Guid teamId);
    }
}
