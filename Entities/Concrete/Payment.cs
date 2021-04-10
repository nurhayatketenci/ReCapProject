using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CUsersId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
