

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Entities;
using DutchTreat.Data.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _ctx;
        public DutchRepository(DutchContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products.OrderBy(p => p.Title).ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products.Where(P => P.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
