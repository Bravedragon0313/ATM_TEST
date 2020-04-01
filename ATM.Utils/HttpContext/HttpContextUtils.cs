namespace ATM.Utils.HttpContext
{
    /// <summary>
    /// HttpContextUtils
    /// </summary>
    public static class HttpContextUtils
    {
        /// <summary>
        /// CommonDataResponse
        /// </summary>
        public class CommonDataResponse
        {
            public CommonDataResponse()
            {
                Message = string.Empty;
                Data = null;
                IsError = false;
            }

            public object Data { get; set; }
            public bool IsError { get; set; }
            public string Message { get; set; }
        }
    }
}
