using SliderManagerApp.Entity;
using SliderManagerApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SliderManagerApp.Repository.Concrete
{
    public class EfSliderRepository : EfGenericRepository<Slider>, ISliderRepository
    {
        public EfSliderRepository(SliderContext context) : base(context)
        {
        }
    }
}
