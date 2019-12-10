using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Aoys.Common
{
   public class SuccessResponse:BaseResponse
    {
        public SuccessResponse(object content=null)
        {
            Result = ResultType.Success;
            Code = (int)HttpStatusCode.OK;
            Message = "执行成功";
            Content = content;
        }
    }
}
