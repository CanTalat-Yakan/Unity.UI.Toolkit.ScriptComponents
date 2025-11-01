# Unity Essentials

This module is part of the Unity Essentials ecosystem and follows the same lightweight, editor-first approach.
Unity Essentials is a lightweight, modular set of editor utilities and helpers that streamline Unity development. It focuses on clean, dependency-free tools that work well together.

All utilities are under the `UnityEssentials` namespace.

```csharp
using UnityEssentials;
```

## Installation

Install the Unity Essentials entry package via Unity's Package Manager, then install modules from the Tools menu.

- Add the entry package (via Git URL)
    - Window → Package Manager
    - "+" → "Add package from git URL…"
    - Paste: `https://github.com/CanTalat-Yakan/UnityEssentials.git`

- Install or update Unity Essentials packages
    - Tools → Install & Update UnityEssentials
    - Install all or select individual modules; run again anytime to update

---

# UI Toolkit Script Components

> Quick overview: Drop-in MonoBehaviours for common UI Toolkit tasks - event routing, OnValueChanged handlers, label/background setters, and display toggling - powered by the UI Element Linker. No custom editor code required.

This module bundles small, focused behaviours that work with the Element Linker to control and listen to UI Toolkit elements without boilerplate. Add them to a GameObject alongside a `UIElementLink` or `UIElementQuery` to forward click/key/pointer/focus events, react to value changes in common controls, set labels and backgrounds, and toggle display - all in Edit or Play Mode and across one or many linked elements.

![screenshot](Documentation/Screenshot.png)

## Features
- UI Element linking (via Element Linker)
  - Bind one or many VisualElements from a UIDocument using `UIElementLink` (single) or `UIElementQuery` (query by name/class/type)
  - Components work on the linked set; no manual `root.Q()` in your scripts
- Components included
  - UI Event Handler (`UIEventHandler`)
    - UnityEvents for: Click, Key (Down/Up with `KeyCode`), Pointer (Down/Up/Enter/Leave with `Vector3`), Focus/Blur
    - Also exposes typed event payloads (`ClickEvent`, `KeyDownEvent`, etc.) if you need the full UI Toolkit event
    - Registers only the callbacks you’ve assigned → minimal overhead; unregisters on disable/destroy
  - UI On Value Changed Handler (`UIOnValueChangedEventHandler`)
    - Routes `ChangeEvent<T>` for supported elements: `TextField`, `Label`, `Slider`, `SliderInt`, `DropdownField`, `Foldout`
    - Two UnityEvents per type: one with the new value (e.g., `float`, `string`, `bool`) and one with the full `ChangeEvent<T>`
    - Clean inspector using `[ShowIf]` to show only relevant sections per linked element type
  - UI Set Label (`UISetLabel`)
    - Sets the `Label.text` of all linked `Label` elements
    - Simple `LabelText` property updates the UI immediately
  - UI Set Background (`UISetBackground`)
    - Sets background color and/or texture on all linked elements (uses UI Toolkit Extensions)
  - UI Display Toggle (`UIDisplayToggle`)
    - Shows/hides linked elements using `display: flex/none`
    - Optional "Display On Start" and a public `Toggle()` method
- Works in Edit Mode (where applicable)
  - `UIEventHandler` and `UIOnValueChangedEventHandler` are `[ExecuteAlways]` so you can test from the editor

## Requirements
- Unity Editor 6000.0+ (Editor/Runtime UI Toolkit)
- A `UIDocument` in your scene
- Dependencies (Unity Essentials modules)
  - UI Toolkit Element Linker: provides `UIElementLink`, `UIElementQuery`, and `UIScriptComponentBase`
  - UI Toolkit Extensions: color/image helpers like `SetBackgroundImage`, `SetBackgroundColor`
  - Editor Attributes – ShowIf: attributes used by the value-changed handler’s inspector (`[ShowIf]`, `[ShowIfNot]`, `[Info]`)

