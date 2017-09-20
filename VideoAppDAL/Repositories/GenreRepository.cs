using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class GenreRepository : IGenreRepository
    {
        VideoAppContext _context;
        public GenreRepository(VideoAppContext context)
        {
            _context = context;
        }

        public Genre Create(Genre genre)
        {
            _context.Genres.Add(genre);
            return genre;
        }

        public Genre Delete(int id)
        {
            var genre = GetById(id);
            _context.Genres.Remove(genre);
            return genre;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.Include(g => g.Videos).ToList();
        }

        public Genre GetById(int id)
        {
            return _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public List<Genre> Search(string query)
        {
            return GetAll().Where(x => x.Name.ToLower().Contains(query)).ToList();
        }
    }
}
