﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByAcceptedl(int id);
        List<Reservation> GetListWithReservationByPrevious(int id);
    }
}
