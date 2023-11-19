using GraphQL.Types;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class VoyagesQuery : ObjectGraphType<object>
    {
        public VoyagesQuery(string baseUrl)
        {
            Name = "VoyagesQuery";

            Field<ClientType>(
                "ClientById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idClient" }),
                resolve: context => RequestAuxiliar.RequestToApiRest<Client>(baseUrl + ClientType.pathById + context.GetArgument<int>("idClient"))
            );
        }
    }
}
