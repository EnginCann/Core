using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cus in context.Customers
                             on r.CustomerId equals cus.UserId
                             join u in context.Users
                             on cus.UserId equals u.Id
                             select new RentalDetailDto()
                             {
                                 RentalId = r.Id,
                                 CarName = c.Description,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();

            }



        }

    }
}

