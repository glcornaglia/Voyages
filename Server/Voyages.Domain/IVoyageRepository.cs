using System.Collections.Generic;

namespace Voyages.Domain
{

    public interface IVoyageRepository
    {
        Client GetClient(int idClient);
        Client GetClientByName(string name, string lastname);
        File GetFile(int idFile);
        Product GetProduct(int idProduct);
    }
}