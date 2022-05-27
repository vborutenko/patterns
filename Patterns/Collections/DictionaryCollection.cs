using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    /// <summary>
    /// The hash table contains a list of buckets, and in those buckets it stores one or more values.
    /// A hash function is used to compute an index based on the key. When we insert an item into our container,
    /// it will be added to the bucket designated by the calculated index. Likewise, when we are doing a lookup by the key,
    /// we can also calculate this index,
    /// and we will know the bucket in which we have to look for our item. Ideally, the hash function will assign each key to a unique bucket,
    /// so that all buckets contain only a single element. This would mean that our lookup operation is really constant in its run-time,
    /// since it has to calculate the hash, and then it has to get the first (and only) item from the appropriate bucket.
    /// https://blog.markvincze.com/back-to-basics-dictionary-part-2-net-implementation/
    ///
    /// --.NET Dictionary uses a variant of the technique called chaining to resolve collisions,
    /// </summary>
    public static class DictionaryCollection
    {
        public static void Test()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
        }
    }
}
