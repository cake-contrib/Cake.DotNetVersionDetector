---
Title: Examples
---

# Basic Usage

In order to use Cake.DotNetVersionDetector, you will need to add the following to your Cake script:

```csharp
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.DotNetVersionDetector&version=0.1.0"
```

**NOTE:** Depending on the currently released version, you might want to change the above to reflect the current version number.  The above is shown to ensure that the best practice of pinning your Cake Addin version numbers is adhered to.

And then you execute DotNetVersionDectector, you can use:

```csharp
DotNetVersionDetector("c:/temp/output.txt");;
```
## Extended Output

In order to get additional information generated into the report files, you can set the Extended property via the Settings class:

```csharp
DotNetVersionDetector("c:/temp/output.txt", new DotNetVersionDetectorSettings()
{
    Extended = true
});
```