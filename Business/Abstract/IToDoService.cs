using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        IResult Add(int userId, ToDo toDo);
        IResult Delete(int userId,int toDoId);
        IDataResult<List<ToDo>> GetAll(int userId);
        IDataResult<ToDo> Get(int userId,int toDoId);
        IResult Update(int userId,ToDo toDo,int toDoId);
    }
}
