using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.AzurePipelines.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;

partial class Build
{
    public class AzurePipelinesAttribute : Nuke.Common.CI.AzurePipelines.AzurePipelinesAttribute
    {
        public AzurePipelinesAttribute(AzurePipelinesImage image, params AzurePipelinesImage[] images)
            : base(image, images)
        {
        }

        protected override AzurePipelinesJob GetJob(
            ExecutableTarget executableTarget,
            LookupTable<ExecutableTarget, AzurePipelinesJob> jobs,
            IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var job = base.GetJob(executableTarget, jobs, relevantTargets);

            var dictionary = new Dictionary<string, string>
                             {
                                 { nameof(Compile), "⚙️" },
                                 { nameof(Test), "🚦" },
                                 { nameof(Pack), "📦" },
                                 { nameof(Coverage), "📊" },
                                 { nameof(Publish), "🚚" }
                             };
            var symbol = dictionary.GetValueOrDefault(job.Name).NotNull("symbol != null");
            job.DisplayName = job.Parallel == 0
                ? $"{symbol} {job.DisplayName}"
                : $"{symbol} {job.DisplayName} 🧩";
            return job;
        }
    }
}