using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer
{
    public class DbContxt:DbContext
    {
        public DbContxt(DbContextOptions<DbContxt> options) : base(options)
        {

        }
        public DbSet <StudentDetails> Students { get; set; }
    }
}
