using GraphQL.Types;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class VoyageByClientNameQuery : ObjectGraphType<object>
    {
        public VoyageByClientNameQuery(string baseUrl)
        {
            Name = "VoyageByClientNameQuery";

            Field<ClientType>(
                "Client",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" },
                    new QueryArgument<StringGraphType> { Name = "lastname" }
                ),
                resolve: context => RequestAuxiliar.RequestToApiRest<Client>(baseUrl + ClientType.pathByName + context.GetArgument<string>("name") + "/" + context.GetArgument<string>("lastname"))
            );
        }
    }
}
