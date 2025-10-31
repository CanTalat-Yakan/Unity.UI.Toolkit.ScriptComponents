using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    [Serializable]
    public class TextFieldEvents
    {
        public UnityEvent<string> OnTextFieldChanged;
        public UnityEvent<ChangeEvent<string>> OnTextFieldChangedEvent;
    }

    [Serializable]
    public class LabelEvents
    {
        public UnityEvent<string> OnLabelChanged;
        public UnityEvent<ChangeEvent<string>> OnLabelChangedEvent;
    }

    [Serializable]
    public class SliderEvents
    {
        public UnityEvent<float> OnSliderChanged;
        public UnityEvent<ChangeEvent<float>> OnSliderChangedEvent;
    }

    [Serializable]
    public class SliderIntEvents
    {
        public UnityEvent<int> OnSliderIntChanged;
        public UnityEvent<ChangeEvent<int>> OnSliderIntChangedEvent;
    }

    [Serializable]
    public class DropdownFieldEvents
    {
        public UnityEvent<string> OnDropdownFieldChanged;
        public UnityEvent<ChangeEvent<string>> OnDropdownFieldChangedEvent;
    }

    [Serializable]
    public class FoldoutEvents
    {
        public UnityEvent<bool> OnFoldoutChanged;
        public UnityEvent<ChangeEvent<bool>> OnFoldoutChangedEvent;
    }

    [ExecuteAlways]
    [AddComponentMenu("UI Toolkit/UI On Value Changed Event Handler")]
    public class UIOnValueChangedEventHandler : UIScriptComponentBase
    {
        [HideInInspector] public UIElementType UIType;
#if UNITY_EDITOR
        public void Update() => UIType = Type;
#endif

        [ShowIf("UIType", UIElementType.TextElement)]
        public TextFieldEvents TextFieldEvents;
        [ShowIf("UIType", UIElementType.Label)]
        public LabelEvents LabelEvents;
        [ShowIf("UIType", UIElementType.Slider)]
        public SliderEvents SliderEvents;
        [ShowIf("UIType", UIElementType.SliderInt)]
        public SliderIntEvents SliderIntEvents;
        [ShowIf("UIType", UIElementType.DropdownField)]
        public DropdownFieldEvents DropdownFieldEvents;
        [ShowIf("UIType", UIElementType.Foldout)]
        public FoldoutEvents FoldoutEvents;
        [ShowIfNot("UIType", 
            UIElementType.TextElement, 
            UIElementType.Label, 
            UIElementType.Slider, 
            UIElementType.SliderInt, 
            UIElementType.DropdownField,
            UIElementType.Foldout)]
        [Info(MessageType.Warning)]
        public string Warning = "UI OnValueChanged EventHandler only supports the following element types: " +
            "TextElement, Label, Slider, SliderInt, DropdownField, and Foldout.";

        private void OnEnable() =>
            RegisterEvents();

        private void OnDisable() =>
            UnregisterEvents();

        private void OnDestroy() =>
            UnregisterEvents();

        private void RegisterEvents()
        {
            if (!HasElements)
                return;

            IterateLinkedElements(e =>
            {
                switch (e)
                {
                    case TextField textField:
                        textField.RegisterValueChangedCallback(OnTextFieldValueChanged);
                        break;
                    case Label label:
                        label.RegisterValueChangedCallback(OnLabelValueChanged);
                        break;
                    case Slider slider:
                        slider.RegisterValueChangedCallback(OnSliderValueChanged);
                        break;
                    case SliderInt sliderInt:
                        sliderInt.RegisterValueChangedCallback(OnSliderIntValueChanged);
                        break;
                    case DropdownField dropdownField:
                        dropdownField.RegisterValueChangedCallback(OnDropdownFieldValueChanged);
                        break;
                    case Foldout foldout:
                        foldout.RegisterValueChangedCallback(OnFoldoutValueChanged);
                        break;
                }
            });
        }

        private void UnregisterEvents()
        {
            if (!HasElements)
                return;

            IterateLinkedElements(e =>
            {
                switch (e)
                {
                    case TextField textField:
                        textField.UnregisterValueChangedCallback(OnTextFieldValueChanged);
                        break;
                    case Label label:
                        label.UnregisterValueChangedCallback(OnLabelValueChanged);
                        break;
                    case Slider slider:
                        slider.UnregisterValueChangedCallback(OnSliderValueChanged);
                        break;
                    case SliderInt sliderInt:
                        sliderInt.UnregisterValueChangedCallback(OnSliderIntValueChanged);
                        break;
                    case DropdownField dropdownField:
                        dropdownField.UnregisterValueChangedCallback(OnDropdownFieldValueChanged);
                        break;
                    case Foldout foldout:
                        foldout.UnregisterValueChangedCallback(OnFoldoutValueChanged);
                        break;
                }
            });
        }

        private void OnTextFieldValueChanged(ChangeEvent<string> e)
        {
            TextFieldEvents.OnTextFieldChanged?.Invoke(e.newValue);
            TextFieldEvents.OnTextFieldChangedEvent?.Invoke(e);
        }

        private void OnLabelValueChanged(ChangeEvent<string> e)
        {
            LabelEvents.OnLabelChanged?.Invoke(e.newValue);
            LabelEvents.OnLabelChangedEvent?.Invoke(e);
        }

        private void OnSliderValueChanged(ChangeEvent<float> e)
        {
            SliderEvents.OnSliderChanged?.Invoke(e.newValue);
            SliderEvents.OnSliderChangedEvent?.Invoke(e);
        }

        private void OnSliderIntValueChanged(ChangeEvent<int> e)
        {
            SliderIntEvents.OnSliderIntChanged?.Invoke(e.newValue);
            SliderIntEvents.OnSliderIntChangedEvent?.Invoke(e);
        }

        private void OnDropdownFieldValueChanged(ChangeEvent<string> e)
        {
            DropdownFieldEvents.OnDropdownFieldChanged?.Invoke(e.newValue);
            DropdownFieldEvents.OnDropdownFieldChangedEvent?.Invoke(e);
        }

        private void OnFoldoutValueChanged(ChangeEvent<bool> e)
        {
            FoldoutEvents.OnFoldoutChanged?.Invoke(e.newValue);
            FoldoutEvents.OnFoldoutChangedEvent?.Invoke(e);
        }
    }
}