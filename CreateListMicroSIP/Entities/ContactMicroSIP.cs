using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateListMicroSIP.Entities {
    internal class ContactMicroSIP {

        public string? Name { get; private set; }
        public string? Number { get; private set; }

        public ContactMicroSIP(string? name, string? number) {
            Name = name;
            Number = number;
        }
    }
}
