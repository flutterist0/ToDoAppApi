using Business.Abstract;
using Core.Entities.Concrete;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ToDoManager(IToDoDal toDoDal, IUserDal userDal) : IToDoService
    {
        private readonly IUserDal _userDal = userDal;
        private readonly IToDoDal _toDoDal = toDoDal;
        public IDataResult<ToDo> Add(ToDoAddDto toDoAddDto)
        {
            if (toDoAddDto.Title.Length<3||toDoAddDto.Description.Length<3)
            {
                return new ErrorDataResult<ToDo>("Title ve ya Descriptionun uzunluqu 3 den boyukdur");
            }
            var toDo = new ToDo
            {
                Title = toDoAddDto.Title,
                Description = toDoAddDto.Description,
                IsComplated = false,
                UserId = toDoAddDto.UserId,
                CreatedAt = DateTime.Now,
                Id = toDoAddDto.ToDoId,
                
                
            };
            _toDoDal.Add(toDo);
            return new SuccessDataResult<ToDo>(toDo,"yarandi");
        }
        public IResult CompleteTask(int userId, int toDoId, bool isComplated)
        {
            var toDo = _toDoDal.Get(t => t.Id == toDoId && t.UserId == userId && t.IsDeleted == false);

            if (toDo == null)
            {
                return new ErrorResult("Task tapılmadı və ya artıq silinib.");
            }
            toDo.IsComplated = isComplated;
            toDo.IsDeleted = false;
            toDo.CreatedAt = DateTime.Now;
            _toDoDal.Update(toDo);
            return new SuccessResult("Task tamamlandı statusu yeniləndi.");
        }


        public IResult Delete(int userId, int toDoId)
        {
            ToDo deleteToDo = null;
            var toDo = _toDoDal.Get(t=>t.UserId==userId&&t.Id==toDoId);
            if (toDo==null)
            {
                return new ErrorResult("Task yoxdu");
            }
            deleteToDo = toDo;
            deleteToDo.IsDeleted = true;
            _toDoDal.Delete(deleteToDo);
            return new SuccessResult("Task silindi");
        }

        public IDataResult<ToDo> Get(int userId, int toDoId)
        {
            var result = _toDoDal.Get(t=>t.Id==toDoId&&t.UserId==userId);
            if (result != null)
                return new SuccessDataResult<ToDo>(result, "loaded");
            else return new ErrorDataResult<ToDo>(result, "tapilmadi");
        }

        public IDataResult<List<ToDo>> GetAll()
        {
            var result = _toDoDal.GetAll(t => t.IsDeleted == false);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ToDo>>(result);

            }
            else
                return new ErrorDataResult<List<ToDo>>("xeta baş verdi");
        }

        public IDataResult<List<ToDo>> GetAllByIsComplated(int userId)
        {
            var result = _toDoDal.GetAll(t => t.UserId == userId && t.IsDeleted == false&&t.IsComplated==true);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<ToDo>>(result);

            }
            else
                return new ErrorDataResult<List<ToDo>>("xeta baş verdi");
        }

        public IDataResult<List<ToDo>> GetAllByUserId(int userId)
        {
            var result = _toDoDal.GetAll(t=>t.UserId==userId&&t.IsDeleted==false);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<ToDo>>(result);

            }else
                return new ErrorDataResult<List<ToDo>>("xeta baş verdi");

        }

        public IResult Update(int userId, ToDoUpdateDto toDoUpdateDto,int toDoId)
        {
            var exsitingToDo = _toDoDal.Get(t=>t.Id==toDoId&&t.UserId==userId&&t.IsDeleted==false);
            if (exsitingToDo == null)
            {
                return new ErrorResult("Task not found");
            }
            exsitingToDo.Title = toDoUpdateDto.Title;   
            exsitingToDo.Description = toDoUpdateDto.Description;
            _toDoDal.Update(exsitingToDo);
            return new SuccessResult("Updated");
        }
    }
}
