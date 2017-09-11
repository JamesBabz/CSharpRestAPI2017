using System.Collections.Generic;
using System.Linq;
using VideoAppDAL.Entities;

namespace VideoAppDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();

        public Video Create(Video video)
        {
            Video newVideo;
            Videos.Add(newVideo = new Video()
            {
                Id = Id++,
                Name = video.Name,
                Price = video.Price
            });
            return newVideo;
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }

        public List<Video> Search(string query)
        {
            return GetAll().Where(x => x.Name.ToLower().Contains(query)).ToList();
        }

        public Video GetById(int id)
        {
            return Videos.FirstOrDefault(x => x.Id == id);
        }

        public Video Delete(int id)
        {
            var videoFound = GetById(id);
            Videos.Remove(videoFound);
            return videoFound;
        }
    }
}
