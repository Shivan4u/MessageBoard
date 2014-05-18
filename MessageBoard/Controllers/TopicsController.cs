using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepositry _repo;

        public TopicsController(IMessageBoardRepositry repo)
        {
            _repo = repo;
        }

        public IEnumerable<Topic> Get(bool includeReplies = false)
        {

            IQueryable<Topic> results;

            if (includeReplies == true)
            {
                results = _repo.GetTopicsInculdingReplies();
            }
            else {
                results = _repo.GetTopics();
            }

            var topics = results
                            .OrderByDescending(t => t.Created)
                                .Take(50)
                                .ToList();

            return topics;
            
       }

        public HttpResponseMessage Post([FromBody]Topic newTopic)
        {
            if (newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            if (_repo.AddTopic(newTopic) && _repo.save())
            { 
                return  Request.CreateResponse(HttpStatusCode.Created,newTopic);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }
    }
}
