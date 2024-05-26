using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection service)
        {
            service.AddScoped<ICommentService, CommentManager>();
            service.AddScoped<ICommentDal, EfCommentDal>();
            service.AddScoped<IDestinationService, DestinationManager>();
            service.AddScoped<IDestinationDal, EfDestinationDal>();
            service.AddScoped<IAppUserService, AppUserManager>();
            service.AddScoped<IAppUserDal, EfAppUserDal>();
            service.AddScoped<IReservationService, ReservationManager>();
            service.AddScoped<IReservationDal, EfReservationDal>();
            service.AddScoped<IGuideService, GuideManager>();
            service.AddScoped<IGuideDal, EfGuideDal>();
            service.AddScoped<IExcelService, ExcelManager>();
            service.AddScoped<IPdfService, PdfManager>();
        }
    }
}
