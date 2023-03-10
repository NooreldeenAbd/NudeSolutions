using Dev_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Assignment.DAL.Data
{
    public interface IDataContext
    {
        DbSet<InsuredItem> InsuredItems { get; set; }

        int SaveChanges();
    }
}
