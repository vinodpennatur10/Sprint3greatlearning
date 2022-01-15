using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class TaskEFModel
    {

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Status { get; set; }
        public int AssignedUserId { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
