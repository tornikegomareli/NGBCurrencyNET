using System;
using System.Collections.Generic;
using NBGCurrency.Client;
using NBGCurrency.NetworkLayer;
using NBGCurrency.Extensions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ngbClient = NGBCurrencyClient.Shared.GetCurrentDateAsync().Result;

        }
    }
}
