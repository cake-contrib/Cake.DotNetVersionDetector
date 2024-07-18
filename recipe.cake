#load nuget:?package=Cake.Recipe&version=3.1.1

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./Source",
                            title: "Cake.DotNetVersionDetector",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.DotNetVersionDetector",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunDotNetCorePack: true,
                            preferredBuildProviderType: BuildProviderType.AzurePipelines,
                            shouldRunCodecov: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
