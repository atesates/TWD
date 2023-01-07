using System;
using System.Collections.Generic;
using System.Text;

namespace TWD.Core.Utilities.Results
{
    public  interface IDataResult<out T>:IResult
    {//instead of showing to user the information about error, showing logical result to user
        //successs, error, vs
        T Data { get; }
    }
}
