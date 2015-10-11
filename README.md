# incident-cs
![Logo](http://kornelijepetak.com/incident-logo.png)

Randomization library for .NET
Inspired by the [chance.js](http://chancejs.com/) library.

## Randomization areas:
- [x] Primitives (numbers, strings, etc.)
- [x] Textual elements (words, sentences and paragraphs)
 - [] LoremIpsum
- [x] Human related (names, birthdays, etc.)
 - [] Phones
- [x] Web elements (domains, urls, colors)
- [ ] Geographic data
- [ ] Games related

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
string .GenderString
Gender .Gender
int .Age(HumanAgeCategory ageCategory?)
DateTime .BirthDay(HumanAgeCategory ageCategory?)
string .Prefix(bool shortPrefix?, HumanGender gender?)
string .Suffix(bool shortSuffix?)
```

##### `Incident.Web`
```c#
int .Port
string .StandardTLD
string .CountryCodeTLD
string .TLD
string .Hashtag
string .Email
string .CustomEmail(string tld, bool namesOnly)
string .Domain
string .CustomDomain(string tld, bool includeWWW)
string .Url
string .CustomUrl(string protocol, string extension)
string .IPv4
string .LocalIPv4
string .IPv6
string .Twitter
string .RgbColor
string .RgbaColor
string .HexColor
string .GoogleAnalyticsId
```

## TODO / Other features
- [ ] Consider using Mersene Twister instead of System.Random
