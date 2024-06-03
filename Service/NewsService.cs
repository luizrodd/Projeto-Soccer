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
        public async Task<bool> Create(NewsDTO news)
        {
            var createNews = new News(news.Title, news.Image, news.Source, news.TeamId) { Date = news.Date, Description = news.Description };

            await _data.News.AddAsync(createNews);
            _data.SaveChanges();
            return true;
        }

        public async Task<bool> Update(NewsDTO news)
        {
            var id = news.Id;

            var newsToUpdate = await _data.News.FindAsync(id);

            if (newsToUpdate == null)
            {
                return false;
            }

            newsToUpdate.Date = news.Date;
            newsToUpdate.Title = news.Title;
            newsToUpdate.Description = news.Description;
            newsToUpdate.Image = news.Image;
            newsToUpdate.Source = news.Source;
            newsToUpdate.TeamId = news.TeamId;

            await _data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var newsToDelete = await _data.News.FindAsync(id);

            if (newsToDelete == null)
                return false;

            _data.News.Remove(newsToDelete);
            await _data.SaveChangesAsync();

            return true;
        }
    }
}
