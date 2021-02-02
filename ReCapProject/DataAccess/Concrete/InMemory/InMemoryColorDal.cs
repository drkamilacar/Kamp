using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ColorId = 1, ColorDescription = "Siyah"},
                new Color{ColorId = 2, ColorDescription = "Beyaz"},
                new Color{ColorId = 3, ColorDescription = "Gri"}
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(p => p.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetById(int colorId)
        {
            return _colors.Where(p => p.ColorId == colorId).ToList();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(p => p.ColorId == color.ColorId);
            colorToUpdate.ColorDescription = color.ColorDescription;
        }
    }
}
