using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SliderManagerApp.Models;
using SliderManagerApp.Repository.Abstract;

namespace SliderManagerApp.Controllers
{
    public class HomeController : Controller
    {

        private ISliderRepository _sliderRepository;
        public HomeController( ISliderRepository sliderRepo)
        {
            _sliderRepository = sliderRepo;
        }

        public IActionResult Index()
        {
            return View(_sliderRepository.Find(s=>s.IsApproved==true && DateTime.Now<s.FinishDate && DateTime.Now>s.StartingDate)); //Yalnız onaylı ve belirlediğimiz tarih aralığındaki sliderları View'deki modele gönderiyoruz.
        }


    }
}
