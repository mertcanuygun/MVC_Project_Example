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
    public class ArtistController : Controller
    {
        ArtistRepository artistRepository = new ArtistRepository();

        // GET: Artist
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ArtistCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                Artist artist = new Artist();
                artist.FirstName = model.FirstName;
                artist.LastName = model.LastName;
                artistRepository.Create(artist);
                return RedirectToAction("List");
            }
            else
                return View(model);
        }

        public ActionResult List()
        {
            IEnumerable<ArtistVM> artists = artistRepository.GetEntities(x => x.Status != 2)
                                         .Select(x => new ArtistVM
                                         {
                                             Id = x.Id,
                                             FirstName = x.FirstName,
                                             LastName = x.LastName,
                                         });
            return View(artists);
        }

        public ActionResult Details(int id)
        {
            Artist artist = artistRepository.GetEntity(x => x.Id == id);
            ArtistVM artistVM = new ArtistVM();

            artistVM.Id = artist.Id;
            artistVM.FirstName = artist.FirstName;
            artistVM.LastName = artist.LastName;
            artistVM.CreateDate = artist.CreateDate;
            artistVM.Status = 1;
            
            return View(artistVM);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Artist artist = artistRepository.GetEntity(x=> x.Id == id);
            ArtistUpdateDTO artistUpdateDTO = new ArtistUpdateDTO();

            artistUpdateDTO.Id = artist.Id;
            artistUpdateDTO.FirstName = artist.FirstName;
            artistUpdateDTO.LastName = artist.LastName;
            
            return View(artistUpdateDTO);
        }

        [HttpPost]
        public ActionResult Update(ArtistUpdateDTO model)
        {
            Artist artist = artistRepository.GetEntity(x=> x.Id == model.Id);
            
            artist.FirstName = model.FirstName;
            artist.LastName = model.LastName;
            artist.UpdateDate = DateTime.Now;
            artist.Status = 1;

            artistRepository.Update(artist);

            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {

            Artist artist = artistRepository.GetEntity(x=>x.Id == id);

            artist.Status = 2;
            artist.DeleteDate = DateTime.Now;

            artistRepository.Delete(artist);

            return RedirectToAction("List");
        }

        public ActionResult DeletedItems()
        {
            IEnumerable<ArtistVM> artists = artistRepository.GetEntities(x => x.Status == 2)
                                         .Select(x => new ArtistVM
                                         {
                                             Id = x.Id,
                                             FirstName = x.FirstName,
                                             LastName = x.LastName,
                                             DeleteDate = DateTime.Now,
                                         });
            return View(artists);
        }
    }
}