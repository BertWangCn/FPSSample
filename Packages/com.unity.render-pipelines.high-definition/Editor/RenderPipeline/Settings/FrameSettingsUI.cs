using UnityEditor.AnimatedValues;
using UnityEngine.Events;

namespace UnityEditor.Experimental.Rendering.HDPipeline
{
    partial class FrameSettingsUI : BaseUI<SerializedFrameSettings>
    {
        public AnimBool isSectionExpandedRenderingPasses { get { return m_AnimBools[0]; } }
        public AnimBool isSectionExpandedLightingSettings { get { return m_AnimBools[1]; } }
        public AnimBool isSectionExpandedRenderingSettings { get { return m_AnimBools[2]; } }
        public AnimBool isSectionExpandedXRSettings { get { return m_AnimBools[3]; } }
        public AnimBool isSectionExpandedXRSupported { get { return m_AnimBools[4]; } }
        public AnimBool isSectionExpandedUseForwardOnly { get { return m_AnimBools[5]; } }

        public LightLoopSettingsUI lightLoopSettings = new LightLoopSettingsUI();

        public FrameSettingsUI()
            : base(7)
        {
        }

        public override void Reset(SerializedFrameSettings data, UnityAction repaint)
        {
            lightLoopSettings.Reset(data.lightLoopSettings, repaint);
            base.Reset(data, repaint);
        }

        public override void Update()
        {
            isSectionExpandedXRSupported.target = PlayerSettings.virtualRealitySupported;
            isSectionExpandedUseForwardOnly.target = !data.enableForwardRenderingOnly.boolValue;
            lightLoopSettings.Update();
        }
    }
}
