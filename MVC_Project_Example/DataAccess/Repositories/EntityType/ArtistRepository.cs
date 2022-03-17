using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC_Project_Example.DataAccess.Repositories.EntityType
{
    public class ArtistRepository : IBaseRepository<Artist>
    {
        MusicAppDbEntities db = new MusicAppDbEntities();

        public void Create(Artist entity)
        {
            entity.Status = 1;
            entity.CreateDate = DateTime.Now;
            db.Artists.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Artist entity)
        {
            db.SaveChanges();
        }

        public Artist GetEntity(Expression<Func<Artist, bool>> exp)
        {
            return db.Artists.FirstOrDefault(exp);
        }

        public List<Artist> GetEntities(Expression<Func<Artist, bool>> exp)
        {
            return db.Artists.Where(exp).ToList();
        }

        public void Update(Artist entity)
        {
            db.SaveChanges();
        }
    }
}