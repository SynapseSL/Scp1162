using System;
using Neuron.Core.Meta;
using Neuron.Modules.Configs.Localization;

namespace Scp1162;

[Automatic]
[Serializable]
public class Translation : Translations<Translation>
{
    public string Message { get; set; } = "You have changed your Item in <color=red>SCP</color>-1162";

    public float Duration { get; set; } = 5;
}