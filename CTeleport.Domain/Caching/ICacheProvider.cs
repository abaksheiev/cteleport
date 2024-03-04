namespace CTeleport.Domain.Caching
{
    public interface ICacheProvider 
    {
        /// <summary>
        /// Get object by key
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="cachKey">Key of object</param>
        /// <returns>The object. Return default if it does not exist</returns>
        public T Get<T>(string cachKey);

        /// <summary>
        /// Add object into cach
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="cachKey">Key of object</param>
        /// <param name="instance">The object</param>
        public void Set<T>(string cachKey, T instance);
    }
}
