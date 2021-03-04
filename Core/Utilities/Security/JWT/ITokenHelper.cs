using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {

        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }
}
