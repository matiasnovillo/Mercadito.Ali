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
    public class ProductTypeRepository : IProductTypeRepository
    {
        protected readonly MercaditoAliContext _context;

        public ProductTypeRepository(MercaditoAliContext context)
        {
            _context = context;
        }

        public IQueryable<ProductType> AsQueryable()
        {
            try
            {
                return _context.ProductType.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.ProductType.Count();
            }
            catch (Exception) { throw; }
        }

        public ProductType? GetByProductTypeId(int producttypeId)
        {
            try
            {
                return _context.ProductType
                            .FirstOrDefault(x => x.ProductTypeId == producttypeId);
            }
            catch (Exception) { throw; }
        }

        public List<ProductType?> GetAll()
        {
            try
            {
                return _context.ProductType.ToList();
            }
            catch (Exception) { throw; }
        }

        public paginatedProductTypeDTO GetAllByNamePaginated(string textToSearch,
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

                int TotalProductType = _context.ProductType.Count();

                var query = from producttype in _context.ProductType
                            join userCreation in _context.User on producttype.UserCreationId equals userCreation.UserId
                            join userLastModification in _context.User on producttype.UserLastModificationId equals userLastModification.UserId
                            select new { ProductType = producttype, UserCreation = userCreation, UserLastModification = userLastModification };

                // Extraemos los resultados en listas separadas
                List<ProductType> lstProductType = query.Select(result => result.ProductType)
                        .Where(x => strictSearch ?
                            words.All(word => x.Name.ToString().Contains(word)) :
                            words.Any(word => x.Name.ToString().Contains(word)))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                List<User> lstUserCreation = query.Select(result => result.UserCreation).ToList();
                List<User> lstUserLastModification = query.Select(result => result.UserLastModification).ToList();

                return new paginatedProductTypeDTO
                {
                    lstProductType = lstProductType,
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalItems = TotalProductType,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(ProductType producttype)
        {
            try
            {
                _context.ProductType.Add(producttype);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool Update(ProductType producttype)
        {
            try
            {
                _context.ProductType.Update(producttype);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByProductTypeId(int producttypeId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.ProductTypeId == producttypeId)
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
                List<ProductType> lstProductType = _context.ProductType.ToList();

                DataTable DataTable = new();
                DataTable.Columns.Add("ProductTypeId", typeof(string));
                DataTable.Columns.Add("Active", typeof(string));
                DataTable.Columns.Add("DateTimeCreation", typeof(string));
                DataTable.Columns.Add("DateTimeLastModification", typeof(string));
                DataTable.Columns.Add("UserCreationId", typeof(string));
                DataTable.Columns.Add("UserLastModificationId", typeof(string));
                DataTable.Columns.Add("Name", typeof(string));
                

                foreach (ProductType producttype in lstProductType)
                {
                    DataTable.Rows.Add(
                        producttype.ProductTypeId,
                        producttype.Active,
                        producttype.DateTimeCreation,
                        producttype.DateTimeLastModification,
                        producttype.UserCreationId,
                        producttype.UserLastModificationId,
                        producttype.Name
                        
                        );
                }

                return DataTable;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
