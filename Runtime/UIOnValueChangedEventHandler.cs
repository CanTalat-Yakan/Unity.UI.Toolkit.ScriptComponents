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
    public class UIOnValueChangedEventHandler : BaseScriptComponent
    {
        [HideInInspector] public UIElementType UIType;
#if UNITY_EDITOR
        public void Update() => UIType = Type;
#endif

        [If("UIType", UIElementType.TextElement)]
        public TextFieldEvents TextFieldEvents;
        [If("UIType", UIElementType.Label)]
        public LabelEvents LabelEvents;
        [If("UIType", UIElementType.Slider)]
        public SliderEvents SliderEvents;
        [If("UIType", UIElementType.SliderInt)]
        public SliderIntEvents SliderIntEvents;
        [If("UIType", UIElementType.DropdownField)]
        public DropdownFieldEvents DropdownFieldEvents;
        [If("UIType", UIElementType.Foldout)]
        public FoldoutEvents FoldoutEvents;
        [IfNot("UIType", 
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

            IterateLinkedElements(element =>
            {
                switch (element)
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

            IterateLinkedElements(element =>
            {
                switch (element)
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

        private void OnTextFieldValueChanged(ChangeEvent<string> evt)
        {
            TextFieldEvents.OnTextFieldChanged?.Invoke(evt.newValue);
            TextFieldEvents.OnTextFieldChangedEvent?.Invoke(evt);
        }

        private void OnLabelValueChanged(ChangeEvent<string> evt)
        {
            LabelEvents.OnLabelChanged?.Invoke(evt.newValue);
            LabelEvents.OnLabelChangedEvent?.Invoke(evt);
        }

        private void OnSliderValueChanged(ChangeEvent<float> evt)
        {
            SliderEvents.OnSliderChanged?.Invoke(evt.newValue);
            SliderEvents.OnSliderChangedEvent?.Invoke(evt);
        }

        private void OnSliderIntValueChanged(ChangeEvent<int> evt)
        {
            SliderIntEvents.OnSliderIntChanged?.Invoke(evt.newValue);
            SliderIntEvents.OnSliderIntChangedEvent?.Invoke(evt);
        }

        private void OnDropdownFieldValueChanged(ChangeEvent<string> evt)
        {
            DropdownFieldEvents.OnDropdownFieldChanged?.Invoke(evt.newValue);
            DropdownFieldEvents.OnDropdownFieldChangedEvent?.Invoke(evt);
        }

        private void OnFoldoutValueChanged(ChangeEvent<bool> evt)
        {
            FoldoutEvents.OnFoldoutChanged?.Invoke(evt.newValue);
            FoldoutEvents.OnFoldoutChangedEvent?.Invoke(evt);
        }
    }
}