// GENERATED AUTOMATICALLY FROM 'Assets/PaddleControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PaddleControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PaddleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PaddleControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""265c38f5-dd18-4d34-b198-aec58e1627ff"",
            ""actions"": [
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""1077f913-a9f9-41b1-acb3-b9ee0adbc744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap(duration=0.2)""
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5d158cd-fa89-4525-bdae-3cf8e05ddc2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap(duration=0.2)""
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""50fd2809-3aa3-4a90-988e-1facf6773553"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""c60e0974-d140-4597-a40e-9862193067e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""abb776f3-f329-4f7b-bbf8-b577d13be018"",
                    ""path"": ""*/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c31bda63-804e-4b0a-bbd0-becb942a2663"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1b8c4dd-7b3a-4db6-a93a-0889b59b1afc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""cefc16fc-557a-44b0-939f-2ad792876b07"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07244659-79df-461d-b329-defbe2fbc5f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0ec75cb-f02c-40d2-a33f-1fd6eab2ae0b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""21fe6bfe-4721-4483-9f4a-a0031ade105c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2dd39746-c75c-4a11-838a-e59eacaf4e0b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""05cd2607-4efe-4e78-a0eb-e9e6e129faef"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a467fe3b-eaf2-417d-8ac3-1078e4c5651d"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""07aba12b-d88a-4d7f-8d0a-abdcfad2fbc1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb95f30b-f8fc-4795-a3b0-9fbd52d14b4e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1c0dbd9-8603-4c17-b39d-2b52cdea23ef"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c106d6e6-2780-47ff-b318-396171bd54cc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""578caa03-6827-4797-adfc-a59770c437fe"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=2,y=2)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""985ed4c3-9bcf-47fa-b7a5-1d217b10607f"",
                    ""path"": ""*/{SecondaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""DefaultControlScheme"",
            ""bindingGroup"": ""DefaultControlScheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
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
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_fire = m_gameplay.FindAction("fire", throwIfNotFound: true);
        m_gameplay_jump = m_gameplay.FindAction("jump", throwIfNotFound: true);
        m_gameplay_move = m_gameplay.FindAction("move", throwIfNotFound: true);
        m_gameplay_look = m_gameplay.FindAction("look", throwIfNotFound: true);
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

    // gameplay
    private readonly InputActionMap m_gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_gameplay_fire;
    private readonly InputAction m_gameplay_jump;
    private readonly InputAction m_gameplay_move;
    private readonly InputAction m_gameplay_look;
    public struct GameplayActions
    {
        private @PaddleControls m_Wrapper;
        public GameplayActions(@PaddleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @fire => m_Wrapper.m_gameplay_fire;
        public InputAction @jump => m_Wrapper.m_gameplay_jump;
        public InputAction @move => m_Wrapper.m_gameplay_move;
        public InputAction @look => m_Wrapper.m_gameplay_look;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @look.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @fire.started += instance.OnFire;
                @fire.performed += instance.OnFire;
                @fire.canceled += instance.OnFire;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
            }
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    private int m_DefaultControlSchemeSchemeIndex = -1;
    public InputControlScheme DefaultControlSchemeScheme
    {
        get
        {
            if (m_DefaultControlSchemeSchemeIndex == -1) m_DefaultControlSchemeSchemeIndex = asset.FindControlSchemeIndex("DefaultControlScheme");
            return asset.controlSchemes[m_DefaultControlSchemeSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
