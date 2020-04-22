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

It comes with a built-in **optimized**, **simple** client which can be used to make all the basic requests to the Georgian LARI currency API.

You don't need to look up anything about how the API works and how you have to manage the SOAP requests.(compared to default settings). With the help of an abstraction layer it will be just a few lines to make things work.

Supported Currencies:

```
AED, AMD, AUD, AZN, BGN, BYR, CAD, CHF, CNY, CZK, DKK, EEK, EGP, EUR, GBP, HKD, HUF, ILS, INR, IRR, ISK, JPY, KGS, KWD, KZT, LTL, LVL, MDL, NOK, NZD, PLN, RON, RSD, RUB, SEK, SGD, TJS, TMT, TRY, UAH, USD, UZS
```

## Installation

![Demonstration](https://media.giphy.com/media/W2p1C9gme1ExcyxyT6/giphy.gif)

##### There are three ways to install the NBGCurrencyNET package :shipit:

- Download/Clone and just put the binary in your project :+1:

- Use Visual Studio Package Console :+1:

```
Install-Package nbgcurrencynet -Version 1.0.0
```

- Use dotnet CLI :+1:

```
dotnet add package nbgcurrencynet --version 1.0.0
```

## Using NBGCurrencyNET in your project

You can use NBGCurrencyNET in you project by directly `using` the main namespace.

To get you up and running, let's take a look at few usage examples.

Our Hello World project has just one source file, `Program.cs` which looks like this:

Main client is the NBGCurrencyClient, which is a thread-safe singleton. All required methods are located in this class.
Of course all of the methods are async and you need to call them with await.

- `GetCurrencyAsync` -> `float`
- `GetCurrencyChangeAsync` -> `float`
- `GetCurrencyDescriptionAsync` -> `string`
- `GetCurrencyRateAsync` -> `int`
- `GetCurrentDateAsync` -> `DateTimeOffset`

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

Got **something interesting** you'd like to **share**? Feel free to open an issue and share your ideas.

## Author

[Tornike Gomareli](https://github.com/tornikegomareli)

## Support

If you will like my work, make sure to star the repository.

Reach out to me at one of my socials:

- [Facebook](https://www.facebook.com/microg)
- [Twitter](https://twitter.com/tornikegomareli)
- [E-Mail](mailto:gomarelidevelopment@gmail.com)
