// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Managers/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player Actions"",
            ""id"": ""4c1940db-9dc1-4a4a-8c14-923acf6e7ff3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6b3018bc-4206-4879-8a61-ac356e32be51"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Basic Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bfac961e-7345-412b-9c8d-9607bc805786"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charged Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""839b38fb-5dac-48ae-904e-1eebc5576948"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e8e72919-dc7f-4cb3-b129-3ddb91ad8a5e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3981d98b-d2af-4c9a-8474-aca13d6ec1b4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""907d861e-63f7-49e2-82d7-e2cf3cd1e50a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f008e71-1e34-4ef9-9f4c-32004a1b8018"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""639695bd-f68e-4760-8414-b83a0ea3444d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7f837b95-ef7e-4a67-9a4a-358ae7a38ce4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3fcbad5b-7e35-4290-b905-a0c4d195277d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b00789fd-6daa-4abd-8df5-ee6fe8437930"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7e9eb88a-1c1c-48ac-a4ab-c0dae7f6dc83"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f70f3efb-cb32-4c67-944c-d520f89c6c4a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""48cfe195-0c12-4378-adb7-278c941a6b80"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Basic Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""028472f4-72f9-4214-ae4f-6ea132d92e9f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Main Control Scheme"",
                    ""action"": ""Charged Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main Control Scheme"",
            ""bindingGroup"": ""Main Control Scheme"",
            ""devices"": []
        }
    ]
}");
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_Move = m_PlayerActions.FindAction("Move", throwIfNotFound: true);
        m_PlayerActions_BasicAttack = m_PlayerActions.FindAction("Basic Attack", throwIfNotFound: true);
        m_PlayerActions_ChargedAttack = m_PlayerActions.FindAction("Charged Attack", throwIfNotFound: true);
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

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Move;
    private readonly InputAction m_PlayerActions_BasicAttack;
    private readonly InputAction m_PlayerActions_ChargedAttack;
    public struct PlayerActionsActions
    {
        private @Controls m_Wrapper;
        public PlayerActionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerActions_Move;
        public InputAction @BasicAttack => m_Wrapper.m_PlayerActions_BasicAttack;
        public InputAction @ChargedAttack => m_Wrapper.m_PlayerActions_ChargedAttack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMove;
                @BasicAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnBasicAttack;
                @ChargedAttack.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnChargedAttack;
                @ChargedAttack.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnChargedAttack;
                @ChargedAttack.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnChargedAttack;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @BasicAttack.started += instance.OnBasicAttack;
                @BasicAttack.performed += instance.OnBasicAttack;
                @BasicAttack.canceled += instance.OnBasicAttack;
                @ChargedAttack.started += instance.OnChargedAttack;
                @ChargedAttack.performed += instance.OnChargedAttack;
                @ChargedAttack.canceled += instance.OnChargedAttack;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);
    private int m_MainControlSchemeSchemeIndex = -1;
    public InputControlScheme MainControlSchemeScheme
    {
        get
        {
            if (m_MainControlSchemeSchemeIndex == -1) m_MainControlSchemeSchemeIndex = asset.FindControlSchemeIndex("Main Control Scheme");
            return asset.controlSchemes[m_MainControlSchemeSchemeIndex];
        }
    }
    public interface IPlayerActionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnChargedAttack(InputAction.CallbackContext context);
    }
}
