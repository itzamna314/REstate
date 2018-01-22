﻿using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios.Contextual;
using LightBDD.Framework.Scenarios.Extended;
using REstate.Remote.Tests.Features.Context;
using REstate.Tests.Features.Templates;

// ReSharper disable InconsistentNaming

namespace REstate.Remote.Tests.Features
{
    [FeatureDescription(@"
In order to support cloud scaling
As a developer
I want to delete Machines from a remote server")]
    [ScenarioCategory("Machine Deletion")]
    [ScenarioCategory("Remote")]
    [ScenarioCategory("gRPC")]
    public class MachineDeletion
        : MachineDeletionScenarios<REstateRemoteContext<string, string>>
    {        
        protected override Task<CompositeStep> Given_host_configuration_is_applied()
        {
            return Task.FromResult(
                CompositeStep
                    .DefineNew()
                    .WithContext(Context)
                    .AddAsyncSteps(
                        _ => _.Given_a_REstate_gRPC_Server_running(),
                        _ => _.Given_the_default_agent_is_gRPC_remote())
                    .Build());
        }
    }
}
