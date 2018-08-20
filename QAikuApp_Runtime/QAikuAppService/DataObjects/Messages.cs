using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Mobile.Server;

namespace QAikuAppService.DataObjects
{
    public class Message : EntityData
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public int SenderId { get; set; }
        public DateTime SendDate { get; set; }

        public int Category { get; set; }
        public bool Favorite { get; set; }
    }
    enum Category { Question = 1, Answer };
}
