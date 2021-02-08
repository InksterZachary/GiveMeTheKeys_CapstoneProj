using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        
            public ImageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
            {
            }
            public Image GetImage(int imageId) => FindByCondition(c => c.ImageId.Equals(imageId)).SingleOrDefault();
            public Image GetImage(string imageId) => FindByCondition(c => c.ImageId.Equals(imageId)).SingleOrDefault();
            public IQueryable<Image> GetAllImages(int imageId) => FindByCondition(c => c.ListingId.Equals(imageId));
            public void CreateImage(Image image) => Create(image);
            public void EditImage(Image image) => Update(image);
            public void DeleteImage(Image image) => Delete(image);
        
    }
}
