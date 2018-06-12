using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Y.ZSZ.CoreMvc;

namespace Y.ZSZ.ManageWeb.App_Start
{
    public class ModelBinderConfig
    {
        public static void RegisterModelBinder(ModelBinderDictionary dic)
        {
            dic.Add(typeof(string), new TrimToDBCModelBinder());
            dic.Add(typeof(int), new TrimToDBCModelBinder());
            dic.Add(typeof(long), new TrimToDBCModelBinder());
            dic.Add(typeof(double), new TrimToDBCModelBinder());
        }
    }
}