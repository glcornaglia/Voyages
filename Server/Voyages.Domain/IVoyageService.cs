using System.Collections.Generic;
using System.Threading.Tasks;

namespace Voyages.Domain
{

    public interface IVoyageService
    {
        Client GetClient(int idClient);
        Client GetClientByName(string name, string lastname);
        File GetFile(int idFile);
        Product GetProduct(int idProduct);
    }
}