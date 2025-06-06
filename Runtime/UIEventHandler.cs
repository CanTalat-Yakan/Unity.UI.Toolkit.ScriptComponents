using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    [Serializable]
    public class OnFocusEvents
    {
        public bool Enable = false;
        public UnityEvent<FocusEvent> OnFocusWithEvent;
        public UnityEvent OnFocus;
        public UnityEvent<BlurEvent> OnBlurWithEvent;
        public UnityEvent OnBlur;

    }

    [Serializable]
    public class KeyEvents
    {
        public bool Enable = false;
        public UnityEvent<KeyDownEvent> OnKeyDownWithEvent;
        public UnityEvent<KeyCode> OnKeyDown;
        public UnityEvent<KeyUpEvent> OnKeyUpWithEvent;
        public UnityEvent<KeyCode> OnKeyUp;
    }

    [Serializable]
    public class PointerEvents
    {
        public bool Enable = false;
        public UnityEvent<PointerDownEvent> OnPointerDownWithEvent;
        public UnityEvent<Vector3> OnPointerDown;
        public UnityEvent<PointerUpEvent> OnPointerUpWithEvent;
        public UnityEvent<Vector3> OnPointerUp;
        public UnityEvent<PointerEnterEvent> OnPointerEnterWithEvent;
        public UnityEvent<Vector3> OnPointerEnter;
        public UnityEvent<PointerLeaveEvent> OnPointerLeaveWithEvent;
        public UnityEvent<Vector3> OnPointerLeave;
    }

    [Serializable]
    public class ClickEvents
    {
        public bool Enable = false;
        public UnityEvent<ClickEvent> OnClickWithEvent;
        public UnityEvent OnClick;
    }

    [AddComponentMenu("UI Toolkit/UI Event Handler")]
    public class UIEventHandler : BaseScriptComponent<VisualElement>
    {
        public OnFocusEvents FocusEvents;
        public KeyEvents KeyEvents;
        public PointerEvents PointerEvents;
        public ClickEvents ClickEvents;

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

                if (FocusEvents.Enable)
                {
                    if (FocusEvents.OnFocusWithEvent != null) 
                        element.RegisterCallback<FocusEvent>(onFocus);
                    if (FocusEvents.OnBlurWithEvent != null) 
                        element.RegisterCallback<BlurEvent>(onBlur);
                }

                if (KeyEvents.Enable)
                {
                    if (KeyEvents.OnKeyDownWithEvent != null || KeyEvents.OnKeyDown != null) 
                        element.RegisterCallback<KeyDownEvent>(onKeyDown);
                    if (KeyEvents.OnKeyUpWithEvent != null || KeyEvents.OnKeyUp != null) 
                        element.RegisterCallback<KeyUpEvent>(onKeyUp);
                }

                if (PointerEvents.Enable)
                {
                    if (PointerEvents.OnPointerDownWithEvent != null || PointerEvents.OnPointerDown != null) 
                        element.RegisterCallback<PointerDownEvent>(onPointerDown);
                    if (PointerEvents.OnPointerUpWithEvent != null || PointerEvents.OnPointerUp != null) 
                        element.RegisterCallback<PointerUpEvent>(onPointerUp);
                    if (PointerEvents.OnPointerEnterWithEvent != null || PointerEvents.OnPointerEnter != null) 
                        element.RegisterCallback<PointerEnterEvent>(onPointerEnter);
                    if (PointerEvents.OnPointerLeaveWithEvent != null || PointerEvents.OnPointerLeave != null) 
                        element.RegisterCallback<PointerLeaveEvent>(onPointerLeave);
                }

                if (ClickEvents.Enable)
                    if (ClickEvents.OnClickWithEvent != null || ClickEvents.OnClick != null) 
                        element.RegisterCallback<ClickEvent>(onClick);
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

                if (FocusEvents.Enable)
                {
                    if (FocusEvents.OnFocusWithEvent != null) 
                        element.UnregisterCallback<FocusEvent>(onFocus);
                    if (FocusEvents.OnBlurWithEvent != null) 
                        element.UnregisterCallback<BlurEvent>(onBlur);
                }

                if (KeyEvents.Enable)
                {
                    if (KeyEvents.OnKeyDownWithEvent != null || KeyEvents.OnKeyDown != null) 
                        element.UnregisterCallback<KeyDownEvent>(onKeyDown);
                    if (KeyEvents.OnKeyUpWithEvent != null || KeyEvents.OnKeyUp != null) 
                        element.UnregisterCallback<KeyUpEvent>(onKeyUp);
                }

                if (PointerEvents.Enable)
                {
                    if (PointerEvents.OnPointerDownWithEvent != null || PointerEvents.OnPointerDown != null) 
                        element.UnregisterCallback<PointerDownEvent>(onPointerDown);
                    if (PointerEvents.OnPointerUpWithEvent != null || PointerEvents.OnPointerUp != null) 
                        element.UnregisterCallback<PointerUpEvent>(onPointerUp);
                    if (PointerEvents.OnPointerEnterWithEvent != null || PointerEvents.OnPointerEnter != null) 
                        element.UnregisterCallback<PointerEnterEvent>(onPointerEnter);
                    if (PointerEvents.OnPointerLeaveWithEvent != null || PointerEvents.OnPointerLeave != null) 
                        element.UnregisterCallback<PointerLeaveEvent>(onPointerLeave);
                }

                if (ClickEvents.Enable)
                    if (ClickEvents.OnClickWithEvent != null || ClickEvents.OnClick != null) 
                        element.UnregisterCallback<ClickEvent>(onClick);
            }
        }

        // Focus
        private void onFocus(FocusEvent evt)
        {
            FocusEvents.OnFocusWithEvent?.Invoke(evt);
            FocusEvents.OnFocus?.Invoke();
        }

        private void onBlur(BlurEvent evt)
        {
            FocusEvents.OnBlurWithEvent?.Invoke(evt);
            FocusEvents.OnBlur?.Invoke();
        }

        // Key
        private void onKeyDown(KeyDownEvent evt)
        {
            KeyEvents.OnKeyDownWithEvent?.Invoke(evt);
            KeyEvents.OnKeyDown?.Invoke(evt.keyCode);
        }

        private void onKeyUp(KeyUpEvent evt)
        {
            KeyEvents.OnKeyUpWithEvent?.Invoke(evt);
            KeyEvents.OnKeyUp?.Invoke(evt.keyCode);
        }

        // Pointer
        private void onPointerDown(PointerDownEvent evt)
        {
            PointerEvents.OnPointerDownWithEvent?.Invoke(evt);
            PointerEvents.OnPointerDown?.Invoke(evt.position);
        }

        private void onPointerUp(PointerUpEvent evt)
        {
            PointerEvents.OnPointerUpWithEvent?.Invoke(evt);
            PointerEvents.OnPointerUp?.Invoke(evt.position);
        }

        private void onPointerEnter(PointerEnterEvent evt)
        {
            PointerEvents.OnPointerEnterWithEvent?.Invoke(evt);
            PointerEvents.OnPointerEnter?.Invoke(evt.position);
        }

        private void onPointerLeave(PointerLeaveEvent evt)
        {
            PointerEvents.OnPointerLeaveWithEvent?.Invoke(evt);
            PointerEvents.OnPointerLeave?.Invoke(evt.position);
        }

        // Click
        private void onClick(ClickEvent evt)
        {
            ClickEvents.OnClickWithEvent?.Invoke(evt);
            ClickEvents.OnClick?.Invoke();
        }
    }
}