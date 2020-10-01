using DataAccess.Context;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private DbSet<Administrator> administrators;
        private BookedUYContext bookedUYContext;

        public AdministratorRepository(BookedUYContext context)
        {
            this.bookedUYContext = context;
            this.administrators = context.Set<Administrator>();
        }

        public IEnumerable<Administrator> GetAll()
        {
            return this.administrators;
        }
    }
}
