﻿using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService
    {
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
        List<Color> GetAll();
        List<Color> GetColorsByColorId(int id);
        List<ColorDetailDto> GetColorDetails();
    }
}
