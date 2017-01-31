using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using angularjs.Business.Business;
using angularjs.Application.Generic;
using angularjs.Application.ApplicationInterfaces;

namespace angularjs.Application.ApplicationImplementations
{
    class PratoApplication : GenericApplication<Prato, int>, IPratoApplication, IGenericApplication<Prato, int>
    {
    }
}
