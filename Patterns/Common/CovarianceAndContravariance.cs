using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    //Value types also do not support variance
    public static class CovarianceAndContravariance
    {
        public static void Test()
        {
            //Covariance permits a method to have a more derived return type than that defined
            //by the generic type parameter of the interface (OUT)
            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;

            //Contravariance permits a method to have argument types that are less derived than that
            //specified by the generic parameter of the interface (IN)
            IEqualityComparer<BaseClass> baseComparer = new BaseComparer();
            IEqualityComparer<DerivedClass> childComparer = baseComparer;
 
        }
    }

    class BaseClass { }
    class DerivedClass : BaseClass { }

    // Comparer class.
    class BaseComparer : IEqualityComparer<BaseClass>
    {
        public int GetHashCode(BaseClass baseInstance)
        {
            return baseInstance.GetHashCode();
        }
        public bool Equals(BaseClass x, BaseClass y)
        {
            return x == y;
        }
    }



}
