using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QAiku.Droid;

namespace QAiku.ViewModel
{
    class QuestionThreadPageModel
    {
        public MsgModel MsgModel { get; set; }

        public QuestionThreadPageModel()
        {
            MsgModel = new MsgModel();

        }

        public static async Task<QuestionThreadPageModel> Update()
        {
            var questionThreadPageModel = new QuestionThreadPageModel();
            await questionThreadPageModel.Initialize();
            return questionThreadPageModel;

        }

        private async Task Initialize()
        {
            await Task.Delay(1000);
            HttpCalls call = new HttpCalls();
            List<MsgModel> msgs = await call.GetAllMessagesAsync();
            MsgModel = msgs[0];


        }
    }
}
