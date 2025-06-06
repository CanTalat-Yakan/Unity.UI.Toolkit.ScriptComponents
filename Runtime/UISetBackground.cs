using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    public class UISetBackground : BaseScriptComponent<VisualElement>
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
                if (BackgroundTexture != null)
                    element.style.backgroundImage = new StyleBackground(BackgroundTexture);
                else element.style.backgroundColor = BackgroundColor;
            });
        }
    }
}
