using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Configurações para criar migrações para o banco de dados
            // var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=mudar@123";
            var connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=Ro@1234567";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }


}
