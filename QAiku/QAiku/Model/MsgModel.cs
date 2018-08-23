using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QAiku
{
    public class MsgModel:BindableObject
    {
        /// <summary>
        /// CosmosDB DocumentId, used when calling for a specific document
        /// </summary>
        public string  id { get; set; }
        /// <summary>
        /// Message subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Message text
        /// </summary>

        public string Description { get; set; }
        /// <summary>
        /// Sender id (email address)
        /// </summary>
        public string SenderId { get; set; }
        /// <summary>
        /// CSV message recipient id list (email address)
        /// </summary>
        public string RecipientsIdCsv { get; set; }
        /// <summary>
        /// Message send date in DateTime
        /// </summary>
        public DateTime SendDate { get; set; }
        /// <summary>
        /// Message category: 1=Question, 2=Answer
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// Whether or not the question is favorited
        /// </summary>
        public bool Favorite { get; set; }
        /// <summary>
        ///  For answers, use Response(0); For questions, choose Unanswered(1), Partial(2), or Answered(3).
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// Specifies the thread that the message belongs to
        /// </summary>
        public string  ThreadId { get; set; }
    }
    /// <summary>
    /// Message categories: 1=Question, 2=Answer
    /// </summary>
    enum Category { Question = 1, Answer };
    /// <summary>
    /// Message states: 0=Response, 1=Unanswered, 2=Partial, 3=Answered
    /// </summary>
    enum State { Response, Unanswered, Partial, Answered }
}
