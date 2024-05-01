using Domain.Entitites;
using Infra;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NewsService(TemplateContext data) : INewsService
    {
        private readonly TemplateContext _data = data;

        public async Task<bool> Create(string title, string description, string image, DateTime date, string source, Guid teamId)
        {
            News news = new News()
            {
                Date = date,
                Title = title,
                Description = description,
                Image = image,
                Source = source,
                TeamId = teamId
            };

            await _data.News.AddAsync(news);
            _data.SaveChanges();
            return true;
        }

        public async Task<List<NewsDTO>> GetAll()
        {
            var news = await _data.News.Select(s => new NewsDTO()
            {
                Date = s.Date,
                Title = s.Title,
                Description = s.Description,
                Image = s.Image,
                Source = s.Source,
                TeamId = s.TeamId,
            }).ToListAsync();

            return news;
        }

        public Task<bool> Update(Guid id, string title, string description, string image, DateTime date, string source, Guid teamId)
        {
            throw new NotImplementedException();
        }
    }
}
