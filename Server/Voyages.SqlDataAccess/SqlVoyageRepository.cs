using System;
using System.Collections.Generic;
using System.Linq;
using Voyages.Domain;

namespace Voyages.SqlDataAccess
{

    public class SqlVoyageRepository : IVoyageRepository
    {
        private readonly VoyagesContext context;

        public SqlVoyageRepository(VoyagesContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }

        public Client GetClient(int idClient)
        {
            return
                (from client in this.context.Clients
                 where client.Id == idClient
                 select new Client
                 {
                     Id = client.Id,
                     Name = client.Name,
                     LastName = client.LastName,
                     Address = client.Address,
                     Telephone = client.Telephone,
                     Email = client.Email,
                     BirthDate = client.BirthDate,
                     IdFile = client.IdFile,
                 }).FirstOrDefault();
        }
        public Client GetClientByName(string name, string lastname)
        {
            return
                (from client in this.context.Clients
                 where client.Name.ToLower().Trim() == name.ToLower().Trim() && client.LastName.ToLower().Trim() == lastname.ToLower().Trim()
                 select new Client
                 {
                     Id = client.Id,
                     Name = client.Name,
                     LastName = client.LastName,
                     Address = client.Address,
                     Telephone = client.Telephone,
                     Email = client.Email,
                     BirthDate = client.BirthDate,
                     IdFile = client.IdFile,
                 }).FirstOrDefault();
        }


        public File GetFile(int idFile)
        {
            return
                (from file in this.context.Files
                 where file.Id == idFile
                 select new File
                 {
                     Id = file.Id,
                     IdProduct = file.IdProduct,
                     Type = file.Type,
                     ArrivalDate = file.ArrivalDate,
                     Duration = file.Duration,
                     FlightNumber = file.FlightNumber,
                     Place = file.Place,
                     Travelers = file.Travelers,
                     Price = file.Price
                 }).FirstOrDefault();
        }

        public Product GetProduct(int idProduct)
        {
            return
                (from product in this.context.Products
                where product.Id == idProduct
                select new Product
                {
                    Id = product.Id,
                    Type = product.Type,
                    Name = product.Name,
                    Description = product.Description,
                    Address = product.Address,
                    Telephone = product.Telephone,
                    PhotoLink = product.PhotoLink
                }).FirstOrDefault();
        }
    }
}