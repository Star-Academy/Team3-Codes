using System;
using Nest;

namespace SearchNest.Utils.Nest
{
    public class ResponseValidator
    {
        public static void handleException(IResponse response)
        {
            if (!response.IsValid)
                Console.WriteLine(response.OriginalException.Message);
        }
    }
}