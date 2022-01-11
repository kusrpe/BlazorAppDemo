using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClientDemo.Common
{
    public interface IErrorComponent
    {
        void ShowError(string title, string message);
    }
}
