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
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2d99e031-7dff-496e-b916-646b4d97e368"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""KeyBoardAD"",
                    ""id"": ""deeffdf0-242b-4e99-b2c7-da225f403ada"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d69f0d38-b823-4818-9452-22adaf0c8473"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e2f769ed-40c1-4faf-8732-f2435db3e839"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerInputs
            m_PlayerInputs = asset.FindActionMap("PlayerInputs", throwIfNotFound: true);
            m_PlayerInputs_Movement = m_PlayerInputs.FindAction("Movement", throwIfNotFound: true);
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
        private readonly InputAction m_PlayerInputs_Movement;
        public struct PlayerInputsActions
        {
            private @InputActions m_Wrapper;
            public PlayerInputsActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PlayerInputs_Movement;
            public InputActionMap Get() { return m_Wrapper.m_PlayerInputs; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerInputsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerInputsActions instance)
            {
                if (m_Wrapper.m_PlayerInputsActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerInputsActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_PlayerInputsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public PlayerInputsActions @PlayerInputs => new PlayerInputsActions(this);
        public interface IPlayerInputsActions
        {
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}
