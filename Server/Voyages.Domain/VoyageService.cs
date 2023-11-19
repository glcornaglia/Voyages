using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyages.Domain
{

    public class VoyageService : IVoyageService
    {
        private readonly IVoyageRepository repository;

        public VoyageService(IVoyageRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            this.repository = repository;
        }

        public Client GetClient(int idClient)
        {
            return this.repository.GetClient(idClient);
        }

        public Client GetClientByName(string name, string lastname)
        {
            return this.repository.GetClientByName(name, lastname);
        }

        public File GetFile(int idFile)
        {
            return this.repository.GetFile(idFile);
        }

        public Product GetProduct(int idProduct)
        {
            return this.repository.GetProduct(idProduct);
        }

    }
}