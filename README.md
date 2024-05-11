# Simple-String-Parser
A simple string parser with extremely permissive syntax

# Syntax
>Health = 20;

>Size = 32, 32;

>Recovery = 0.5

>Dead = false;

>Name = Jimmy;

# permissive syntax
As mentioned before, the syntax is extremely permissive. `10Jimmy0` is a valid string, int and float because the parser for ints and floats skips anything thats not a number so it will read `10Jimmy0` as 100

It treats everything as a list. So for examply it treats `health` as a list with one item. If you try to read a value that isn't there, it will print a warning, and return an empty array.
You could also use the GetTypeOrDef functions that looks for a value that matches a certain name, and if it can't find it, it will print a warning and return a default value.