Tip: If a component seems inactive, make sure the GameObject also has either a `UIElementLink` or `UIElementQuery` set up and points at existing elements in the `UIDocument`.

## Usage
1) Link elements
- Add `UIElementLink` to bind a single VisualElement (drag from a UI Builder-referenced UIDocument or query in code)
- Or add `UIElementQuery` to bind multiple elements by name/class/type
- Keep the linker and the component on the same GameObject

2) Add a component
- Choose one or more of:
  - `UIEventHandler`
  - `UIOnValueChangedEventHandler`
  - `UISetLabel`
  - `UISetBackground`
  - `UIDisplayToggle`

3) Configure and wire events
- For event components, expand the relevant UnityEvent and hook your methods
- For setters, edit `LabelText`, `BackgroundColor`, `BackgroundTexture`, or "Display On Start"

Examples
- Button click
```csharp
// On a GameObject with UIElementLink -> (your Button)
// Add UIEventHandler and wire in Inspector, or do it from code:
public class ButtonActions : MonoBehaviour
{
    public void OnClicked() => Debug.Log("Button clicked");
}
```

- Slider value changed
```csharp
// On a GameObject with UIElementQuery -> (your Slider)
// Add UIOnValueChangedEventHandler; in the Inspector, wire SliderEvents.OnSliderChanged(float)
public class SliderActions : MonoBehaviour
{
    public void OnValue(float v) => Debug.Log($"Slider = {v}");
}
```

- Set label text from code
```csharp
var labelSetter = GetComponent<UISetLabel>();
labelSetter.LabelText = "Hello UI Toolkit";
```

- Toggle display at runtime
```csharp
GetComponent<UIDisplayToggle>().Toggle();
```

## How It Works
- Linking and base class
  - `UIScriptComponentBase` looks for `UIElementLink` or `UIElementQuery` on the same GameObject and caches:
    - `Document` (the `UIDocument`), `LinkedElements` (array), and `Type` (`UIElementType`)
  - Helper `IterateLinkedElements(...)` is used by all components to apply changes to every linked element
- Event components
  - Register callbacks on `OnEnable` only for events that have listeners; unregister on `OnDisable`/`OnDestroy`
  - UI Toolkit events are forwarded both as simplified values and as full event structs
- Setters
  - `UISetLabel` updates `Label.text` on `Start` and whenever `LabelText` changes
  - `UISetBackground` uses extension methods to apply color/texture on `OnEnable`
- Display toggle
  - `UIDisplayToggle` flips `style.display` between `Flex` and `None`; provides `SetEnabled(bool)` and `Toggle()`

## Notes and Limitations
- Supported value-changed elements: `TextField`, `Label`, `Slider`, `SliderInt`, `DropdownField`, `Foldout`
  - Other controls aren’t wired by default; extend `UIOnValueChangedEventHandler` if needed
- Requires a valid link
  - If `LinkedElements` is empty or the query doesn’t match, components do nothing safely
- Edit Mode behavior
  - `UIEventHandler` and `UIOnValueChangedEventHandler` are `[ExecuteAlways]`; avoid heavy listeners that should only run in Play Mode
- Background texture/color
  - If `BackgroundTexture` is null, only color is applied
- UnityEvents
  - Invoked on the main thread; ensure subscribers are lightweight to avoid frame hitches

## Files in This Package
- `Runtime/UIEventHandler.cs` – Click/Key/Pointer/Focus event routing
- `Runtime/UIOnValueChangedEventHandler.cs` – Value-changed routing for common elements
- `Runtime/UISetLabel.cs` – Sets `Label.text` for linked labels
- `Runtime/UISetBackground.cs` – Sets background color/texture for linked elements
- `Runtime/UIDisplayToggle.cs` – Show/hide (display) toggling with optional start state
- `Runtime/UnityEssentials.UIToolkitScriptComponents.asmdef` – Runtime assembly definition

## Tags
unity, ui toolkit, visualelement, events, value-changed, label, background, toggle, script components, runtime
