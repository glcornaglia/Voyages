using System;

namespace Voyages.Web
{
    public class VoyagesConfiguration
    {
        public readonly string ConnectionString;
        public readonly Type VoyageRepositoryType;

        public VoyagesConfiguration(string connectionString, string voyageRepositoryTypeName)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            if (string.IsNullOrWhiteSpace(voyageRepositoryTypeName))
                throw new ArgumentNullException(nameof(voyageRepositoryTypeName));

            this.ConnectionString = connectionString;
            this.VoyageRepositoryType = Type.GetType(voyageRepositoryTypeName, throwOnError: true);
        }
    }
}