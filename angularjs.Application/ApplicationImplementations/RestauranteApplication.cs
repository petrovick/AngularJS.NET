using angularjs.Application.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using angularjs.Application.ApplicationInterfaces;
using angularjs.Business.Business;

namespace angularjs.Application.ApplicationImplementations
{
    public class RestauranteApplication : GenericApplication<Restaurante, int>, IRestauranteApplication, IGenericApplication<Restaurante, int>
    {

    }
}
