using System.Collections.Generic;
using System.Linq ;
namespace Search.Utils
{
    public interface IOperation
    {
         List<T> Apply<T>(List<T> list1 , List<T> list2);
         
    }
}