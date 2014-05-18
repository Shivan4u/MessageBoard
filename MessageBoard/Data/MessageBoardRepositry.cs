using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.Data
{
    public class MessageBoardRepositry  : IMessageBoardRepositry
    {
        private MessageBoardContext _ctx;

        public MessageBoardRepositry(MessageBoardContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Topic> GetTopics()
        {
            return _ctx.Topics;
        }

        public IQueryable<Reply> GetReplyByTopic(int topicID)
        {
            return _ctx.Replies.Where(x => x.TopicId == topicID);
        }


        public bool save()
        {
            try
            {

                return  _ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
            

        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                 _ctx.Topics.Add(newTopic);
                 return true;
            }
            catch (Exception)
            {

                return false;
                throw;
            }
        }


        public IQueryable<Topic> GetTopicsInculdingReplies()
        {
            return _ctx.Topics.Include("Replies"); 
        }


        public bool AddReply(Reply newReply)
        {
            try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch (Exception)
            {

                return false;
                throw;
            }
        }
    }
}