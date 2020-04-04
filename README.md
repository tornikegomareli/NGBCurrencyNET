<h1 align="center">
  <br>
  <a https://nbg.gov.ge/api.html"><img src="https://upload.wikimedia.org/wikipedia/ka/thumb/8/87/Logo_of_National_Bank_of_Georgia.svg/1200px-Logo_of_National_Bank_of_Georgia.svg.png" alt="NBG" height="250" width="250"></a>
</h1>

<h4 align="center">A highly readable and comfortable C# wrapper for National bank of Georgia currency API</h4>

<p align="center">
    <a href="https://github.com/tornikegomareli/NGBCurrencyNET/commits/master">
      <img src="https://img.shields.io/github/last-commit/ArmynC/ArminC-AutoExec.svg?style=flat-square&logo=github&logoColor=white"
         alt="GitHub last commit">
    <a href="https://github.com/tornikegomareli/NGBCurrencyNET/issues">
    <img src="https://img.shields.io/github/issues-raw/ArmynC/ArminC-AutoExec.svg?style=flat-square&logo=github&logoColor=white"
         alt="GitHub issues">
    <a href="https://github.com/tornikegomareli/NGBCurrencyNET/pulls">
    <img src="https://img.shields.io/github/issues-pr-raw/ArmynC/ArminC-AutoExec.svg?style=flat-square&logo=github&logoColor=white"
         alt="GitHub pull requests">
</p>
      
<p align="center">
  <a href="#about">About</a> •
  <a href="#installation">Installation</a> •
  <a href="#contributing">Contributing</a> •
  <a href="#author">Author</a> •
  <a href="#support">Support</a> •
  <a href="#license">License</a>
</p>

---

## About
  
**NBGCurrencyNET** is a **high-quality** C# wrapper for NBG Currency API

It comes **filled** with **optimized** and **simple** Client which will be used to make all basic requests for Georgian LARI currency.

You don't neeed to know anything how API WORKS and how you must manage SOAP requests.(compared to default settings). With the help of abstraction layer it will be just a few lines to make things work.

Supported Currencies:
```
AED, AMD, AUD, AZN, BGN, BYR, CAD, CHF, CNY, CZK, DKK, EEK, EGP, EUR, GBP, HKD, HUF, ILS, INR, IRR, ISK, JPY, KGS, KWD, KZT, LTL, LVL, MDL, NOK, NZD, PLN, RON, RSD, RUB, SEK, SGD, TJS, TMT, TRY, UAH, USD, UZS
```
## Installation

![ExampleCode](https://media.giphy.com/media/W2p1C9gme1ExcyxyT6/giphy.gif)

##### There is three way to install NBGCurrencyNET :shipit:
* Download/Clone and just put dll in your project :+1: 

* Use Visual Studio Package Console :+1: 
```
Install-Package ngbcurrencywrapper -Version 1.0.0
```
* Use dotnet CLI :+1: 
```
dotnet add package ngbcurrencywrapper --version 1.0.0
```

## Using NBGCurrencyNET in your project
You can use NBGCurrencyNET in you project by either directly using main namespace.

To get you started quickly, let's take a look at a few ways to get simple Hello World project working.

Our Hello World project has just one source file, `Program.cs` file, and it looks like this:

Main client is NBGCurrencyClient, which is thread-safe singleton. All required method you can find in this class.
Of course all of the methods are async and you need to call them with await.

GetCurrencyAsync -> float
GetCurrencyChangeAsync -> float
GetCurrencyDescriptionAsync -> string
GetCurrencyRateAsync -> int
GetCurrentDateAsync  -> DateTime


```c#
using System;
using NBGCurrency.Client;
using NBGCurrency.Configuration;

namespace HelloWorld
{
    class Program
    {
        public async void Main(string[] args)
        {
            var client = NBGCurrencyClient.Shared;

            var usdToGel = await client.GetCurrencyAsync(CurrencyEnumCodes.USD);
            var change = await client.GetCurrencyChangeAsync(CurrencyEnumCodes.USD);
            var rate = await client.GetCurrencyChangeAsync(CurrencyEnumCodes.USD);
            var description = await client.GetCurrencyDescriptionAsync(CurrencyEnumCodes.USD);
            var todayDate = await client.GetCurrentDateAsync();
        }
    }
}

```

## Contributing

Got **something interesting** you'd like to **share**? Feel free to open issue

## Author

[Tornike Gomareli](https://github.com/tornikegomareli)

## Support

If you will like my work, just STAR repository.

Reach out to me at one of the following places:

- Facebook at [FB](https://www.facebook.com/microg)
- Twitter **[tornikegomareli](https://twitter.com/tornikegomareli)**
- E-Mail: **gomarelidevelopment@gmail.com**

## License

[![License: CC BY-NC-SA 4.0](https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-orange.svg?style=flat-square)](https://creativecommons.org/licenses/by-nc-sa/4.0/)

- Copyright © [TornikeGomareli](https://twitter.com/tornikegomareli).
