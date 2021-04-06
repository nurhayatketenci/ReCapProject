using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public int CUsersId { get; set; }
        public string CompanyName { get; set; }
        public int FindexPuan { get; set; }
      
    }
}
