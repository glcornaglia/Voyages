using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class VoyagesSchema : Schema
    {
        public VoyagesSchema(IDependencyResolver resolver)
        {
            //Query = resolver.Resolve<VoyagesQuery>();
            Query = resolver.Resolve<VoyageByClientNameQuery>();
            //Mutation = resolver.Resolve<VoyagesMutation>();
            DependencyResolver = resolver;
        }
    }
}
