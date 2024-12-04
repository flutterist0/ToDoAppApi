using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ToDoUpdateDto:IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
  
    }
}
