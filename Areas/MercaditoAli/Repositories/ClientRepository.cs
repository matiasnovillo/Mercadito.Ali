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
    public class ClientRepository : IClientRepository
    {
        protected readonly MercaditoAliContext _context;

        public ClientRepository(MercaditoAliContext context)
        {
            _context = context;
        }

        public IQueryable<Client> AsQueryable()
        {
            try
            {
                return _context.Client.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Client.Count();
            }
            catch (Exception) { throw; }
        }

        public Client? GetByClientId(int clientId)
        {
            try
            {
                return _context.Client
                            .FirstOrDefault(x => x.ClientId == clientId);
            }
            catch (Exception) { throw; }
        }

        public List<Client?> GetAll()
        {
            try
            {
                return _context.Client.ToList();
            }
            catch (Exception) { throw; }
        }

        public paginatedClientDTO GetAllByNamesPaginated(string textToSearch,
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

                int TotalClient = _context.Client.Count();

                var query = from client in _context.Client
                            join userCreation in _context.User on client.UserCreationId equals userCreation.UserId
                            join userLastModification in _context.User on client.UserLastModificationId equals userLastModification.UserId
                            select new { Client = client, UserCreation = userCreation, UserLastModification = userLastModification };

                // Extraemos los resultados en listas separadas
                List<Client> lstClient = query.Select(result => result.Client)
                        .Where(x => strictSearch ?
                            words.All(word => x.CommercialName.ToString().Contains(word)) :
                            words.Any(word => x.FullName.ToString().Contains(word)))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                List<User> lstUserCreation = query.Select(result => result.UserCreation).ToList();
                List<User> lstUserLastModification = query.Select(result => result.UserLastModification).ToList();

                return new paginatedClientDTO
                {
                    lstClient = lstClient,
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalItems = TotalClient,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(Client client)
        {
            try
            {
                _context.Client.Add(client);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Client client)
        {
            try
            {
                _context.Client.Update(client);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByClientId(int clientId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.ClientId == clientId)
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
                List<Client> lstClient = _context.Client.ToList();

                DataTable DataTable = new();
                DataTable.Columns.Add("ClientId", typeof(string));
                DataTable.Columns.Add("Active", typeof(string));
                DataTable.Columns.Add("DateTimeCreation", typeof(string));
                DataTable.Columns.Add("DateTimeLastModification", typeof(string));
                DataTable.Columns.Add("UserCreationId", typeof(string));
                DataTable.Columns.Add("UserLastModificationId", typeof(string));
                DataTable.Columns.Add("FullName", typeof(string));
                DataTable.Columns.Add("CommercialName", typeof(string));
                DataTable.Columns.Add("Address", typeof(string));
                DataTable.Columns.Add("Phone", typeof(string));
                

                foreach (Client client in lstClient)
                {
                    DataTable.Rows.Add(
                        client.ClientId,
                        client.Active,
                        client.DateTimeCreation,
                        client.DateTimeLastModification,
                        client.UserCreationId,
                        client.UserLastModificationId,
                        client.FullName,
                        client.CommercialName,
                        client.Address,
                        client.Phone
                        
                        );
                }

                return DataTable;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
