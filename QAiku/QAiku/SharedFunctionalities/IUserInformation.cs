using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QAiku.SharedFunctionalities
{
    public interface IUserInformation
    {
        Task<string> GetUserName();
    }
}
