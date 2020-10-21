using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SliderManagerApp.Entity;
using SliderManagerApp.Repository.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SliderManagerApp.Controllers
{
    public class AdminController : Controller
    {

        private ISliderRepository _sliderRepository;
        public AdminController(ISliderRepository sliderRepo)
        {
            _sliderRepository = sliderRepo;
        }
        public IActionResult SliderList()
        {
            return View(_sliderRepository.GetAll());
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(Slider entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var imgName = string.Format($"{file.FileName}_{DateTime.Now.Ticks}{extention}");
                    var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", imgName);
                    using (var stream = new FileStream(img, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.ImageURL = imgName;
                    }
                }
                _sliderRepository.Add(entity);
                _sliderRepository.Save();
                return RedirectToAction("SliderList", "Admin");
            }

            return View(entity);
        }

        [HttpGet]
        public IActionResult SliderEdit(int id)
        {
            var slider = _sliderRepository.Get(id);
            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(Slider entity, IFormFile file)
        {

            var slider = _sliderRepository.Get(entity.Id);
            if (slider != null)
            {
                slider.Title = entity.Title;
                slider.Description = entity.Description;
                slider.StartingDate = entity.StartingDate;
                slider.FinishDate = entity.FinishDate;
                slider.CreateDate = entity.CreateDate;
                slider.IsApproved = entity.IsApproved;

                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var imgName = string.Format($"{file.FileName}_{DateTime.Now.Ticks}{extention}");
                    var img = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", imgName);

                    using (var stream = new FileStream(img, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.ImageURL = imgName;
                    }
                }
                _sliderRepository.Update(slider);
                return RedirectToAction("Index", "Home");
            }
            return View(entity);
        }

        public IActionResult SliderDetail(int? id)
        {
            var slider = _sliderRepository.Find(s => s.Id == id).FirstOrDefault();
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        [HttpGet]
        public IActionResult SliderDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slider = _sliderRepository.Find(s => s.Id == id).FirstOrDefault();
            if (slider==null)
            {
                return NotFound();
            }
            return View(slider);
        }
        [HttpPost,ActionName("SliderDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult SliderDeleteConfirmed(int id)
        {
            var slider = _sliderRepository.Find(s => s.Id == id).FirstOrDefault();
            _sliderRepository.Delete(id);
            return RedirectToAction("SliderList", "Admin");
        }

    }
}
