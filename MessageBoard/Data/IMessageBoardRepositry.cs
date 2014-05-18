using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Data
{
   public interface IMessageBoardRepositry
    {

         IQueryable<Topic> GetTopics();
         IQueryable<Topic> GetTopicsInculdingReplies();
         IQueryable<Reply> GetReplyByTopic(int topicID);

         bool save();

         bool AddTopic(Topic topic);
         bool AddReply(Reply reply);

    }
}
