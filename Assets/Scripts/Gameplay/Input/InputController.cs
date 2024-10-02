using Abstracts;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Input
{
    public sealed class InputController : BaseController
    {
        private readonly ResourcePath _viewPrefabPath = new(Constants.Prefabs.Input.KeyboardInput);
        private readonly BaseInputView _view;

        public InputController(
            SubscribedProperty<Vector3> mousePositionInput,
            SubscribedProperty<float> verticalInput,
            SubscribedProperty<bool> primaryFireInput,
            SubscribedProperty<bool> changeWeaponInput,
            SubscribedProperty<bool> nextLevelInput,
            SubscribedProperty<bool> mapInput)
        {
            _view = LoadView<BaseInputView>(_viewPrefabPath);
            _view.Init(mousePositionInput, verticalInput, primaryFireInput, changeWeaponInput, nextLevelInput, mapInput);
        }

    }
}