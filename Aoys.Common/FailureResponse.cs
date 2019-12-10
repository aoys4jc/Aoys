using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Aoys.Common
{
   public class FailureResponse:BaseResponse
    {
        public FailureResponse(string msg)
        {
            Result = ResultType.Failure;
            Code = (int)HttpStatusCode.ExpectationFailed;
            Message = msg;
        }
    }
}
