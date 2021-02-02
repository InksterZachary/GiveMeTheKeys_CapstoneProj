using GMTK_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMTK_Capstone.Contracts
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Review GetReview(int reviewId);
        void CreateReview(Review review);
        void EditReview(Review review);
        void DeleteReview(Review review);
    }
}
