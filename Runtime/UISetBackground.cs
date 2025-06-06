using UnityEngine;

namespace UnityEssentials
{
    public class UISetBackground : BaseScriptComponent
    {
        [Header("Background Settings")]
        public Color BackgroundColor = Color.white;
        public Texture2D BackgroundTexture;

        protected void OnEnable() =>
            ApplyBackgroundSettings();

        private void ApplyBackgroundSettings()
        {
            IterateLinkedElements(element =>
            {
                element.SetBackgroundImage(BackgroundTexture);
                element.SetBackgroundColor(BackgroundColor);
            });
        }
    }
}
