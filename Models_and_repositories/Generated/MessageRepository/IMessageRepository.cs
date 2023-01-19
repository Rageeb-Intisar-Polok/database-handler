using DatabaseHandler.Models.Generated;

namespace DatabaseHandler.Models_and_repositories.Generated.MessageRepository
{
    public interface IMessageRepository
    {
        public List<Message> getLastMessage(String UserId);
        public List<Message> getNextMessage(String UserId, String MessageId);
    }
}
