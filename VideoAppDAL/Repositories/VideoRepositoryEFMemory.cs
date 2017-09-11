using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppDAL.Context;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        private VideoAppContext _context;

        public VideoRepositoryEFMemory(VideoAppContext context)
        {
            _context = context;
        }

        public Video Create(Video video)
        {
            _context.Videoes.Add(video);
            return video;
        }

        public List<Video> GetAll()
        {
            return _context.Videoes.ToList();
        }

        public List<Video> Search(string query)
        {
            return GetAll().Where(x => x.Name.ToLower().Contains(query)).ToList();
        }

        public Video GetById(int id)
        {
            return _context.Videoes.FirstOrDefault(x => x.Id == id);
        }

        public Video Delete(int id)
        {
            var video = GetById(id);
            _context.Videoes.Remove(video);
            return video;
        }
    }
}