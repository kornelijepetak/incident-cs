# incident-cs
![Logo](http://kornelijepetak.com/incident-logo.png)

Randomization library for .NET
Inspired by the [chance.js](http://chancejs.com/) library.

## Currently available functions

##### `Incident.Primitive`
```c#
bool Incident.Primitive.Boolean

byte Incident.Primitive.Byte
byte Incident.Primitive.ByteBetween(int start, int end)

sbyte Incident.Primitive.SignedByte
sbyte Incident.Primitive.SignedByteBetween(int start, int end)

short Incident.Primitive.Short
short Incident.Primitive.PositiveShort
short Incident.Primitive.ShortBetween(int start, int end)

ushort Incident.Primitive.UnsignedShort
ushort Incident.Primitive.UnsignedShortBetween(int start, int end)

int Incident.Primitive.Integer
int Incident.Primitive.PositiveInteger
int Incident.Primitive.IntegerBetween(int start, int end)

uint Incident.Primitive.UnsignedInteger
uint Incident.Primitive.UnsignedIntegerBetween(int start, int end)

float Incident.Primitive.Float
float Incident.Primitive.FloatUnit
float Incident.Primitive.FloatBetween(float start, float end)

double Incident.Primitive.Double
double Incident.Primitive.DoubleUnit
double Incident.Primitive.DoubleBetween(double start, double end)

Guid Incident.Primitive.Guid

DateTime Incident.Primitive.DateTime
DateTime Incident.Primitive.TimeBetween(DateTime start, DateTime end)
```

##### `Incident.Text`
```c#
char Incident.Text.ConsonantCharacter
string Incident.Text.Consonant
char Incident.Text.VowelCharacter
string Incident.Text.Vowel
string Incident.Text.Syllable
string Incident.Text.Word
string Incident.Text.Sentence
string Incident.Text.Paragraph
```

##### `Incident.Human`
```c#
Incident.Human.Age(HumanAgeCategory ageCategory?)
Incident.Human.BirthDay(HumanAgeCategory ageCategory?)
Incident.Human.FirstName
Incident.Human.LastName
Incident.Human.FullName
Incident.Human.GenderString
Incident.Human.Gender
Incident.Human.Prefix(bool shortPrefix?, HumanGender gender?)
Incident.Human.Suffix(bool shortSuffix?)
```

## Randomization areas:
- [ ] Primitives
    - [x] Numerics
    - [x] Guid
    - [ ] Characters
    - [x] DateTime
    - [ ] Timespans
- [ ] Words and sentences
- [ ] Names and Birthdays
- [ ] Phone numbers
- [ ] Geographic data
- [ ] Colors
- [ ] Games related
- [ ] Web related

## Other features
- [ ] Consider using Mersene Twister instead of System.Random
