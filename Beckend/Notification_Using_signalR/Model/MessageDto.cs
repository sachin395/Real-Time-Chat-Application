using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Notification_Using_signalR.Model
{
    public class MessageDto
    {
        [Key]
        public int userId { get; set; }
        public string user { get; set; }
        public string msgText { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
    }
}
