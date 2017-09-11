using System;
using System.Collections.Generic;
using System.Text;
using VideoAppDAL.Entities;

namespace VideoAppDAL
{
    public interface IGenreRepository
    {
        //C
        Genre Create(Genre genre);

        //R
        List<Genre> GetAll();
        List<Genre> Search(string query);
        Genre GetById(int id);

        //D
        Genre Delete(int id);
    }
}
