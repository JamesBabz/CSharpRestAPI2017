using System;
using System.Collections.Generic;
using System.Text;
using VideoAppBLL.BusinessObjects;

namespace VideoAppBLL
{
    public interface IGenreService
    {
        //C
        GenreBO Create(GenreBO genre);

        //R
        List<GenreBO> GetAll();
        List<GenreBO> Search(string query);
        GenreBO GetById(int id);

        //U
        GenreBO Update(GenreBO genre);

        //D
        GenreBO Delete(int id);
    }
}
