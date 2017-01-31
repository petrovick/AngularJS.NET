using angularjs.Application.ApplicationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using angularjs.Application.ApplicationImplementations;

namespace angularjs.Application.Factory
{
    public class ApplicationFactory
    {
        private static ApplicationFactory applicationFactory;

        public static ApplicationFactory getInstance()
        {
            if (applicationFactory == null)
                applicationFactory = new ApplicationFactory();

            return applicationFactory;
        }

        public IRestauranteApplication getRestauranteApplication()
        {
            return new RestauranteApplication();
        }

        public IPratoApplication getPratoApplication()
        {
            return new PratoApplication();
        }





    }
}
