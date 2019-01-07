using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetVersionDetector
{
    /// <summary>
    /// Contains settings used by <see cref="DotNetVersionDetectorRunner"/>.
    /// </summary>
    public sealed class DotNetVersionDetectorSettings : ToolSettings
    {
        /// <summary>
        /// Gets of sets a value indicating whether or not to output extended information in reports or not.
        /// </summary>
        public bool Extended { get; set; }
  }
}
