using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixin
{
    class SpecialDocument : Document
    {
        public override string ID
        {
            get { return "SpecialDocument"; }
        }
    }
}
