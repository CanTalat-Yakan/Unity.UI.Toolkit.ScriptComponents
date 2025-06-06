using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    public class UISetLabel : BaseScriptComponent<Label>
    {
        [SerializeField] private string _labelText = "Default Label Text";
        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                UpdateLabelText();
            }
        }

        private void Start() =>
            UpdateLabelText();

        private void UpdateLabelText() =>
            IterateLinkedElements(label => label.text = _labelText);
    }
}
