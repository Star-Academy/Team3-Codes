using System;
using Nest;

namespace SearchNest.Utils.Nest
{
    public class ResponseValidator
    {
        public static void handleValidation(IResponse response, string requestType)
        {
            if (!response.IsValid)
            {
                Console.WriteLine($"Request of :{requestType}");
                Console.WriteLine(response.OriginalException.Message);
            }
            else
                Console.WriteLine($"Response of {requestType} has been received succsesfully ( {response.ApiCall.HttpStatusCode} )");
        }
    }
}