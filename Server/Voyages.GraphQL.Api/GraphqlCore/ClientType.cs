using GraphQL.Types;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class ClientType : ObjectGraphType<Client>
    {
        public const string pathById = "GetClient/";
        public const string pathByName = "GetClientByName/";

        public ClientType(string baseUrl)
        {
            Field(x => x.Id).Description("Client id.");
            Field(x => x.Name).Description("Client name.");
            Field(x => x.LastName).Description("Client lastname.");
            Field(x => x.Address).Description("Client address.");
            Field(x => x.Telephone).Description("Client telephone.");
            Field(x => x.Email).Description("Client email.");
            Field(x => x.BirthDate).Description("Client Birthday.");
            Field(x => x.IdFile).Description("File Id.");

            Field<FileType>(
                "File",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idFile" }),
                resolve: context => RequestAuxiliar.RequestToApiRest<File>(baseUrl + FileType.path + context.Source.IdFile)
           );
        }
    }

}
