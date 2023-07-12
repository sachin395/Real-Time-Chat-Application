using Microsoft.EntityFrameworkCore;
using Notification_Using_signalR.Model;

namespace Notification_Using_signalR
{
    public class AppDbContext:DbContext
    {
        public DbSet<MessageDto> Review { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
