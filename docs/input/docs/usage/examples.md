---
Title: Examples
---
# Install the DotNetVersionDetector

The DotNetVersionDetector (`dotnetversion.exe`) needs to be installed on your system before
Cake.DotNetVersionDetector can make use of it.

You can download and install it manually from the [ASoft website](https://www.asoft.be/prod_netver.html).
Alternatively, you can install it by utilizing [Chocolatey](https://chocolatey.org):

```pwsh
choco install dotnetversiondetector
```

# Basic Usage

In order to use Cake.DotNetVersionDetector, you will need to add the following to your Cake script:

```csharp
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.DotNetVersionDetector&version=0.1.0"
```

**NOTE:** Depending on the currently released version, you might want to change the above to reflect the current version number.  The above is shown to ensure that the best practice of pinning your Cake Addin version numbers is adhered to.

Then you execute DotNetVersionDetector using:

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