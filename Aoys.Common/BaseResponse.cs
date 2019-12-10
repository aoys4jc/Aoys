using System;

namespace Aoys.Common
{
    public class BaseResponse
    {
        public ResultType Result { get; set; }
        public string Message { get; set; }

        public int Code { get; set; }

        public object Content { get; set; }
    }

    /// <summary>
    /// 结果类型
    /// </summary>
    public enum ResultType
    {        
        Unknown = 0,
        
        Success = 1,
        
        Failure = 2,
        
        Exception = 3,
        
        Resubmit = 4,
    }
}
