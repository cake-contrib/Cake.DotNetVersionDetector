using System;
using Cake.Core;
using Cake.DotNetVersionDetector.Tests.Attributes;
using Cake.Testing;
using Xunit;

namespace Cake.DotNetVersionDetector.Tests
{
    public sealed class DotNetVersionDetectorRunnerTests
    {
        public sealed class TheExecutable
        {
            [Fact]
            public void Should_Throw_If_DotNetVersionDetector_Runner_Was_Not_Found()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("DotNetVersionDetector: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/DotNetVersionDetector/dotnetversions.exe", "/bin/tools/DotNetVersionDetector/dotnetversions.exe")]
            [InlineData("./tools/DotNetVersionDetector/dotnetversions.exe", "/Working/tools/DotNetVersionDetector/dotnetversions.exe")]
            public void Should_Use_DotNetVersionDetector_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture { Settings = { ToolPath = toolPath } };
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [WindowsTheory]
            [InlineData("C:/DotNetVersionDetector/dotnetversions.exe", "C:/DotNetVersionDetector/dotnetversions.exe")]
            public void Should_Use_DotNetVersionDetector_Runner_From_Tool_Path_If_Provided_On_Windows(string toolPath, string expected)
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture { Settings = { ToolPath = toolPath } };
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Find_DotNetVersionDetector_Runner_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/dotnetversions.exe", result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Output_File_Is_Null()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture
                {
                    OutputFilePath = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("outputFilePath", ((ArgumentNullException)result).ParamName);
            }

            [Fact]
            public void Should_Set_Working_Directory()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working", result.Process.WorkingDirectory.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("DotNetVersionDetector: Process was not started.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("DotNetVersionDetector: Process returned an error (exit code 1).", result.Message);
            }

            [WindowsTheory]
            [InlineData("\"c:/temp/output.txt\" /extended")]
            public void Should_Set_Extended_On_Windows(string expected)
            {
                // Given
                var fixture = new DotNetVersionDetectorRunnerFixture { Settings = { Extended = true } };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}
