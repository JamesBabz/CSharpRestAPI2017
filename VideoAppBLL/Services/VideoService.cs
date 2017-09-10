using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using VideoAppDAL;
using VideoAppEntity;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        private DALFacade facade;

        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(video);
                uow.Complete();
                return newVideo;
            }
        }

       

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public List<Video> Search(string query)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Search(query);
            }
        }

        public Video GetById(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetById(id);
            }
        }

        public Video Update(Video video)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.GetById(video.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found");
                }
                videoFromDb.Name = video.Name;
                videoFromDb.Genre = video.Genre;
                uow.Complete();
                return videoFromDb;
            }
        }

        public Video Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(id);
                uow.Complete();
                return newVideo;
            }
        }

        public List<Video> AddVideos(List<Video> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.Create(video);
                }
                uow.Complete();
            }
            return videos;
        }

    }
}