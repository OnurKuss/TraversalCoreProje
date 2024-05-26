using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class GuideManager:IGuideService
    {
        IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void TAdd(Guide t)
        {
            _guideDal.Insert(t);
        }

        public void TUpdate(Guide t)
        {
            _guideDal.Update(t);
        }

        public void TDelete(Guide t)
        {
            _guideDal.Delete(t);
        }

        public List<Guide> TGetList()
        {
            return _guideDal.GetList();
        }

        public Guide TGetByID(int id)
        {
            return _guideDal.GetByID(id);
        }

        public void ChangeToStatusGuide(int id)
        {
            _guideDal.ChangeToStatusGuide(id);
        }
    }
}
