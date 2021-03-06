﻿using VideoAppBLL.BusinessObjects;
using VideoAppDAL.Entities;

namespace VideoAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            if(vid == null) { return null; }
            return new Video()
            {
                Id = vid.Id,
                Name = vid.Name,
                Price = vid.Price,
                GenreId = vid.GenreId
            };
        }
        internal VideoBO Convert(Video vid)
        {
            if (vid == null) { return null; }
            return new VideoBO()
            {
                Id = vid.Id,
                Name = vid.Name,
                Price = vid.Price,
                Genre = new GenreConverter().Convert(vid.Genre),
                GenreId = vid.GenreId
            };
        }

    }
}
