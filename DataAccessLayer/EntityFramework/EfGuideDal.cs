using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        Context context = new Context();
        public void ChangeToStatusGuide(int id)
        {
            var value = context.Guides.Find(id);
            if (value.Status)
            {
                value.Status = false;
            }
            else
            {
                value.Status=true;
            }

            context.SaveChanges();
        }
    }
}
