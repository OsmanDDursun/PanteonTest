// GENERATED AUTOMATICALLY FROM 'Assets/GameFolders/Scripts/Concretes/Inputs/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace PanteonRemoteTest.Inputs
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerInputs"",
            ""id"": ""50a645be-4832-47ee-b584-185efea8e9d0"",
            ""actions"": [
                {
                    ""name"": ""KeyboardMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d99e031-7dff-496e-b916-646b4d97e368"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8793db31-203e-43ab-8493-d6b47425f7de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePressed"",
                    ""type"": ""Button"",
                    ""id"": ""8dae17fa-e4f8-49f7-b227-5c8968b5a380"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2d002537-3cba-4404-be17-94c988b8d303"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""db25f03e-ac56-4c02-87c0-b8b0df94fbc2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""457b2391-877d-42c1-96fb-e9c6495813cf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f56c3d9-6f90-4f88-aa6b-fe8df0488812"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""21865c37-5b96-4194-a6ad-1a1dd020fa0a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeyboardMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7b8dbe52-27fb-483f-a7f0-4228822f2803"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e40c3c4-1b5e-495c-89f7-ede89f3a7527"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerInputs
            m_PlayerInputs = asset.FindActionMap("PlayerInputs", throwIfNotFound: true);
            m_PlayerInputs_KeyboardMovement = m_PlayerInputs.FindAction("KeyboardMovement", throwIfNotFound: true);
            m_PlayerInputs_MousePosition = m_PlayerInputs.FindAction("MousePosition", throwIfNotFound: true);
            m_PlayerInputs_MousePressed = m_PlayerInputs.FindAction("MousePressed", throwIfNotFound: true);
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

        // PlayerInputs
        private readonly InputActionMap m_PlayerInputs;
        private IPlayerInputsActions m_PlayerInputsActionsCallbackInterface;
        private readonly InputAction m_PlayerInputs_KeyboardMovement;
        private readonly InputAction m_PlayerInputs_MousePosition;
        private readonly InputAction m_PlayerInputs_MousePressed;
        public struct PlayerInputsActions
        {
            private @InputActions m_Wrapper;
            public PlayerInputsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @KeyboardMovement => m_Wrapper.m_PlayerInputs_KeyboardMovement;
            public InputAction @MousePosition => m_Wrapper.m_PlayerInputs_MousePosition;
            public InputAction @MousePressed => m_Wrapper.m_PlayerInputs_MousePressed;
            public InputActionMap Get() { return m_Wrapper.m_PlayerInputs; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerInputsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerInputsActions instance)
            {
                if (m_Wrapper.m_PlayerInputsActionsCallbackInterface != null)
                {
                    @KeyboardMovement.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnKeyboardMovement;
                    @KeyboardMovement.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnKeyboardMovement;
                    @KeyboardMovement.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnKeyboardMovement;
                    @MousePosition.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePosition;
                    @MousePosition.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePosition;
                    @MousePressed.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePressed;
                    @MousePressed.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePressed;
                    @MousePressed.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMousePressed;
                }
                m_Wrapper.m_PlayerInputsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @KeyboardMovement.started += instance.OnKeyboardMovement;
                    @KeyboardMovement.performed += instance.OnKeyboardMovement;
                    @KeyboardMovement.canceled += instance.OnKeyboardMovement;
                    @MousePosition.started += instance.OnMousePosition;
                    @MousePosition.performed += instance.OnMousePosition;
                    @MousePosition.canceled += instance.OnMousePosition;
                    @MousePressed.started += instance.OnMousePressed;
                    @MousePressed.performed += instance.OnMousePressed;
                    @MousePressed.canceled += instance.OnMousePressed;
                }
            }
        }
        public PlayerInputsActions @PlayerInputs => new PlayerInputsActions(this);
        public interface IPlayerInputsActions
        {
            void OnKeyboardMovement(InputAction.CallbackContext context);
            void OnMousePosition(InputAction.CallbackContext context);
            void OnMousePressed(InputAction.CallbackContext context);
        }
    }
}
