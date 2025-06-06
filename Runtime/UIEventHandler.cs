using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    [Serializable]
    public class ClickEvents
    {
        public bool Enable = false;

        [Space]
        public UnityEvent<ClickEvent> OnClickEvent;
        public UnityEvent OnClick;
    }

    [Serializable]
    public class KeyEvents
    {
        public bool Enable = false;

        [Space]
        public UnityEvent<KeyDownEvent> OnKeyDownEvent;
        public UnityEvent<KeyCode> OnKeyDown;
        public UnityEvent<KeyUpEvent> OnKeyUpEvent;
        public UnityEvent<KeyCode> OnKeyUp;
    }

    [Serializable]
    public class PointerEvents
    {
        public bool Enable = false;

        [Space]
        public UnityEvent<PointerDownEvent> OnPointerDownEvent;
        public UnityEvent<Vector3> OnPointerDown;
        public UnityEvent<PointerUpEvent> OnPointerUpEvent;
        public UnityEvent<Vector3> OnPointerUp;
        public UnityEvent<PointerEnterEvent> OnPointerEnterEvent;
        public UnityEvent<Vector3> OnPointerEnter;
        public UnityEvent<PointerLeaveEvent> OnPointerLeaveEvent;
        public UnityEvent<Vector3> OnPointerLeave;
    }

    [Serializable]
    public class OnFocusEvents
    {
        public bool Enable = false;

        [Space]
        public UnityEvent<FocusEvent> OnFocusEvent;
        public UnityEvent OnFocus;
        public UnityEvent<BlurEvent> OnBlurEvent;
        public UnityEvent OnBlur;
    }

    [AddComponentMenu("UI Toolkit/UI Event Handler")]
    public class UIEventHandler : BaseScriptComponent<VisualElement>
    {
        public ClickEvents ClickEvents;
        public KeyEvents KeyEvents;
        public PointerEvents PointerEvents;
        public OnFocusEvents FocusEvents;

        private void OnEnable() =>
            RegisterEvents();

        private void OnDisable() =>
            UnregisterEvents();

        private void RegisterEvents()
        {
            if (!HasElements)
                return;

            foreach (var element in LinkedElements)
            {
                if (element == null)
                    continue;

                if (ClickEvents.Enable)
                    if (ClickEvents.OnClickEvent != null || ClickEvents.OnClick != null)
                        element.RegisterCallback<ClickEvent>(onClick);

                if (KeyEvents.Enable)
                {
                    if (KeyEvents.OnKeyDownEvent != null || KeyEvents.OnKeyDown != null) 
                        element.RegisterCallback<KeyDownEvent>(onKeyDown);
                    if (KeyEvents.OnKeyUpEvent != null || KeyEvents.OnKeyUp != null) 
                        element.RegisterCallback<KeyUpEvent>(onKeyUp);
                }

                if (PointerEvents.Enable)
                {
                    if (PointerEvents.OnPointerDownEvent != null || PointerEvents.OnPointerDown != null) 
                        element.RegisterCallback<PointerDownEvent>(onPointerDown);
                    if (PointerEvents.OnPointerUpEvent != null || PointerEvents.OnPointerUp != null) 
                        element.RegisterCallback<PointerUpEvent>(onPointerUp);
                    if (PointerEvents.OnPointerEnterEvent != null || PointerEvents.OnPointerEnter != null) 
                        element.RegisterCallback<PointerEnterEvent>(onPointerEnter);
                    if (PointerEvents.OnPointerLeaveEvent != null || PointerEvents.OnPointerLeave != null) 
                        element.RegisterCallback<PointerLeaveEvent>(onPointerLeave);
                }

                if (FocusEvents.Enable)
                {
                    if (FocusEvents.OnFocusEvent != null)
                        element.RegisterCallback<FocusEvent>(onFocus);
                    if (FocusEvents.OnBlurEvent != null)
                        element.RegisterCallback<BlurEvent>(onBlur);
                }
            }
        }

        private void UnregisterEvents()
        {
            if (!HasElements)
                return;

            foreach (var element in LinkedElements)
            {
                if (element == null)
                    continue;

                if (ClickEvents.Enable)
                    if (ClickEvents.OnClickEvent != null || ClickEvents.OnClick != null)
                        element.UnregisterCallback<ClickEvent>(onClick);

                if (KeyEvents.Enable)
                {
                    if (KeyEvents.OnKeyDownEvent != null || KeyEvents.OnKeyDown != null) 
                        element.UnregisterCallback<KeyDownEvent>(onKeyDown);
                    if (KeyEvents.OnKeyUpEvent != null || KeyEvents.OnKeyUp != null) 
                        element.UnregisterCallback<KeyUpEvent>(onKeyUp);
                }

                if (PointerEvents.Enable)
                {
                    if (PointerEvents.OnPointerDownEvent != null || PointerEvents.OnPointerDown != null) 
                        element.UnregisterCallback<PointerDownEvent>(onPointerDown);
                    if (PointerEvents.OnPointerUpEvent != null || PointerEvents.OnPointerUp != null) 
                        element.UnregisterCallback<PointerUpEvent>(onPointerUp);
                    if (PointerEvents.OnPointerEnterEvent != null || PointerEvents.OnPointerEnter != null) 
                        element.UnregisterCallback<PointerEnterEvent>(onPointerEnter);
                    if (PointerEvents.OnPointerLeaveEvent != null || PointerEvents.OnPointerLeave != null) 
                        element.UnregisterCallback<PointerLeaveEvent>(onPointerLeave);
                }

                if (FocusEvents.Enable)
                {
                    if (FocusEvents.OnFocusEvent != null)
                        element.UnregisterCallback<FocusEvent>(onFocus);
                    if (FocusEvents.OnBlurEvent != null)
                        element.UnregisterCallback<BlurEvent>(onBlur);
                }
            }
        }

        // Click
        private void onClick(ClickEvent evt)
        {
            ClickEvents.OnClickEvent?.Invoke(evt);
            ClickEvents.OnClick?.Invoke();
        }

        // Key
        private void onKeyDown(KeyDownEvent evt)
        {
            KeyEvents.OnKeyDownEvent?.Invoke(evt);
            KeyEvents.OnKeyDown?.Invoke(evt.keyCode);
        }

        private void onKeyUp(KeyUpEvent evt)
        {
            KeyEvents.OnKeyUpEvent?.Invoke(evt);
            KeyEvents.OnKeyUp?.Invoke(evt.keyCode);
        }

        // Pointer
        private void onPointerDown(PointerDownEvent evt)
        {
            PointerEvents.OnPointerDownEvent?.Invoke(evt);
            PointerEvents.OnPointerDown?.Invoke(evt.position);
        }

        private void onPointerUp(PointerUpEvent evt)
        {
            PointerEvents.OnPointerUpEvent?.Invoke(evt);
            PointerEvents.OnPointerUp?.Invoke(evt.position);
        }

        private void onPointerEnter(PointerEnterEvent evt)
        {
            PointerEvents.OnPointerEnterEvent?.Invoke(evt);
            PointerEvents.OnPointerEnter?.Invoke(evt.position);
        }

        private void onPointerLeave(PointerLeaveEvent evt)
        {
            PointerEvents.OnPointerLeaveEvent?.Invoke(evt);
            PointerEvents.OnPointerLeave?.Invoke(evt.position);
        }

        // Focus
        private void onFocus(FocusEvent evt)
        {
            FocusEvents.OnFocusEvent?.Invoke(evt);
            FocusEvents.OnFocus?.Invoke();
        }

        private void onBlur(BlurEvent evt)
        {
            FocusEvents.OnBlurEvent?.Invoke(evt);
            FocusEvents.OnBlur?.Invoke();
        }
    }
}