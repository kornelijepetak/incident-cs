# incident-cs
![Logo](http://kornelijepetak.com/incident-logo.png)

A randomization library for .NET

*(inspired by the [chance.js](http://chancejs.com/) library)*

Over **70 different things** to randomize! 

[Download from NuGet!](https://www.nuget.org/packages/IncidentCS)

```
PM> Install-Package IncidentCS
```


## Get started

[Check the wiki](https://github.com/kornelijepetak/incident-cs/wiki) for the list of available randomizers or see the **example** belosw for the quick start. 

Note that the example shows only a small subset of randomization areas.

## Randomization areas:
- [x] Primitives (numbers, strings, etc.)
- [x] Textual elements (words, sentences and paragraphs)
 - [ ] LoremIpsum
- [x] Human related (names, birthdays, etc.)
- [x] Web elements (domains, urls, colors)
- [x] Business data (phones, companies)
 - [ ] Schools, Universities
- [x] Games related
- [x] Geographic data

## Example

```c#

// Ensures random textual content (i.e. names, words) to be in English language
Incident.Culture = new CultureInfo("en-US"); 

var roles = Incident.Utils.CreateWheel(new Dictionary<string, double>()
{
    // 3 in 100 are bosses
    { "Boss", 3 },
    
    // 12 in 100 are managers
    { "Manager", 12 },
    
    // 85 in 100 (the rest) are workers
    { "Worker", 85 }
});
			
// Randomize a user
var user = new User() 
{ 
    Name = Incident.Human.FullName,
    
    Birthday = Incident.Human.Birthday(HumanAgeCategory.Adult),
    Phone = Incident.Business.Phone,
    
    Address = new Address()
    {
        Street = Incident.Primitive.IntegerBetween(10, 1000) + " " + Incident.Geo.Street,
        City = Incident.Geo.City,
        ZIP = Incident.Geo.ZIP,
        Country = Incident.Geo.Country
    },
    
    Company = Incident.Business.Company,
    Role = roles.RandomElement,
    
    Twitter = Incident.Web.Twitter,
    FavoriteHashTag = Incident.Web.Hashtag,
    FavoriteColor = Incident.Web.HexColor,
    FavoriteQuote = Incident.Text.Sentence
};
```

## Localization / other

You are welcome to add localized randomizers or suggest an improvement. 
Send me a pull request.

## TODO / Other features
- [ ] Consider using Mersene Twister instead of System.Random
