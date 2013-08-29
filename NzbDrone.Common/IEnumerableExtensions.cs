using System;
using System.Collections.Generic;
using System.Linq;

namespace NzbDrone.Common
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var knownKeys = new HashSet<TKey>();

            return source.Where(element => knownKeys.Add(keySelector(element)));
        }
    }

    public static class ExceptionExtensions
    {
        public static Exception SearchFor<T>(this Exception exception)
        {
            if (exception.GetType() == typeof(T))
            {
                return exception;
            }

            if (exception.InnerException != null)
            {
                return exception.InnerException.SearchFor<T>();
            }

            return null;
        }
    }
}