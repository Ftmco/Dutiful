using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.DataBase.Context;

public class DutifulContext : DbContext
{
    public DutifulContext(DbContextOptions<DutifulContext> options) : base(options)
    { }


}