using System;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal: EfEntityRepositoryBase<CarImage, ReCapProjectContext>, ICarImageDal
    {
        
    }
}
