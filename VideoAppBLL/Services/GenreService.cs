using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoAppBLL.BusinessObjects;
using VideoAppBLL.Converters;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    class GenreService : IGenreService
    {
        GenreConverter converter = new GenreConverter();
        private DALFacade _facade;
        public GenreService(DALFacade facade)
        {
            _facade = facade;
        }

        public GenreBO Create(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
               var genreEntity =  uow.GenreRepository.Create(converter.Convert(genre));
                uow.Complete();
                return converter.Convert(genreEntity);
            }
        }

        public GenreBO Delete(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreEntity = uow.GenreRepository.Delete(id);
                uow.Complete();
                return converter.Convert(genreEntity);
            }
        }

        public List<GenreBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAll().Select(converter.Convert).ToList();
            }
        }

        public GenreBO GetById(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return converter.Convert(uow.GenreRepository.GetById(id));
            }
        }

        public List<GenreBO> Search(string query)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GenreRepository.Search(query).Select(converter.Convert).ToList();
            }
        }

        public GenreBO Update(GenreBO genre)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var genreFromDb = uow.GenreRepository.GetById(genre.Id);
                if (genreFromDb == null)
                {
                    throw new InvalidOperationException("Genre not found");
                }
                genreFromDb.Name = genre.Name;
                uow.Complete();
                return converter.Convert(genreFromDb);
            }
        }
    }
}
