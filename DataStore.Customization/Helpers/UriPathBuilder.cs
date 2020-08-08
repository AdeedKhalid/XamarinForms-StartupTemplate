using System;

namespace DataStore.Customization.Helpers
{
    public class UriPathBuilder
    {
        private static UriBuilder _uriBuilder;

        public UriPathBuilder() { }

        public UriPathBuilder(string endPoint) => _uriBuilder = new UriBuilder(endPoint);

        public static UriBuilder GetPath(string path, UriQueryBuilder queryBuilder = null)
        {
            if (_uriBuilder == null) _uriBuilder = new UriBuilder(path);
            //_uriBuilder.Path = path;
            _uriBuilder.Query = queryBuilder?.Build();
            return _uriBuilder;
        }
    }
}
