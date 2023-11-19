using GraphQL.Types;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class FileType : ObjectGraphType<File>
    {
        public const string path = "GetFile/";

        public FileType(string baseUrl)
        {
            Field(x => x.Id).Description("File id.");
            Field(x => x.IdProduct).Description("Product id.");
            Field(x => x.Type).Description("File type.");
            Field(x => x.ArrivalDate).Description("File Arrival Date.");
            Field(x => x.Duration).Description("File Duration.");
            Field(x => x.FlightNumber).Description("File Flight Number.");
            Field(x => x.Place).Description("File Place.");
            Field(x => x.Price).Description("File Price.");

            Field<ProductType> (
              "Product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idProduct" }),
                resolve: context => RequestAuxiliar.RequestToApiRest<Product>(baseUrl + ProductType.path + context.Source.IdProduct)
           );
        }
    }
}
