using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Configurações para criar migrações para o banco de dados
            // var connectionString = ""Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=SeuVizinho";
            // var connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=Ro@1234567";
            var connectionString = "Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=NetCore_ApiREst";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }


}
