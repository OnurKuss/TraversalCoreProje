using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager:ISubAboutService
    {
        ISubAboutDal _aboutDal;

        public SubAboutManager(ISubAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(SubAbout t)
        {
            _aboutDal.Insert(t);
        }

        public void TUpdate(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> TGetList()
        {
            return _aboutDal.GetList();
        }

        public SubAbout TGetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
