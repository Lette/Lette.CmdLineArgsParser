Lette.CmdLineArgsParser
=======================

Parses command line arguments, and returns an object with the parsed settings.

The parser can handle boolean (on/off) arguments, as well as nameless arguments and key/value arguments.

### How to

First, create a class that the parser can use to react to (usually just store) the informatione retrieved from the command line arguments. This class is instantiated in the parser and must have a default constuctor.

```
public class Settings
{
  public boolean Flag { get; set; }
  public string NamedArgument { get; set; }
  public string NamelessArgument { get; set; }
}
```

Then, create a list of rules for the parser.

```
private static readonly ArgumentRuleList<Settings> _rules = new ArgumentRuleList<Settings>
  {
    { new[] { "-f", "--flag" },           s => s.Flag = true },
    { new[] { "-n", "--named-argument" }, (s, p) => s.NamedArgument = p },
    (s, p) => s.NamelessArgument = p
  };
```
(What does all of this mean? See "Argument Rules" below.)

Finally, instantiate a `ArgumentsParser` and `Parse`.

```
var parser = new ArgumentsParser<Settings>();
var settings = parser.Parse(_rules);
```

If your command line was `executable.exe -f --named-argument named-arg unnamed-arg`, then the properties in `settings` will be:
* `Flag == true`
* `NamedArgument == "named-arg"`
* `NamelessArgument == "unnamed-arg"`


*(Everything below this line is work in progress.)*

### Argument Rules
The argument rules define what the parser should be looking for and what it should do with what it finds.

#### KeyArgumentRule
Boolean / on/off rule ...

#### KeyValueArgumentRule
Extracts the value on the command line that follows directly after a named argument.
```
--named-argument value
```

#### ValueArgumentRule
The list of rules may have at most one rule of this type. It's effectively a "catch all" type of rule. Every argument that cannot be matched to any other rule will be picked up by.

### "Advanced" concepts

#### Sensible defaults in the settings class
#### Error handling / `ArgumentException`s
#### Handling multiple unnamed arguments
#### Case insensitivity
#### Order insensitivity
#### Supplying custom arguments
The second parameter to the `ArgumentsParser<T>.Parse` method is optional. If you don't provide it, the parser will default to read command line arguments from `Environment.GetCommandLienArgs()`.
```
var parser = new ArgumentsParser<Settings>();
var args = new[] { "custom", "list", "of", "arguments" };
var settings = parser.Parse(_rules, args);
```
