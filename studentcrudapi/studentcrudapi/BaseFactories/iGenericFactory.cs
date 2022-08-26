using studentcrudapi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentcrudapi.BaseFactories
{
    interface iGenericFactory<T> : IDisposable where T : class
    {
        string ExecuteCommandString(string spQuery, Hashtable ht, int iid);
        //string ExecuteCommandString1(string spQuery, Hashtable ht);
        List<Item> ExecuteQuery();
    }
}
