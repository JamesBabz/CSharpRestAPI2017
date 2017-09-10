using VideoAppBLL.BusinessObject;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Name = vid.Name,
                Genre = vid.Genre
            };
        }
        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                Name = vid.Name,
                Genre = vid.Genre
            };
        }

    }
}
