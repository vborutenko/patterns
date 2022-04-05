using System;
using System.Collections.Generic;
using System.Text;

namespace ___Version7
{
    public static class LocalFunctions
    {
        public static void Test()
        {
            
            string localFunction(string filepath)
            {
                return filepath.EndsWith(@"\") ? filepath : filepath + @"\";
            }

            Func<string,string> func = x => x.EndsWith(@"\") ? x : x + @"\";

            localFunction("abc");
            func("");

            //1.When creating a lambda, a delegate has to be created, which is an unnecessary allocation in this case.
            //Local functions are really just functions, no delegates are necessary.

            //2.Local functions can be generic

            //3. Local functions look better.
        }
    }
}
