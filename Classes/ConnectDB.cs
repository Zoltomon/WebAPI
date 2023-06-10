using AutoZolto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoZolto.Classes
{
    internal class ConnectDB
    {
        public static _1301123ZoltoContext connect { get; set; } = new _1301123ZoltoContext();
    }
}
