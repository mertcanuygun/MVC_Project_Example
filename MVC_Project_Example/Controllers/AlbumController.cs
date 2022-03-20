using MVC_Project_Example.DataAccess.Repositories.EntityType;
using MVC_Project_Example.Models.DTO;
using MVC_Project_Example.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project_Example.Controllers
{
    public class AlbumController : Controller
    {
        AlbumRepository albumRepository = new AlbumRepository();

        // GET: Album
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AlbumCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                Album album = new Album();
                album.Name = model.Name;
                album.TotalTrack = model.TotalTrack;
                album.ArtistId = model.ArtistId;
                albumRepository.Create(album);

                return RedirectToAction("List");
            }
            else
                return View(model);
        }

        public ActionResult List()
        {
            IEnumerable<AlbumVM> albums = albumRepository.GetEntities(x => x.Status != 2)
                                         .Select(x => new AlbumVM
                                         {
                                             Id = x.Id,
                                             Name = x.Name,
                                             TotalTrack = x.TotalTrack,
                                             ArtistId = x.ArtistId,
                                         });
            return View(albums);
        }

        public ActionResult Details(int id)
        {
            Album album = albumRepository.GetEntity(x => x.Id == id);
            AlbumVM albumVM = new AlbumVM();

            albumVM.Id = album.Id;
            albumVM.Name = album.Name;
            albumVM.TotalTrack = album.TotalTrack;
            albumVM.ArtistId = album.ArtistId;
            albumVM.CreateDate = album.CreateDate;
            albumVM.UpdateDate = album.UpdateDate;
            albumVM.DeleteDate = album.DeleteDate;
            albumVM.Status = album.Status;

            return View(albumVM);
        }
    }
}