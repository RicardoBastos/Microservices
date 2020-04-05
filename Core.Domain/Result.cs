using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Result
    {
        public object data { get; set; }
        public string single { get; set; }
        public string message { get; set; }
        public int totalRecords { get; set; }

    }
}
