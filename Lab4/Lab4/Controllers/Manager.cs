using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using Lab4.Models;
using System.Web.Mvc;
using AutoMapper;

namespace Lab4.Controllers
{
    public class Manager
    {
        private DataContext ds = new DataContext();

        public List<string> GetProductSizes()
        {
            // Return a collection of strings
            var sizes = new List<string> { "Small", "Medium", "Large" };
            return sizes;
        }

        // ############################################################
        // Supplier - get all, get all for select list

        public IEnumerable<SupplierBase> GetAllSuppliers()
        {
            // Fetch from the data store
            var fetchedObjects = ds.Suppliers.OrderBy(nm => nm.Name);

            // Prepare the return result
            // Return the result
            return Mapper.Map<IEnumerable<SupplierBase>>(fetchedObjects);
        }

        // Get list
        public IEnumerable<SupplierList> GetAllSuppliersList()
        {
            // Fetch from the data store
            var fetchedObjects = ds.Suppliers.OrderBy(nm => nm.Name);
            
            // Prepare the return result
            // Return the result
            return Mapper.Map<IEnumerable<SupplierList>>(fetchedObjects);
        }

        // ############################################################
        // Product - get all, get one, add new

        public IEnumerable<ProductBase> GetAllProducts()
        {
            // Fetch from the data store
            var fetchedObjects = ds.Products.Include("Supplier").OrderBy(nm => nm.Id);

            // Prepare the return result
            // Return the result
            return Mapper.Map<IEnumerable<ProductBase>>(fetchedObjects);
        }

        public ProductBase GetProductById(int id)
        {
            // Fetch from the data store
            // If not found, return null
            // Otherwise, continue
            // Prepare the return result
            // Return the result
            var fetchedObject = ds.Products.Include("Supplier").SingleOrDefault(i => i.Id == id);

            return (fetchedObject == null) ? null : Mapper.Map<ProductBase>(fetchedObject);
        }

        public ProductBase AddNewProduct(ProductAdd newItem)
        {
            // Calculate the next value for the identifier
            int newId = (ds.Products.Count() > 0) ? newId = ds.Products.Max(id => id.Id) + 1 : 1;

            var supplier = ds.Suppliers.Find(newItem.SupplierId);

            Mapper.CreateMap<ProductAdd, Product>();

            // Create a new item; notice the property mapping
            var addedItem = new Product
            {
                Id = newId,
                Supplier = supplier
                //MSRP = newItem.MSRP,
                //Name = newItem.Name,
                //ProductId = newItem.ProductId,
                //Size = newItem.Size,
                //SupplierId = newItem.SupplierId,
                //UPC = newItem.UPC
            };

            var addItem = new ProductBase
            {
                Id = addedItem.Id,
                SupplierName = supplier.Name,
                MSRP = newItem.MSRP,
                Name = newItem.Name,
                ProductId = newItem.ProductId,
                Size = newItem.Size,
                SupplierId = newItem.SupplierId,
                UPC = newItem.UPC
            };

            // Add the new item to the store
            ds.Products.Add(addedItem);

            // Return the new item
            return Mapper.Map<ProductBase>(addItem);
        }

    }

}
