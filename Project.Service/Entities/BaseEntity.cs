using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
