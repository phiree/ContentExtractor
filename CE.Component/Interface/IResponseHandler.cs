using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CE.Component.Interface
{
    public interface IResponseHandler
    {
        string GetResponseHtml(string url);
    }
}
