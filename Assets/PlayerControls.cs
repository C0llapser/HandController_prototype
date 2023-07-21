//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""43d3a3a9-acae-47d2-83e5-e07e0dc36615"",
            ""actions"": [
                {
                    ""name"": ""RightHandOnOff"",
                    ""type"": ""Button"",
                    ""id"": ""e34d182c-8584-4f82-adef-d7004c5abf0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftHandOnOff"",
                    ""type"": ""Button"",
                    ""id"": ""ebd1475e-cf33-469c-891b-ae17674f2a97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4384b963-19b9-4779-b14d-50c609bc8ab8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""aed656b1-8ad0-4f32-bb4c-b1587e489e30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b461adbe-cde9-4999-a3e5-5da2b50e07b4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightHandOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0de657ae-45d3-4829-95a2-07cb864eab05"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftHandOnOff"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d20dd8c5-82a3-423d-bf87-fb12eb19875b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_RightHandOnOff = m_Player.FindAction("RightHandOnOff", throwIfNotFound: true);
        m_Player_LeftHandOnOff = m_Player.FindAction("LeftHandOnOff", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_MouseDelta = m_Player.FindAction("MouseDelta", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_RightHandOnOff;
    private readonly InputAction m_Player_LeftHandOnOff;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_MouseDelta;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightHandOnOff => m_Wrapper.m_Player_RightHandOnOff;
        public InputAction @LeftHandOnOff => m_Wrapper.m_Player_LeftHandOnOff;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @MouseDelta => m_Wrapper.m_Player_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @RightHandOnOff.started += instance.OnRightHandOnOff;
            @RightHandOnOff.performed += instance.OnRightHandOnOff;
            @RightHandOnOff.canceled += instance.OnRightHandOnOff;
            @LeftHandOnOff.started += instance.OnLeftHandOnOff;
            @LeftHandOnOff.performed += instance.OnLeftHandOnOff;
            @LeftHandOnOff.canceled += instance.OnLeftHandOnOff;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MouseDelta.started += instance.OnMouseDelta;
            @MouseDelta.performed += instance.OnMouseDelta;
            @MouseDelta.canceled += instance.OnMouseDelta;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @RightHandOnOff.started -= instance.OnRightHandOnOff;
            @RightHandOnOff.performed -= instance.OnRightHandOnOff;
            @RightHandOnOff.canceled -= instance.OnRightHandOnOff;
            @LeftHandOnOff.started -= instance.OnLeftHandOnOff;
            @LeftHandOnOff.performed -= instance.OnLeftHandOnOff;
            @LeftHandOnOff.canceled -= instance.OnLeftHandOnOff;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MouseDelta.started -= instance.OnMouseDelta;
            @MouseDelta.performed -= instance.OnMouseDelta;
            @MouseDelta.canceled -= instance.OnMouseDelta;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnRightHandOnOff(InputAction.CallbackContext context);
        void OnLeftHandOnOff(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
    }
}