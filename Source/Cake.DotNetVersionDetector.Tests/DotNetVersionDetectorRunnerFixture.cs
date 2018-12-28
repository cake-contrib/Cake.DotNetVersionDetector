using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;
using NSubstitute;

namespace Cake.DotNetVersionDetector.Tests
{
    public class DotNetVersionDetectorRunnerFixture : ToolFixture<DotNetVersionDetectorSettings>
    {
        public ICakeLog Log { get; set; }

        public FilePath InputFilePath { get; set; }

        public FilePath OutputFilePath { get; set; }

        public DotNetVersionDetectorRunnerFixture()
             : base("dotnetversions.exe")
        {
            Log = Substitute.For<ICakeLog>();
            OutputFilePath = "c:/temp/output.txt";
        }

        protected override void RunTool()
        {
            var tool = new DotNetVersionDetectorRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(OutputFilePath, Settings);
        }
    }
}
