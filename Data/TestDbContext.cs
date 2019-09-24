using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASP.NetRunStoredProcedures
{
  public class TestDbContext : DbContext
  {
    public TestDbContext (DbContextOptions<TestDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Query<Test>();
    }
    public virtual IList<ASP.NetRunStoredProcedures.Test> Test { get; set; }

    /*public virtual DbSet<Test> sp_Proc1()
    {
      return ((ExecuteFunction<Test>("sp_Proc1")));
    }*/
  }
}
