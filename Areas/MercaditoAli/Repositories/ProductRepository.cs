using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using MercaditoAli.Areas.CMSCore.Entities;
using MercaditoAli.Areas.BasicCore;
using MercaditoAli.Areas.MercaditoAli.Entities;
using MercaditoAli.Areas.MercaditoAli.DTOs;
using MercaditoAli.Areas.MercaditoAli.Interfaces;
using System.Data;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2024
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace MercaditoAli.Areas.MercaditoAli.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly MercaditoAliContext _context;

        public ProductRepository(MercaditoAliContext context)
        {
            _context = context;
        }

        public IQueryable<Product> AsQueryable()
        {
            try
            {
                return _context.Product.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Product.Count();
            }
            catch (Exception) { throw; }
        }

        public Product? GetByProductId(int productId)
        {
            try
            {
                return _context.Product
                            .FirstOrDefault(x => x.ProductId == productId);
            }
            catch (Exception) { throw; }
        }

        public List<Product?> GetAll()
        {
            try
            {
                return _context.Product.ToList();
            }
            catch (Exception) { throw; }
        }

        public paginatedProductDTO GetAllByNamePaginated(string textToSearch,
            bool strictSearch,
            int pageIndex, 
            int pageSize)
        {
            try
            {
                //textToSearch: "novillo matias  com" -> words: {novillo,matias,com}
                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @"\s+", " ")
                    .Split(" ");

                int TotalProduct = _context.Product.Count();

                var query = from product in _context.Product
                            join productType in _context.ProductType on product.ProductTypeId equals productType.ProductTypeId
                            join userCreation in _context.User on product.UserCreationId equals userCreation.UserId
                            join userLastModification in _context.User on product.UserLastModificationId equals userLastModification.UserId
                            select new { Product = product, UserCreation = userCreation, UserLastModification = userLastModification, ProductType = productType };

                // Extraemos los resultados en listas separadas
                List<Product> lstProduct = query.Select(result => result.Product)
                        .Where(x => strictSearch ?
                            words.All(word => x.Name.Contains(word)) :
                            words.Any(word => x.Name.Contains(word)))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                List<User> lstUserCreation = query.Select(result => result.UserCreation).ToList();
                List<User> lstUserLastModification = query.Select(result => result.UserLastModification).ToList();
                List<ProductType> lstProductType = query.Select(result => result.ProductType).ToList();

                return new paginatedProductDTO
                {
                    lstProduct = lstProduct,
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    lstProductType = lstProductType,
                    TotalItems = TotalProduct,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(Product product)
        {
            try
            {
                _context.Product.Add(product);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Product product)
        {
            try
            {
                _context.Product.Update(product);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByProductId(int productId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.ProductId == productId)
                        .ExecuteDelete();

                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Other methods
        public DataTable GetAllInDataTable()
        {
            try
            {
                List<Product> lstProduct = _context.Product.ToList();

                DataTable DataTable = new();
                DataTable.Columns.Add("ProductId", typeof(string));
                DataTable.Columns.Add("Active", typeof(string));
                DataTable.Columns.Add("DateTimeCreation", typeof(string));
                DataTable.Columns.Add("DateTimeLastModification", typeof(string));
                DataTable.Columns.Add("UserCreationId", typeof(string));
                DataTable.Columns.Add("UserLastModificationId", typeof(string));
                DataTable.Columns.Add("Name", typeof(string));
                DataTable.Columns.Add("Price", typeof(string));
                DataTable.Columns.Add("Stock", typeof(string));
                DataTable.Columns.Add("Description", typeof(string));
                DataTable.Columns.Add("ProductTypeId", typeof(string));
                

                foreach (Product product in lstProduct)
                {
                    DataTable.Rows.Add(
                        product.ProductId,
                        product.Active,
                        product.DateTimeCreation,
                        product.DateTimeLastModification,
                        product.UserCreationId,
                        product.UserLastModificationId,
                        product.Name,
                        product.Price,
                        product.Stock,
                        product.Description,
                        product.ProductTypeId
                        
                        );
                }

                return DataTable;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
