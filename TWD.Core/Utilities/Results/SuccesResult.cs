using System;
using System.Collections.Generic;
using System.Text;

namespace TWD.Core.Utilities.Results
{
    public class SuccesResult : Result
    {
        public SuccesResult(string message) : base(success:true, message)
        {

        }
        public SuccesResult() : base(success: true)
        {

        }
    }
}
