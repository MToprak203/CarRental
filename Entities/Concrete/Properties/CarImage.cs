using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Properties
{
    public class CarImage : IProperty
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public Nullable<DateTime> Date { get; set; }
    }
}
