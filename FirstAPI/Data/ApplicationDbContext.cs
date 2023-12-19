using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Villa> Villas { get; set; }
    }
}
