using angularjs.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angularjs.Data.Factory
{
    public class ContextFactory
    {
        private static RestauranteContext context;
        private ContextFactory() { }

        public static RestauranteContext getContext()
        {
            if (context == null)
                context = new RestauranteContext();
            return context;
        }


    }
}
