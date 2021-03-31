using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
     public  class CreditCart:IEntity
    {
        public int Id { get; set; }
        public string NameOnTheCard { get; set; }
        public int CardNumber { get; set; }
        public int CardCvv { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int  TotalMoney { get; set; }
    }
}
