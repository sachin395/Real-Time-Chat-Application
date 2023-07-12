using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Notification_Using_signalR.Model;

namespace Notification_Using_signalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly AppDbContext _context;

        public ChatController(IHubContext<ChatHub> hubContext,AppDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        [Route("send")] //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult SendRequest(MessageDto msg)
        {
            var message = new MessageDto { user = msg.user, msgText = msg.msgText,Date=DateTime.UtcNow,ProductId=msg.ProductId};
            _context.Review.Add(message);
            _context.SaveChanges();
            _hubContext.Clients.All.SendAsync("ReceiveOne", msg.user, msg.msgText,msg.Date,msg.ProductId);
            return Ok(true);
        }
        [Route("GetChats")]                                          
        [HttpGet]
        public IActionResult GetChats(int productId)
        {
            List<MessageDto>chats=_context.Review.Where(x=>x.ProductId==productId).ToList();
            return Ok(chats);
        }

    }

}
