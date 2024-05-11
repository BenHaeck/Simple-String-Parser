# Simple-String-Parser
A simple string parser with extremely permissive syntax

The point of this library is to be able to store and read information to and from a file in a format thats human readable and human editable.
Similar to JSON, but a lot less complex, and with a much more forgiving syntax.

# Syntax
```
Health = 20;  
Size = 32, 32;  
Recovery = 0.5;  
Dead = false;  
Name = Jimmy;  
Backstory = /sI was once a warrior like you  
Then I took an arrow to the knee;
```

Basically, the syntax goes like this  
`name = value1, value2, value3;`  
`stringLiteral = /sLiteraly, literal`  
As long as every line follows these line templates, there valid.

# Permissive syntax
As mentioned before, the syntax is extremely permissive. `10Jimmy0` is a valid string, int and float
because the parsing functions for ints and floats skips any character that is not a number so they will read `10Jimmy0` as 100

It treats everything as a list. So for examply it treats `health` in the previous example as a list with one item.
If you try to read a value that isn't there, it will print a warning, and return an empty array.
You could also use the GetTypeOrDef functions that looks for a value that matches a certain name, and if it can't find it, it will print a warning and return a default value.

/s declares the text to be a string literal. String literals can span multiple lines, and a string literal can not be stored as a list.
This means that you can use commas in them.

