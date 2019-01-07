using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetVersionDetector
{
    /// <summary>
    /// The .Net Version Detector Runner
    /// </summary>
    public class DotNetVersionDetectorRunner : Tool<DotNetVersionDetectorSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetVersionDetectorRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator</param>
        public DotNetVersionDetectorRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator)
            : base(fileSystem, environment, processRunner, toolLocator)
        {
            _environment = environment;
        }

        /// <summary>
        /// Generates the .Net Version Detector Report in both txt and xml format.
        /// </summary>
        /// <param name="outputFilePath">The output file path.</param>
        /// <param name="settings">The settings.</param>
        public void Run(FilePath outputFilePath, DotNetVersionDetectorSettings settings)
        {
            if (outputFilePath == null)
            {
                throw new ArgumentNullException(nameof(outputFilePath));
            }

            settings = settings ?? new DotNetVersionDetectorSettings();

            Run(settings, GetArguments(outputFilePath, settings));
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "DotNetVersionDetector";
        }

        /// <summary>
        /// Gets the name of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "dotnetversions.exe" };
        }

        private ProcessArgumentBuilder GetArguments(FilePath outputFilePath, DotNetVersionDetectorSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.AppendQuoted(outputFilePath.MakeAbsolute(_environment).FullPath);

            if (settings.Extended)
            {
                builder.Append("/extended");
            }

            return builder;
        }
    }
}
