using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

using JetBrains.Annotations;

namespace Cake.DotNetVersionDetector
{
    /// <summary>
    /// <para>Contains functionality related to the <see href="https://www.asoft.be/prod_netver.html">.Net Version Detector</see> tool.</para>
    /// <para>
    /// In order to use the commands for this addin, you will need to have the .Net Version Detector tool available.  This can be installed via Chocolatey.
    /// In addition, you will need to include the following:
    /// <code>
    /// #addin Cake.DotNetVersionDetector
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("DotNetVersionDetector")]
    [PublicAPI]
    public static class DotNetVersionDetectorAliases
    {
        /// <summary>
        /// Runs .Net Version Detector, and outputs to specified output FilePath.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="outputFilePath">The output file path.</param>
        /// <example>
        /// <code>
        /// DotNetVersionDetector("c:/temp/output.txt");
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void DotNetVersionDetector(this ICakeContext context, FilePath outputFilePath)
        {
            DotNetVersionDetector(context, outputFilePath, new DotNetVersionDetectorSettings());
        }

        /// <summary>
        /// Runs .Net Version Detector, and outputs to specified output FilePath with the specified DotNetVersionDetectorSettings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="outputFilePath">The output file path.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// DotNetVersionDetector("c:/temp/output.txt", new DotNetVersionDetectorSettings()
        /// {
        ///     Extended = true
        /// });
        /// </code>
        /// </example>
        [CakeMethodAlias]
        public static void DotNetVersionDetector(this ICakeContext context, FilePath outputFilePath, DotNetVersionDetectorSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (outputFilePath == null)
            {
                throw new ArgumentNullException(nameof(outputFilePath));
            }

            var runner = new DotNetVersionDetectorRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            runner.Run(outputFilePath, settings);
        }
    }
}
