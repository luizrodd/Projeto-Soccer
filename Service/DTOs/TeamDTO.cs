﻿using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class TeamDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<NewsDTO> NewsList { get; set; } = new List<NewsDTO>();
        public Guid ChampionshipId { get; set; }
    }
}
