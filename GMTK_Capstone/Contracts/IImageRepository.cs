using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IImageRepository : IRepositoryBase<Image>
    {
        Image GetImage(int imageId);
        Image GetImage(string imageId);
        void CreateImage(Image image);
        void EditImage(Image image);
        void DeleteImage(Image image);
        IQueryable<Image> GetAllImages(int imageId);
    }
}
