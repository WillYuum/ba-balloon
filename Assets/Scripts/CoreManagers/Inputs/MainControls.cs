//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/CoreManagers/Inputs/MainControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""PlayerActions"",
            ""id"": ""8458b2d7-1ddb-4854-b720-d4e871bd4f69"",
            ""actions"": [],
            ""bindings"": []
        },
        {
            ""name"": ""TestControls"",
            ""id"": ""79f34880-2038-4cbc-bf7f-7d9ccab302c9"",
            ""actions"": [
                {
                    ""name"": ""PressStart"",
                    ""type"": ""Button"",
                    ""id"": ""695dbcee-8b96-4524-a22f-118be246c813"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""117d0789-a54e-4cb4-b4ba-8484d7c66b59"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActions
        m_PlayerActions = asset.FindActionMap("PlayerActions", throwIfNotFound: true);
        // TestControls
        m_TestControls = asset.FindActionMap("TestControls", throwIfNotFound: true);
        m_TestControls_PressStart = m_TestControls.FindAction("PressStart", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerActions
    private readonly InputActionMap m_PlayerActions;
    private List<IPlayerActionsActions> m_PlayerActionsActionsCallbackInterfaces = new List<IPlayerActionsActions>();
    public struct PlayerActionsActions
    {
        private @MainControls m_Wrapper;
        public PlayerActionsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsActionsCallbackInterfaces.Add(instance);
        }

        private void UnregisterCallbacks(IPlayerActionsActions instance)
        {
        }

        public void RemoveCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // TestControls
    private readonly InputActionMap m_TestControls;
    private List<ITestControlsActions> m_TestControlsActionsCallbackInterfaces = new List<ITestControlsActions>();
    private readonly InputAction m_TestControls_PressStart;
    public struct TestControlsActions
    {
        private @MainControls m_Wrapper;
        public TestControlsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressStart => m_Wrapper.m_TestControls_PressStart;
        public InputActionMap Get() { return m_Wrapper.m_TestControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestControlsActions set) { return set.Get(); }
        public void AddCallbacks(ITestControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_TestControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TestControlsActionsCallbackInterfaces.Add(instance);
            @PressStart.started += instance.OnPressStart;
            @PressStart.performed += instance.OnPressStart;
            @PressStart.canceled += instance.OnPressStart;
        }

        private void UnregisterCallbacks(ITestControlsActions instance)
        {
            @PressStart.started -= instance.OnPressStart;
            @PressStart.performed -= instance.OnPressStart;
            @PressStart.canceled -= instance.OnPressStart;
        }

        public void RemoveCallbacks(ITestControlsActions instance)
        {
            if (m_Wrapper.m_TestControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITestControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_TestControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TestControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TestControlsActions @TestControls => new TestControlsActions(this);
    public interface IPlayerActionsActions
    {
    }
    public interface ITestControlsActions
    {
        void OnPressStart(InputAction.CallbackContext context);
    }
}
