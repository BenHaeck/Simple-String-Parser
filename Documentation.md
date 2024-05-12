
# Constructors
`StringParser (String s)`
creates a string parser with s being the string you want to parse

# properties
`warnOnAccessEmpty`  
if you try to access a value that does not exist, thie controls whether you will get a warning or not

# Methods
### GetAsTypes methods get a value as an array.
`public string[] GetAsStrings (string name)`  
gets the values attached to a name as an array of strings

`public int[] GetAsInts (string name)`  
gets the values attached to a name as an array of ints

`public float[] GetAsFloats (string name)`  
gets the values attached to a name as an array of floats

### GetAsTypeOrDef get a value, or if that value does not exist, it will return a default value
`public string GetAsStringOrDef(string name, string def)`  
gets the first value in a list attach to a name or returns the default value if that name isn't bound to anything

`public int GetAsIntOrDef(string name, int def)`  
gets the first value in a list attach to a name as an int or returns the default value if that name isn't bound to anything

`public float GetAsFloatOrDef(string name, float def)`  
gets the first value in a list attach to a name as a float or returns the default value if that name isn't bound to anything

# Static Functions
`public static int ParseInt (string s)`  
Takes in a string and outputs an integer. Any character that is not a recognized digit (0-9) is skipped, unless its a decimal, in which case, it will end the function. So this function will never throw an error

`public static float ParseFloat (string s)`
Takes in a string and outputs a float. Just like the parse int function, this will ignore and character that is not a diget with the exeption of a decimal

`public static string RemoveWhiteSpace(string)`  
Removes all white space in a string

`public static string RemoveEnclosed (string s, char opening, char closing)`
Removes all characters between an opening character and a closing character. For example `RemoveEnclosed("Hey [this will be removed]thats pretty cool", '[', ']'); // = "Hey thats pretty cool"`

`public static string Serialize (string name, string val)`  
returns a name and value as a string that can be parsed by the parser.

`public static string SerializeAsStringLiteral (string name, string val)`
same as the above serialize function but makes it a string literal (or adds /s to it)

`public static string ArrayToString<T> (T[] a)`
converts an array to a string that can be parsed back into an array again.
