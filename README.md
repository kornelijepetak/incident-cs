# incident-cs
![Logo](http://kornelijepetak.com/incident-logo.png)

Randomization library for .NET
Inspired by the [chance.js](http://chancejs.com/) library.

## Randomization areas:
- [x] Primitives (numbers, strings, etc.)
- [x] Textual elements (words, sentences and paragraphs)
 - [ ] LoremIpsum
- [x] Human related (names, birthdays, etc.)
 - [ ] Phones
- [x] Web elements (domains, urls, colors)
- [x] Business data
- [x] Games related
- [ ] Geographic data

## Currently available functions

##### `Incident.Primitive`
```c#
bool .Boolean

byte .Byte
byte .ByteBetween(int start, int end)

sbyte .SignedByte
sbyte .SignedByteBetween(int start, int end)

short .Short
short .PositiveShort
short .ShortBetween(int start, int end)

ushort .UnsignedShort
ushort .UnsignedShortBetween(int start, int end)

int .Integer
int .PositiveInteger
int .IntegerBetween(int start, int end)

uint .UnsignedInteger
uint .UnsignedIntegerBetween(int start, int end)

float .Float
float .FloatUnit
float .FloatBetween(float start, float end)

double .Double
double .DoubleUnit
double .DoubleBetween(double start, double end)

Guid .Guid

DateTime .DateTime
DateTime .TimeBetween(DateTime start, DateTime end)
```

##### `Incident.Text`
```c#
char .ConsonantCharacter
string .Consonant
char .VowelCharacter
string .Vowel
string .Syllable

string .Word
string .Sentence
string .Paragraph
```

##### `Incident.Human`
```c#
string .FirstName
string .LastName
string .FullName

string .Prefix(bool shortPrefix?, HumanGender gender?)
string .Suffix(bool shortSuffix?)

string .GenderString
Gender .Gender

int .Age(HumanAgeCategory ageCategory?)
DateTime .BirthDay(HumanAgeCategory ageCategory?)
```

##### `Incident.Web`
```c#
int .Port

string .StandardTLD
string .CountryCodeTLD
string .TLD

string .Email
string .CustomEmail(string tld?, bool namesOnly?)

string .Domain
string .CustomDomain(string tld?, bool includeWWW?)

string .Url
string .CustomUrl(string protocol?, string extension?)

string .IPv4
string .LocalIPv4
string .IPv6

string .RgbColor
string .RgbaColor
string .HexColor

string .Hashtag
string .Twitter
string .GoogleAnalyticsId
```

##### `Incident.Geo`
```c#
string .FullAddress 
string .Address 
string .Street 
string .ZIP 
string .PostalCode 

string .City 
string .State 
string .Country 
string .ImaginaryCountry 

double .Altitude 
double .CustomAltitude(int precision)

double .Depth 
double .CustomDepth(int precision)

double .Latitude 
double .CustomLatitude(int precision)

double .Longitude 
double .CustomLongitude(int precision)

string .Coordinates 
string .CustomCoordinates(int precision)

string .GeoHash 
```

##### `Incident.Time`
```c#
string .AmPm 

DateTime .Time(DateTime from, DateTime to)

int .UnixTimestamp 
long .Hammertime 

int .Hour 
int .Minute 
int .Second 
int .Millisecond 

int .Day 
int .Month 
int .Year 
int .LeapYear 

int .CustomYear(int min, int max, bool onlyLeapYears?)
```

##### `Incident.Business`
```c#
string .CompanyType
string .Company
```

##### `Incident.Games`
```c#
int .D2
int .D3
int .D4
int .D6
int .D8
int .D10
int .D12
int .D20
int .D100
int .Dice(int sideCount)

PokerSuit .PokerSuit
PokerRank .PokerRank
```

##### `Incident.Utils`
```c#
IRandomWheel<T> .CreateWheel<T>(Dictionary<T, double> chances, bool saveChances?)
string .Repeat(Func<string> itemGenerator, int count)
```

##### `[Extension methods]`
```c#
T IEnumerable<T>.ChooseAtRandom<T>()
T IList<T>.PickAtRandom<T>()
void IList<T>.Shuffle<T>()
string string.Capitalize()
IEnumerable<T> IEnumerable<T>.Repeat(int count)

```


## TODO / Other features
- [ ] Consider using Mersene Twister instead of System.Random
