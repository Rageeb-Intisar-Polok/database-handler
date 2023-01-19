// initial all message getting is configured. rest of the entire required
// configuration is still need to program.

using DatabaseHandler.Context;
using DatabaseHandler.Models.Generated;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Models_and_repositories.Generated.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        public readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Message> getLastMessage(string UserId)
        {
            return _context.messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToList<Message>();
        }
        public List<Message> getNextMessage(String UserId, String MessageId)
        {
            return _context.messages.FromSqlRaw<Message>("InitialGetMessageOfConnectionId {0}", UserId).ToList<Message>();
        }
    }
}
