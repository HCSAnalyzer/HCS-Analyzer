using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCSAnalyzer.Classes.Base_Classes
{
    public class cFeedBackMessage
    {
        public bool IsSucceed;
        public string Message;

        public cFeedBackMessage(bool IsSucceed)
        {
            if (!IsSucceed)
            {
                this.IsSucceed = false;
                this.Message = "Fail";
            }
            else
            {
                this.IsSucceed = true;
                this.Message = "Success";
            
            }

        }

    }
}
