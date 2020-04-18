using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesRealm.Models;

namespace TestesRealm.Models
{
    // Define your models like regular C# classes
    public class Model : RealmObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
