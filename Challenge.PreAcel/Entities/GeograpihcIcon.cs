using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.PreAcel.Entities
{
    public class GeograpihcIcon
    {

        public int Id { get; set; }

        public string Image { get; set; }

        public string Denomination { get; set; }

        public DateTime GetDate { get; set; }

        public int Height { get; set; }
         

        public string History { get; set; }

        public City city { get; set; }


    }
}
