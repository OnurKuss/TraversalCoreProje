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
    public class CommentManager:ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }
        public List<Comment> TGetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x=> x.DestinationID == id);
        }
        public Comment TGetByID(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }
    }
}
