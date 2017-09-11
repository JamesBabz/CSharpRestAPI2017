using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppBLL.Converters;
using VideoAppDAL;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter converter = new VideoConverter();
        private DALFacade _facade;

        public VideoService(DALFacade facade)
        {
            _facade = facade;
        }

        public VideoBO Create(VideoBO video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Create(converter.Convert(video));
                uow.Complete();
                return converter.Convert(newVideo);
            }
        }

       

        public List<VideoBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public List<VideoBO> Search(string query)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.VideoRepository.Search(query).Select(converter.Convert).ToList();
            }
        }

        public VideoBO GetById(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return converter.Convert(uow.VideoRepository.GetById(id));
            }
        }

        public VideoBO Update(VideoBO video)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.GetById(video.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                videoFromDb.Name = video.Name;
                videoFromDb.Price = video.Price;
                uow.Complete();
                return converter.Convert(videoFromDb);
            }
        }

        public VideoBO Delete(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.Delete(id);
                uow.Complete();
                return converter.Convert(newVideo);
            }
        }

        public List<VideoBO> AddVideos(List<VideoBO> videos)
        {
            using (var uow = _facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.Create(converter.Convert(video));
                }
                uow.Complete();
            }
            return videos;
        }

    }
}