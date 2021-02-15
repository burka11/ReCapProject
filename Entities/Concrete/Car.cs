﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }

        public short ModelYear { get; set; }

        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }

    }
}
