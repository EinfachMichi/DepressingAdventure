// GENERATED AUTOMATICALLY FROM 'Assets/Project/InputActions/GameInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""61ef5199-174b-463c-919c-75523c1a524f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""7172deec-5cad-45fb-98bb-366df21b9ddb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""4ef3e0ae-6fb1-4209-a130-606dbcc752b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9c860cc1-47e2-42cc-ace4-e2996f7647be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choice1"",
                    ""type"": ""Button"",
                    ""id"": ""f71ea347-c90c-4554-a597-954240b5f4b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choice2"",
                    ""type"": ""Button"",
                    ""id"": ""0ad55235-4605-4a52-a83a-3b15cfbb322e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c4881429-5b71-4645-88ef-da96fdc294b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a33f4066-e31c-4c6c-b8f1-b1b161d7af75"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7a56e0d8-b41f-4b53-93a7-d13afb4d5a3e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41c6470a-fa82-4116-a409-7c11e03ce4d1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""96de9698-ef6f-4c21-ae81-15d2edbfa943"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""be06d551-6ca7-41fb-b2cc-0851213d2235"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e5f85c8b-8ac3-4dce-9bab-a05b5fcc909b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""96222837-ab9d-421d-b121-8c67ad3f3046"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""20b3a221-131d-4cd4-8e39-0821f654fe02"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02b6e767-7c21-46e5-825b-6c71b6f2fb1b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Controller Left Analog"",
                    ""id"": ""1f121534-d936-4b7b-acb6-5016c566f198"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bb0bcb7a-25ee-4ead-b89f-f841176f01e3"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3b13584d-b768-40a0-b7d6-19c8a2fad31d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a24b2dab-da6a-45fa-b968-651ffce4fc0f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9e667726-5f5e-488f-9358-c1223dc714ed"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b4589790-e071-4f3c-b2aa-98ad9d9644ad"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4307f12-df25-4393-974d-7a83226787ee"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d572c876-2e2e-4fd6-8ca5-6befe88d29da"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2994c27e-c7f7-4f40-a96a-5e29cee75abf"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choice1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""226115d4-7498-42b0-9ab0-2b97a7d34757"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Choice2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""20231b5e-ef84-4a53-be2f-ba6dce631159"",
            ""actions"": [
                {
                    ""name"": ""Slot1"",
                    ""type"": ""Button"",
                    ""id"": ""8562b1f8-88cb-4fe2-940a-7b4264cd0b31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot2"",
                    ""type"": ""Button"",
                    ""id"": ""9208fc62-f65a-4ab4-90b8-e8309010b00a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot3"",
                    ""type"": ""Button"",
                    ""id"": ""45299dc8-ef11-4ae2-87d3-47a708f12861"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot4"",
                    ""type"": ""Button"",
                    ""id"": ""057d7baf-f92a-4bcc-a374-58c975a3dc0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slot5"",
                    ""type"": ""Button"",
                    ""id"": ""4ee916ea-fca5-417c-9656-566c4e6afdd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0042276-b08d-400c-aa0a-07d52090f686"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8bba80-c9af-4521-be97-698d51aa36b4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec21f079-d8df-48ed-a04c-8863f2e56ad7"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6cae9a0-346c-4212-abfd-87d0357fb494"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00f067f4-4736-4b85-bdd5-968abffdefb5"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QuickTime"",
            ""id"": ""2d83343a-5faa-4043-b269-af3e8411c8c1"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""fb54080b-6769-4fee-94c7-523b57ebf3a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""07d5e48e-0017-43d5-add1-379656d3b6c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""92914e6a-8e40-45c7-9559-2b50696e44c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""ceffd327-0b78-4e6e-9699-b907bdf28e5e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""5ab2b51e-e097-46bd-9e2b-485e72dd107b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7194b00b-bb54-4032-b22b-4cdca05f89d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e596db3d-54a3-4039-80ab-9fd21e0811c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a32797c-a97e-40f7-beef-6624bff47c2f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b22b3c88-c37b-4930-bdc2-10f2c1aacb76"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0e661bd-d097-4177-b203-d2305801b153"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Map"",
            ""id"": ""5e32b385-8c7c-4926-a24c-c6f25756fc3d"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""085f91d6-033e-4a11-a692-2e912a1a15de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b58b3837-521c-4027-a4a5-9f71299e9d37"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle"",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Choice1 = m_Player.FindAction("Choice1", throwIfNotFound: true);
        m_Player_Choice2 = m_Player.FindAction("Choice2", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_Slot1 = m_Inventory.FindAction("Slot1", throwIfNotFound: true);
        m_Inventory_Slot2 = m_Inventory.FindAction("Slot2", throwIfNotFound: true);
        m_Inventory_Slot3 = m_Inventory.FindAction("Slot3", throwIfNotFound: true);
        m_Inventory_Slot4 = m_Inventory.FindAction("Slot4", throwIfNotFound: true);
        m_Inventory_Slot5 = m_Inventory.FindAction("Slot5", throwIfNotFound: true);
        // QuickTime
        m_QuickTime = asset.FindActionMap("QuickTime", throwIfNotFound: true);
        m_QuickTime_A = m_QuickTime.FindAction("A", throwIfNotFound: true);
        m_QuickTime_S = m_QuickTime.FindAction("S", throwIfNotFound: true);
        m_QuickTime_D = m_QuickTime.FindAction("D", throwIfNotFound: true);
        m_QuickTime_W = m_QuickTime.FindAction("W", throwIfNotFound: true);
        m_QuickTime_Space = m_QuickTime.FindAction("Space", throwIfNotFound: true);
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_Toggle = m_Map.FindAction("Toggle", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Choice1;
    private readonly InputAction m_Player_Choice2;
    public struct PlayerActions
    {
        private @GameInput m_Wrapper;
        public PlayerActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Choice1 => m_Wrapper.m_Player_Choice1;
        public InputAction @Choice2 => m_Wrapper.m_Player_Choice2;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Choice1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice1;
                @Choice1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice1;
                @Choice1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice1;
                @Choice2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice2;
                @Choice2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice2;
                @Choice2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChoice2;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Choice1.started += instance.OnChoice1;
                @Choice1.performed += instance.OnChoice1;
                @Choice1.canceled += instance.OnChoice1;
                @Choice2.started += instance.OnChoice2;
                @Choice2.performed += instance.OnChoice2;
                @Choice2.canceled += instance.OnChoice2;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private IInventoryActions m_InventoryActionsCallbackInterface;
    private readonly InputAction m_Inventory_Slot1;
    private readonly InputAction m_Inventory_Slot2;
    private readonly InputAction m_Inventory_Slot3;
    private readonly InputAction m_Inventory_Slot4;
    private readonly InputAction m_Inventory_Slot5;
    public struct InventoryActions
    {
        private @GameInput m_Wrapper;
        public InventoryActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Slot1 => m_Wrapper.m_Inventory_Slot1;
        public InputAction @Slot2 => m_Wrapper.m_Inventory_Slot2;
        public InputAction @Slot3 => m_Wrapper.m_Inventory_Slot3;
        public InputAction @Slot4 => m_Wrapper.m_Inventory_Slot4;
        public InputAction @Slot5 => m_Wrapper.m_Inventory_Slot5;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
            {
                @Slot1.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot1;
                @Slot1.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot1;
                @Slot1.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot1;
                @Slot2.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot2;
                @Slot2.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot2;
                @Slot2.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot2;
                @Slot3.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot3;
                @Slot3.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot3;
                @Slot3.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot3;
                @Slot4.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot4;
                @Slot4.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot4;
                @Slot4.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot4;
                @Slot5.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot5;
                @Slot5.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot5;
                @Slot5.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnSlot5;
            }
            m_Wrapper.m_InventoryActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Slot1.started += instance.OnSlot1;
                @Slot1.performed += instance.OnSlot1;
                @Slot1.canceled += instance.OnSlot1;
                @Slot2.started += instance.OnSlot2;
                @Slot2.performed += instance.OnSlot2;
                @Slot2.canceled += instance.OnSlot2;
                @Slot3.started += instance.OnSlot3;
                @Slot3.performed += instance.OnSlot3;
                @Slot3.canceled += instance.OnSlot3;
                @Slot4.started += instance.OnSlot4;
                @Slot4.performed += instance.OnSlot4;
                @Slot4.canceled += instance.OnSlot4;
                @Slot5.started += instance.OnSlot5;
                @Slot5.performed += instance.OnSlot5;
                @Slot5.canceled += instance.OnSlot5;
            }
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);

    // QuickTime
    private readonly InputActionMap m_QuickTime;
    private IQuickTimeActions m_QuickTimeActionsCallbackInterface;
    private readonly InputAction m_QuickTime_A;
    private readonly InputAction m_QuickTime_S;
    private readonly InputAction m_QuickTime_D;
    private readonly InputAction m_QuickTime_W;
    private readonly InputAction m_QuickTime_Space;
    public struct QuickTimeActions
    {
        private @GameInput m_Wrapper;
        public QuickTimeActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_QuickTime_A;
        public InputAction @S => m_Wrapper.m_QuickTime_S;
        public InputAction @D => m_Wrapper.m_QuickTime_D;
        public InputAction @W => m_Wrapper.m_QuickTime_W;
        public InputAction @Space => m_Wrapper.m_QuickTime_Space;
        public InputActionMap Get() { return m_Wrapper.m_QuickTime; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QuickTimeActions set) { return set.Get(); }
        public void SetCallbacks(IQuickTimeActions instance)
        {
            if (m_Wrapper.m_QuickTimeActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnA;
                @S.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnS;
                @D.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnD;
                @W.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnW;
                @Space.started -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_QuickTimeActionsCallbackInterface.OnSpace;
            }
            m_Wrapper.m_QuickTimeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
            }
        }
    }
    public QuickTimeActions @QuickTime => new QuickTimeActions(this);

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_Toggle;
    public struct MapActions
    {
        private @GameInput m_Wrapper;
        public MapActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Toggle => m_Wrapper.m_Map_Toggle;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @Toggle.started -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
                @Toggle.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
                @Toggle.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnToggle;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Toggle.started += instance.OnToggle;
                @Toggle.performed += instance.OnToggle;
                @Toggle.canceled += instance.OnToggle;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnChoice1(InputAction.CallbackContext context);
        void OnChoice2(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnSlot1(InputAction.CallbackContext context);
        void OnSlot2(InputAction.CallbackContext context);
        void OnSlot3(InputAction.CallbackContext context);
        void OnSlot4(InputAction.CallbackContext context);
        void OnSlot5(InputAction.CallbackContext context);
    }
    public interface IQuickTimeActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
        void OnW(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
    }
    public interface IMapActions
    {
        void OnToggle(InputAction.CallbackContext context);
    }
}
