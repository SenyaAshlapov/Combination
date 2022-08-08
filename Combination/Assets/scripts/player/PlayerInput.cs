//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9c121064-8793-48b7-b378-84ee80da3668"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""36469495-7480-49ce-91fa-9f4d5c048ffc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""shot"",
                    ""type"": ""Button"",
                    ""id"": ""34aecd92-140b-4fbe-8e2d-5afe6b7ebfdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""moveAbility"",
                    ""type"": ""Button"",
                    ""id"": ""5d907067-bd98-40ab-887e-bf2a82e472a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""shotAbility"",
                    ""type"": ""Button"",
                    ""id"": ""9977de96-b02e-4556-a66b-ee68ce90c3d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""health"",
                    ""type"": ""Button"",
                    ""id"": ""7dc20241-2d77-4c14-851b-ab404479f097"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""mousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b6c32445-6585-4dac-ad7b-c9d0e8fbba8a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a66af2e6-0b6b-47d5-9c6b-26bd3ee4eda9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5fa0ab5a-c425-49c3-9a90-32d3a378f2ef"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a4e7a28-cc53-4669-9ee2-464f1009c024"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""848309de-f58b-468c-a829-289fcc9ea080"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""464b2451-3939-4300-94da-f42dd742c8bf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""72e94b36-6f6c-42e4-a7ea-c7241d1ada1e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5ce1559e-e0f2-428a-95f7-84a70c6f686a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""128cd303-2fa0-4e5a-84f0-39d721b9531f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03ea1eed-8ebf-45be-9b5f-c5a9e21185c5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9c5d4c71-0955-4c62-8883-28a5fb2dd9de"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e4463f7-a412-4e32-a7d8-96716b84d4d5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""shotAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efaa2509-fbef-4588-b54b-d8b4e9a65586"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""health"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed9408d2-4989-4db1-820a-7d55cdff6f5f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5e64bd2-1b48-4f3d-8c43-0d76ac0f933d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""moveAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0f5e69d-7281-4959-9ce9-323703632568"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""mousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_move = m_Player.FindAction("move", throwIfNotFound: true);
        m_Player_shot = m_Player.FindAction("shot", throwIfNotFound: true);
        m_Player_moveAbility = m_Player.FindAction("moveAbility", throwIfNotFound: true);
        m_Player_shotAbility = m_Player.FindAction("shotAbility", throwIfNotFound: true);
        m_Player_health = m_Player.FindAction("health", throwIfNotFound: true);
        m_Player_mousePosition = m_Player.FindAction("mousePosition", throwIfNotFound: true);
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
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_move;
    private readonly InputAction m_Player_shot;
    private readonly InputAction m_Player_moveAbility;
    private readonly InputAction m_Player_shotAbility;
    private readonly InputAction m_Player_health;
    private readonly InputAction m_Player_mousePosition;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_Player_move;
        public InputAction @shot => m_Wrapper.m_Player_shot;
        public InputAction @moveAbility => m_Wrapper.m_Player_moveAbility;
        public InputAction @shotAbility => m_Wrapper.m_Player_shotAbility;
        public InputAction @health => m_Wrapper.m_Player_health;
        public InputAction @mousePosition => m_Wrapper.m_Player_mousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @shot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @shot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @shot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShot;
                @moveAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveAbility;
                @moveAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveAbility;
                @moveAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveAbility;
                @shotAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotAbility;
                @shotAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotAbility;
                @shotAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShotAbility;
                @health.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealth;
                @health.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealth;
                @health.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHealth;
                @mousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @mousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @mousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @shot.started += instance.OnShot;
                @shot.performed += instance.OnShot;
                @shot.canceled += instance.OnShot;
                @moveAbility.started += instance.OnMoveAbility;
                @moveAbility.performed += instance.OnMoveAbility;
                @moveAbility.canceled += instance.OnMoveAbility;
                @shotAbility.started += instance.OnShotAbility;
                @shotAbility.performed += instance.OnShotAbility;
                @shotAbility.canceled += instance.OnShotAbility;
                @health.started += instance.OnHealth;
                @health.performed += instance.OnHealth;
                @health.canceled += instance.OnHealth;
                @mousePosition.started += instance.OnMousePosition;
                @mousePosition.performed += instance.OnMousePosition;
                @mousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShot(InputAction.CallbackContext context);
        void OnMoveAbility(InputAction.CallbackContext context);
        void OnShotAbility(InputAction.CallbackContext context);
        void OnHealth(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
