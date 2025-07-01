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
        private void OnClick(ClickEvent e)
        {
            ClickEvents.OnClickEvent?.Invoke(e);
            ClickEvents.OnClick?.Invoke();
        }

        // Key
        private void OnKeyDown(KeyDownEvent e)
        {
            KeyEvents.OnKeyDownEvent?.Invoke(e);
            KeyEvents.OnKeyDown?.Invoke(e.keyCode);
        }

        private void OnKeyUp(KeyUpEvent e)
        {
            KeyEvents.OnKeyUpEvent?.Invoke(e);
            KeyEvents.OnKeyUp?.Invoke(e.keyCode);
        }

        // Pointer
        private void OnPointerDown(PointerDownEvent e)
        {
            PointerEvents.OnPointerDownEvent?.Invoke(e);
            PointerEvents.OnPointerDown?.Invoke(e.position);
        }

        private void OnPointerUp(PointerUpEvent e)
        {
            PointerEvents.OnPointerUpEvent?.Invoke(e);
            PointerEvents.OnPointerUp?.Invoke(e.position);
        }

        private void OnPointerEnter(PointerEnterEvent e)
        {
            PointerEvents.OnPointerEnterEvent?.Invoke(e);
            PointerEvents.OnPointerEnter?.Invoke(e.position);
        }

        private void OnPointerLeave(PointerLeaveEvent e)
        {
            PointerEvents.OnPointerLeaveEvent?.Invoke(e);
            PointerEvents.OnPointerLeave?.Invoke(e.position);
        }

        // Focus
        private void OnFocus(FocusEvent e)
        {
            FocusEvents.OnFocusEvent?.Invoke(e);
            FocusEvents.OnFocus?.Invoke();
        }

        private void OnBlur(BlurEvent e)
        {
            FocusEvents.OnBlurEvent?.Invoke(e);
            FocusEvents.OnBlur?.Invoke();
        }
    }
}