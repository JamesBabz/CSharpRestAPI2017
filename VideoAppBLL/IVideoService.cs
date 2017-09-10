using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObject;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO video);
        List<VideoBO> AddVideos(List<VideoBO> video);

        //R
        List<VideoBO> GetAll();
        List<VideoBO> Search(string query);
        VideoBO GetById(int id);

        //U
        VideoBO Update(VideoBO video);

        //D
        VideoBO Delete(int id);
    }
}