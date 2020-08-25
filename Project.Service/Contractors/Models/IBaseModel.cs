using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Contractors.Models
{
    public interface IBaseModel
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
