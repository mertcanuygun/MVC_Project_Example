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
        ArtistRepository artistRepository = new ArtistRepository();

        // GET: Album
        [HttpGet]
        public ActionResult Add()
        {
            AlbumCreateDTO albumDTO = new AlbumCreateDTO();
            albumDTO.Artists = artistRepository.GetEntities(x => x.Status != 2).Select(x => new ArtistVM
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            });
            return View(albumDTO);
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
                                             ArtistName = x.Artist.FirstName+' '+x.Artist.LastName,
                                         });
            return View(albums);
        }

        public ActionResult Details(int id)
        {
            Album album = albumRepository.GetEntity(x => x.Id == id);
            AlbumDetailsVM albumVM = new AlbumDetailsVM();

            albumVM.Id = album.Id;
            albumVM.Name = album.Name;
            albumVM.TotalTrack = album.TotalTrack;
            albumVM.ArtistName = album.Artist.FirstName+' '+album.Artist.LastName;
            albumVM.CreateDate = album.CreateDate;
            albumVM.UpdateDate = album.UpdateDate;
            albumVM.DeleteDate = album.DeleteDate;
            albumVM.Status = album.Status;

            return View(albumVM);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Album album = albumRepository.GetEntity(x=> x.Id == id);
            AlbumUpdateDTO updateDTO = new AlbumUpdateDTO();

            updateDTO.Id = id;
            updateDTO.Name = album.Name;
            updateDTO.TotalTrack = album.TotalTrack;
            updateDTO.ArtistId = album.ArtistId;

            updateDTO.Artists = artistRepository.GetEntities(x => x.Status != 2).Select(x=> new ArtistVM { Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            });

            return View(updateDTO);
        }

        public ActionResult Update(AlbumUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                Album album = albumRepository.GetEntity(x => x.Id == model.Id);

                album.Name = model.Name;
                album.TotalTrack = model.TotalTrack;
                album.ArtistId = model.ArtistId;
                

                albumRepository.Update(album);

                return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            Album album = albumRepository.GetEntity(x=> x.Id == id);

            album.Status = 2;
            album.DeleteDate = DateTime.Now;

            albumRepository.Delete(album);

            return RedirectToAction("List");
        }

        public ActionResult DeletedItems()
        {
            IEnumerable<AlbumVM> albums = albumRepository.GetEntities(x => x.Status == 2)
                                         .Select(x => new AlbumVM
                                         {
                                             Id = x.Id,
                                             Name = x.Name,
                                             TotalTrack = x.TotalTrack,
                                             ArtistName = x.Artist.FirstName + ' ' + x.Artist.LastName,
                                             Status = x.Status,
                                         });
            return View(albums);
        }
    }
}