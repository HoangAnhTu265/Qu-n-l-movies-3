using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Quản_lý_movies_3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private ExamEntities1 movieService = new ExamEntities1();

        public void Add(Movie m)
        {
            movieService.Movies.Add(m);
            movieService.SaveChanges();
        }

        public void Delete(int Id)
        {
            Movie m = (from a in movieService.Movies
                       where a.MovieId == Id
                       select a).FirstOrDefault();
            movieService.Movies.Remove(m);
            movieService.SaveChanges();
        }

        public void Edit(Movie item)
        {
            movieService.Entry(item).State = EntityState.Modified;


            movieService.SaveChanges();
        }

        public List<Movie> getAll()
        {
            return movieService.Movies.ToList();
        }
    }
}
