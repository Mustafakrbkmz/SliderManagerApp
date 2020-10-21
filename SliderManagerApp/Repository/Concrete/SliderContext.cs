using Microsoft.EntityFrameworkCore;
using SliderManagerApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SliderManagerApp.Repository.Concrete
{
    public class SliderContext : DbContext
    {
        public SliderContext(DbContextOptions<SliderContext> options)
             : base(options)
        {   
        }

        public DbSet<Slider> Sliders { get; set; }
        

    }
}
