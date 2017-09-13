using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VideoAppBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        [Required]
        [MinLength (2)]
        [MaxLength (20)]
        public string Name { get; set; }
        public float Price { get; set; }

        public int GenreId { get; set; }
        public GenreBO Genre { get; set; }
    }
}
