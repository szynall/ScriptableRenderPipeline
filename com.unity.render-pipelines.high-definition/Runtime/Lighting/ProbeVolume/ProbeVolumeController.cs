using UnityEngine.Rendering;
using UnityEngine.Serialization;
using System;

namespace UnityEngine.Rendering.HighDefinition
{
    [VolumeComponentMenu("Lighting/Probe Volume Global Illumination")]
    internal class ProbeVolumeController : VolumeComponent
    {
        [Serializable]
        internal sealed class LeakMitigationModeParameter : VolumeParameter<LeakMitigationMode>
        {
            public LeakMitigationModeParameter(LeakMitigationMode value, bool overrideState = false)
                : base(value, overrideState) {}
        }

        [SerializeField, Tooltip("Selects the heuristic used for mitigating light leaking and self-shadowing artifacts when sampling from the probe volumes.")]
        internal LeakMitigationModeParameter leakMitigationMode = new LeakMitigationModeParameter(LeakMitigationMode.NormalBias);

        [SerializeField, Tooltip("Controls the distance in world space to bias along the surface normal to mitigate light leaking self-shadow artifacts.")]
        internal MinFloatParameter normalBiasWS = new MinFloatParameter(0.0f, 0.0f);

        [SerializeField, Tooltip("Controls the strength of our bilateral filter. 0.0 falls back to trilinear filtering. 1.0 is maximum cross term (geometric or validity).")]
        internal ClampedFloatParameter bilateralFilterWeight = new ClampedFloatParameter(1.0f, 0.0f, 1.0f);

        ProbeVolumeController()
        {
            displayName = "Probe Volume Controller";
        }
    }
} // UnityEngine.Experimental.Rendering.HDPipeline
