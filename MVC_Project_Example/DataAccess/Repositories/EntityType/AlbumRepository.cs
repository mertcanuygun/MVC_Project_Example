using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_Project_Example.DataAccess.Repositories.EntityType
{
    public class AlbumRepository : IBaseRepository<Album>
    {
        MusicAppDbEntities db = new MusicAppDbEntities();
        public void Create(Album entity)
        {
            entity.Status = 1;
            entity.CreateDate = DateTime.Now;
            db.Albums.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Album entity)
        {
            db.SaveChanges();
        }

        public List<Album> GetEntities(Expression<Func<Album, bool>> exp)
        {
            return db.Albums.Where(exp).ToList();
        }

        public Album GetEntity(Expression<Func<Album, bool>> exp)
        {
            return db.Albums.FirstOrDefault(exp);
        }

        public void Update(Album entity)
        {
            db.SaveChanges();
        }
    }
}