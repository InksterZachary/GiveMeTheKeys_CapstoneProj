using GMTK_Capstone.Contracts;
using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Data
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public Review GetReview(int reviewId) => FindByCondition(c => c.ReviewId.Equals(reviewId)).SingleOrDefault();
        public void CreateReview(Review review) => Create(review);
        public void EditReview(Review review) => Update(review);
        public void DeleteReview(Review review) => Delete(review);
    }
}
