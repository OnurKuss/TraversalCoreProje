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
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void TAdd(Destination t)
        {
            _destinationDal.Insert(t);
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.Update(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public List<Destination> TGetList()
        {
            return _destinationDal.GetList();
        }

        public Destination TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }
    }
}
