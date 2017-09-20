using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class GenreBO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<VideoBO> Videos { get; set; }
    }
}
