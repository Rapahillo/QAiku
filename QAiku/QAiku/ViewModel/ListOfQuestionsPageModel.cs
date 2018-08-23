using System;
using System.Collections.Generic;
using System.Text;
using QAiku.Droid;

namespace QAiku.ViewModel
{
    class ListOfQuestionsPageModel
    {
        public List<MsgModel> MsgModels { get; set; }
        public ListOfQuestionsPageModel()
        {
            MsgModels = new List<MsgModel>();
        }
    }
}
