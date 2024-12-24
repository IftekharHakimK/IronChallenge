# IronChallenge

# Dependency
- Ensure you have .NET Runtime 8.0 or higher installed to run the application.

  If you are building or modifying the source code, you will need the .NET SDK 8.0 or higher.
  Download from: https://dotnet.microsoft.com/en-us/download

# How to use?
Get the [release](https://github.com/IftekharHakimK/IronChallenge/releases/latest/IronChallenge.zip) first and unzip the files.

```
$ dotnet IronChallenge.dll "8 88777444666*664#"
TURING
```

# Warning

- Putting Backspace('*') on empty screen does nothing.
- Putting consecutive 0s without pause result in single space.
- Consecutive pauses have no difference than single pause.

# Development

## Building
```
dotnet build
```

## Running (CLI)
```
dotnet run <input>
```
Examples:
```
$ dotnet run "8 88777444666*664#"
TURING
$ dotnet run "444333833 55  44 333* 2777#"
IFTEKHAR
```
## Testing
```
dotnet test
```

# Deployment Automation
Upon push to *main* branch, github [workflow](/.github/workflows/build_and_release.yml) is automatically triggered. It
can be triggered manually too.