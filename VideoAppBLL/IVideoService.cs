using System;
using System.Collections.Generic;
using System.Text;
using VideoAppEntity;

namespace VideoAppBLL
{
    public interface IVideoService
    {
        //C
        Video Create(Video video);
        List<Video> AddVideos(List<Video> video);

        //R
        List<Video> GetAll();
        List<Video> Search(string query);
        Video GetById(int id);

        //U
        Video Update(Video video);

        //D
        Video Delete(int id);
    }
}