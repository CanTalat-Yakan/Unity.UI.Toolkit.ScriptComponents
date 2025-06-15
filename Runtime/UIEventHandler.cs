using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace UnityEssentials
{
    [Serializable]
    public class ClickEvents
    {
        public UnityEvent<ClickEvent> OnClickEvent;
        public UnityEvent OnClick;
    }

    [Serializable]
    public class KeyEvents
    {
        public UnityEvent<KeyDownEvent> OnKeyDownEvent;
        public UnityEvent<KeyCode> OnKeyDown;
        public UnityEvent<KeyUpEvent> OnKeyUpEvent;
        public UnityEvent<KeyCode> OnKeyUp;
    }

    [Serializable]
    public class PointerEvents
    {
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
        public UnityEvent<FocusEvent> OnFocusEvent;
        public UnityEvent OnFocus;
        public UnityEvent<BlurEvent> OnBlurEvent;
        public UnityEvent OnBlur;
    }

    [ExecuteAlways]
    [AddComponentMenu("UI Toolkit/UI Event Handler")]
    public class UIEventHandler : BaseScriptComponent
    {
        public ClickEvents ClickEvents;
        public KeyEvents KeyEvents;
        public PointerEvents PointerEvents;
        public OnFocusEvents FocusEvents;

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
                if (ClickEvents.OnClickEvent != null || ClickEvents.OnClick != null)
                    e.RegisterCallback<ClickEvent>(OnClick);

                if (KeyEvents.OnKeyDownEvent != null || KeyEvents.OnKeyDown != null)
                    e.RegisterCallback<KeyDownEvent>(OnKeyDown);
                if (KeyEvents.OnKeyUpEvent != null || KeyEvents.OnKeyUp != null)
                    e.RegisterCallback<KeyUpEvent>(OnKeyUp);

                if (PointerEvents.OnPointerDownEvent != null || PointerEvents.OnPointerDown != null)
                    e.RegisterCallback<PointerDownEvent>(OnPointerDown);
                if (PointerEvents.OnPointerUpEvent != null || PointerEvents.OnPointerUp != null)
                    e.RegisterCallback<PointerUpEvent>(OnPointerUp);
                if (PointerEvents.OnPointerEnterEvent != null || PointerEvents.OnPointerEnter != null)
                    e.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
                if (PointerEvents.OnPointerLeaveEvent != null || PointerEvents.OnPointerLeave != null)
                    e.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);

                if (FocusEvents.OnFocusEvent != null)
                    e.RegisterCallback<FocusEvent>(OnFocus);
                if (FocusEvents.OnBlurEvent != null)
                    e.RegisterCallback<BlurEvent>(OnBlur);
            });
        }

        private void UnregisterEvents()
        {
            if (!HasElements)
                return;

            IterateLinkedElements(e =>
            {
                if (ClickEvents.OnClickEvent != null || ClickEvents.OnClick != null)
                    e.UnregisterCallback<ClickEvent>(OnClick);

                if (KeyEvents.OnKeyDownEvent != null || KeyEvents.OnKeyDown != null)
                    e.UnregisterCallback<KeyDownEvent>(OnKeyDown);
                if (KeyEvents.OnKeyUpEvent != null || KeyEvents.OnKeyUp != null)
                    e.UnregisterCallback<KeyUpEvent>(OnKeyUp);

                if (PointerEvents.OnPointerDownEvent != null || PointerEvents.OnPointerDown != null)
                    e.UnregisterCallback<PointerDownEvent>(OnPointerDown);
                if (PointerEvents.OnPointerUpEvent != null || PointerEvents.OnPointerUp != null)
                    e.UnregisterCallback<PointerUpEvent>(OnPointerUp);
                if (PointerEvents.OnPointerEnterEvent != null || PointerEvents.OnPointerEnter != null)
                    e.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
                if (PointerEvents.OnPointerLeaveEvent != null || PointerEvents.OnPointerLeave != null)
                    e.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);

                if (FocusEvents.OnFocusEvent != null)
                    e.UnregisterCallback<FocusEvent>(OnFocus);
                if (FocusEvents.OnBlurEvent != null)
                    e.UnregisterCallback<BlurEvent>(OnBlur);
            });
        }

        // Click
        private void OnClick(ClickEvent evt)
        {
            ClickEvents.OnClickEvent?.Invoke(evt);
            ClickEvents.OnClick?.Invoke();
        }

        // Key
        private void OnKeyDown(KeyDownEvent evt)
        {
            KeyEvents.OnKeyDownEvent?.Invoke(evt);
            KeyEvents.OnKeyDown?.Invoke(evt.keyCode);
        }

        private void OnKeyUp(KeyUpEvent evt)
        {
            KeyEvents.OnKeyUpEvent?.Invoke(evt);
            KeyEvents.OnKeyUp?.Invoke(evt.keyCode);
        }

        // Pointer
        private void OnPointerDown(PointerDownEvent evt)
        {
            PointerEvents.OnPointerDownEvent?.Invoke(evt);
            PointerEvents.OnPointerDown?.Invoke(evt.position);
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            PointerEvents.OnPointerUpEvent?.Invoke(evt);
            PointerEvents.OnPointerUp?.Invoke(evt.position);
        }

        private void OnPointerEnter(PointerEnterEvent evt)
        {
            PointerEvents.OnPointerEnterEvent?.Invoke(evt);
            PointerEvents.OnPointerEnter?.Invoke(evt.position);
        }

        private void OnPointerLeave(PointerLeaveEvent evt)
        {
            PointerEvents.OnPointerLeaveEvent?.Invoke(evt);
            PointerEvents.OnPointerLeave?.Invoke(evt.position);
        }

        // Focus
        private void OnFocus(FocusEvent evt)
        {
            FocusEvents.OnFocusEvent?.Invoke(evt);
            FocusEvents.OnFocus?.Invoke();
        }

        private void OnBlur(BlurEvent evt)
        {
            FocusEvents.OnBlurEvent?.Invoke(evt);
            FocusEvents.OnBlur?.Invoke();
        }
    }
}