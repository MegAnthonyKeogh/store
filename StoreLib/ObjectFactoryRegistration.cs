using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib
{
    public class ObjectFactoryRegistration
    {
        public Type Interface { get; set; }
        public object Concrete { get; set; }
        public string Name { get; set; }
    }
}