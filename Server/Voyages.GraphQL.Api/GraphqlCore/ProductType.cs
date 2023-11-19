using GraphQL.Types;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class ProductType : ObjectGraphType<Product>
    {
        public const string path = "GetProduct/";

        public ProductType()
        {
            Field(x => x.Id).Description("Product id.");
            Field(x => x.Type).Description("Product type.");
            Field(x => x.Name).Description("Product Name.");
            Field(x => x.Description).Description("Product Description.");
            Field(x => x.Address).Description("Product Address.");
            Field(x => x.Telephone).Description("Product Telephone.");
            Field(x => x.PhotoLink).Description("Product PhotoLink.");
        }
    }
}
