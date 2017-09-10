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
        private InMemoryContext Context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.Context = context;
        }

        public Video Create(Video video)
        {
            Context.Videoes.Add(video);
            return video;
        }

        public List<Video> GetAll()
        {
            return Context.Videoes.ToList();
        }

        public List<Video> Search(string query)
        {
            return GetAll().Where(x => x.Name.ToLower().Contains(query) || x.Genre.ToLower().Contains(query)).ToList();
        }

        public Video GetById(int id)
        {
            return Context.Videoes.FirstOrDefault(x => x.Id == id);
        }

        public Video Delete(int id)
        {
            var video = GetById(id);
            Context.Videoes.Remove(video);
            return video;
        }
    }
}