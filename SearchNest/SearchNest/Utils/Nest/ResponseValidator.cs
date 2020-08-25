using System;
using Nest;

namespace SearchNest.Utils.Nest
{
    public class ResponseValidator
    {
        public static void HandleException(IResponse response)
        {
            if (!response.IsValid)
                Console.WriteLine(response.OriginalException.Message);
        }
    }
}