using MercaditoAli.Areas.MercaditoAli.Entities;
using MercaditoAli.Areas.MercaditoAli.DTOs;
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

namespace MercaditoAli.Areas.MercaditoAli.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> AsQueryable();

        #region Queries
        int Count();

        Product? GetByProductId(int productId);

        List<Product?> GetAll();

        paginatedProductDTO GetAllByNamePaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Non-Queries
        bool Add(Product product);

        bool Update(Product product);

        bool DeleteByProductId(int product);
        #endregion

        #region Other methods
        DataTable GetAllInDataTable();
        #endregion
    }
}
