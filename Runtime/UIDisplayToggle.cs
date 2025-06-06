using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    [AddComponentMenu("UI Toolkit/UI Display Toggle")]
    public class UIDisplayToggle : BaseScriptComponent<VisualElement>
    {
        [SerializeField] private bool _displayOnStart = true;

        public void Start()
        {
            gameObject.SetActive(_displayOnStart);

            if (gameObject.activeSelf)
                SetEnabled(true);
        }

        public void OnEnable() =>
            SetEnabled(true);

        public void OnDisable() =>
            SetEnabled(false);

        public void SetDisplayOnStart(bool displayOnStart) =>
            _displayOnStart = displayOnStart;

        public void SetEnabled(bool enable)
        {
            if (!HasElements)
                return;

            IterateLinkedElements(e => e.SetDisplayEnabled(enable));
        }

        public bool GetEnabled(int index = 0)
        {
            if (!HasElements || LinkedElements.Length <= index)
                return false;

            return LinkedElements[index].GetDisplayEnabled();
        }

        public void Toggle() =>
            IterateLinkedElements((element) =>
            {
                bool enabled = element.GetDisplayEnabled();
                element.SetDisplayEnabled(!enabled);
            });
    }
}