namespace Nancy.Demo.PostSharp
{
    using System;
    using System.Collections.Generic;

    public static class Cache
    {
        private readonly static Dictionary<string, CachedObject> CacheObjects;

        static Cache()
        {
            CacheObjects = new Dictionary<string, CachedObject>();
        }

        private class CachedObject
        {
            public object Content { get; set; }

            public DateTime Expiration { get; set; }
        }

        public static void Add(string name, object content, int duration)
        {
            var expiration = duration == 0 ? DateTime.MaxValue : DateTime.Now.AddSeconds(duration);

            CacheObjects.Add(
                name,
                new CachedObject { Content = content, Expiration = expiration });
        }

        public static object Get(string name)
        {
            CachedObject cachedObject;
            if (!CacheObjects.TryGetValue(name, out cachedObject))
            {
                return null;
            }

            if (IsCacheExpired(cachedObject))
            {
                Delete(name);
                return null;
            }

            return cachedObject.Content;
        }

        private static bool IsCacheExpired(CachedObject cachedObject)
        {
            var isCacheExpired = cachedObject.Expiration.TimeOfDay < DateTime.Now.TimeOfDay;
            return isCacheExpired;
        }

        private static void Delete(string name)
        {
            CacheObjects.Remove(name);
        }
    }
}