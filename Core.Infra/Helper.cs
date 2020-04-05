using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Infra
{
    public static class Helper
    {
        public static string TratarQueryParaSelectCount(string query, string from)
        {
            return "select count(*) " + query.Substring(query.IndexOf(from), (query.Length - query.IndexOf(from)));

        }
    }
}
