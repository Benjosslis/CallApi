using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CallApi.Api.Models;

namespace CallApi.Api.Data
{
    public class CallApiApiContext : DbContext
    {
        public CallApiApiContext (DbContextOptions<CallApiApiContext> options)
            : base(options)
        {
        }

        public DbSet<CallApi.Api.Models.ApiModels> ApiModels { get; set; } = default!;
    }
}
