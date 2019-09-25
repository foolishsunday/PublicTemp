using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPCar.Common
{
    //List去重
    public class LambdaComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _LambdaComparer;
        private readonly Func<T, int> _LambdaHash;
        public LambdaComparer(Func<T, T, bool> lambdaComparer)
            : this(lambdaComparer, EqualityComparer<T>.Default.GetHashCode)
        {

        }
        public LambdaComparer(Func<T, T, bool> lambdaComparer, Func<T, int> lambdaHash)
        {
            if (lambdaComparer == null)
                throw new ArgumentNullException("lambdaComparer");
            if (lambdaHash == null)
                throw new ArgumentNullException("lambdaHash");
            _LambdaComparer = lambdaComparer;
            _LambdaHash = lambdaHash;

        }
        public bool Equals(T x, T y)
        {
            return _LambdaComparer(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _LambdaHash(obj);
        }
    }
}
