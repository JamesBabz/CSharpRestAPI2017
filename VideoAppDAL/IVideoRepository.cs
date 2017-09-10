using System.Collections.Generic;
using VideoAppEntity;

namespace VideoAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video video);

        //R
        List<Video> GetAll();
        List<Video> Search(string query);
        Video GetById(int id);

        //D
        Video Delete(int id);
    }
}
