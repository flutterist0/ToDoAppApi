using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IToDoService
    {
        IDataResult<ToDo> Add(ToDoAddDto toDoAddDto);
        IResult Delete(int userId,int toDoId);
        IResult CompleteTask(int userId, int toDoId, bool isComplated);
        IDataResult<List<ToDo>> GetAll();
        IDataResult<List<ToDo>> GetAllByIsComplated(int userId);
        IDataResult<List<ToDo>> GetAllByUserId(int userId);
        IDataResult<ToDo> Get(int userId,int toDoId);
        IResult Update(int userId,ToDoUpdateDto toDoUpdateDto, int toDoId);
    }
}
