using Microsoft.EntityFrameworkCore;
using WebAPI_beanstalk.Models;

namespace WebAPI_beanstalk.DataAccess
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            //optionsBuilder.UseMySQL("server=localhost; user=root; password=dev609; database=todoDB");
            optionsBuilder.UseMySQL("server=testdbfromvs.cvfxkni97ujr.us-east-1.rds.amazonaws.com; user=root; password=dev60940; database=todoDB");
            base.OnConfiguring(optionsBuilder);
        }
        //optionsBuilder.UseMySQL("server=awseb-e-hiwmvmgmid-stack-awsebrdsdatabase-easqk0wxbvvc.cvfxkni97ujr.us-east-1.rds.amazonaws.com; user=root; password=dev60940; database=todoDB");
    }
}
