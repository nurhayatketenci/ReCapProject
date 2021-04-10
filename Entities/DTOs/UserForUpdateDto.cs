using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForUpdateDto : UserForRegisterDto, IDto
    {
        public int UserId { get; set; }
    }
}
