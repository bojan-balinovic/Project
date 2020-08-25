using Project.Service.Contractors.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Models
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
