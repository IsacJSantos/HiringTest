//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/Input.inputactions
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

public partial class @Input : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""1002fcb9-b599-4c61-846d-fa94e7c88830"",
            ""actions"": [
                {
                    ""name"": ""Interact"",
                    ""type"": ""Value"",
                    ""id"": ""30c18b51-07bd-4431-8338-038afec9a6f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""XMove"",
                    ""type"": ""Value"",
                    ""id"": ""ad84e389-326c-46bb-94ac-3cfd703699d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""YMove"",
                    ""type"": ""Value"",
                    ""id"": ""8be0f76d-53b5-4b4b-b613-f4e33a3e2f8e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""e81f45aa-a00d-4bef-a2f0-37208e055b40"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ca3d616c-2ec9-4272-b187-d63e66eb1f9a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2677f3d1-5c25-4dac-84b1-298f62917d19"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""adkeys"",
                    ""id"": ""c47ea8f5-1010-4170-ad88-a5d722fb85be"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""XMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""eda2e78f-fb4a-453c-a368-a8fac2c0f6f4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""XMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""f88e2818-02c7-48df-a58a-2d10b2e04b29"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""XMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""wskeys"",
                    ""id"": ""ebd0aa70-87b4-4d14-bddc-866c60852cac"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""f1886733-83f3-406c-b86b-cba1ee72dce1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""YMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""ea325a63-47b5-460c-b02d-25201eac4a96"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""YMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ba596316-b132-420d-bd90-b7d715a1c8ea"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dca81c07-d1f3-430a-b040-b2408970c0d4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""85065f9d-5480-4801-9aa2-89b50bf7f698"",
            ""actions"": [
                {
                    ""name"": ""PauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""162cb0f2-752e-463e-914a-83cd2521f795"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40ce19fb-9fdb-46a7-b498-2b40de7069cc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and Mouse"",
                    ""action"": ""PauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keybord and Mouse"",
            ""bindingGroup"": ""Keybord and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Interact = m_PlayerControl.FindAction("Interact", throwIfNotFound: true);
        m_PlayerControl_XMove = m_PlayerControl.FindAction("XMove", throwIfNotFound: true);
        m_PlayerControl_YMove = m_PlayerControl.FindAction("YMove", throwIfNotFound: true);
        m_PlayerControl_Run = m_PlayerControl.FindAction("Run", throwIfNotFound: true);
        m_PlayerControl_Look = m_PlayerControl.FindAction("Look", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_PauseMenu = m_UI.FindAction("PauseMenu", throwIfNotFound: true);
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private IPlayerControlActions m_PlayerControlActionsCallbackInterface;
    private readonly InputAction m_PlayerControl_Interact;
    private readonly InputAction m_PlayerControl_XMove;
    private readonly InputAction m_PlayerControl_YMove;
    private readonly InputAction m_PlayerControl_Run;
    private readonly InputAction m_PlayerControl_Look;
    public struct PlayerControlActions
    {
        private @Input m_Wrapper;
        public PlayerControlActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Interact => m_Wrapper.m_PlayerControl_Interact;
        public InputAction @XMove => m_Wrapper.m_PlayerControl_XMove;
        public InputAction @YMove => m_Wrapper.m_PlayerControl_YMove;
        public InputAction @Run => m_Wrapper.m_PlayerControl_Run;
        public InputAction @Look => m_Wrapper.m_PlayerControl_Look;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterface != null)
            {
                @Interact.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnInteract;
                @XMove.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnXMove;
                @XMove.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnXMove;
                @XMove.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnXMove;
                @YMove.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnYMove;
                @YMove.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnYMove;
                @YMove.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnYMove;
                @Run.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnRun;
                @Look.started -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerControlActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_PlayerControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @XMove.started += instance.OnXMove;
                @XMove.performed += instance.OnXMove;
                @XMove.canceled += instance.OnXMove;
                @YMove.started += instance.OnYMove;
                @YMove.performed += instance.OnYMove;
                @YMove.canceled += instance.OnYMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_PauseMenu;
    public struct UIActions
    {
        private @Input m_Wrapper;
        public UIActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseMenu => m_Wrapper.m_UI_PauseMenu;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @PauseMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
                @PauseMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPauseMenu;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseMenu.started += instance.OnPauseMenu;
                @PauseMenu.performed += instance.OnPauseMenu;
                @PauseMenu.canceled += instance.OnPauseMenu;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeybordandMouseSchemeIndex = -1;
    public InputControlScheme KeybordandMouseScheme
    {
        get
        {
            if (m_KeybordandMouseSchemeIndex == -1) m_KeybordandMouseSchemeIndex = asset.FindControlSchemeIndex("Keybord and Mouse");
            return asset.controlSchemes[m_KeybordandMouseSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnInteract(InputAction.CallbackContext context);
        void OnXMove(InputAction.CallbackContext context);
        void OnYMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPauseMenu(InputAction.CallbackContext context);
    }
}
