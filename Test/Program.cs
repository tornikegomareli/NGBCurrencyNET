using System;
using System.Collections.Generic;
using NBGCurrency.NetworkLayer;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
          

          

            var s = NGBNetworkManager.SharedInstance.{ CurrencyEnumCodes.AED, "AED" },CreateSoapEnvelope().Result;

         
        }
    }
}
