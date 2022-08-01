using Profile;
using System;
using System.Collections.Generic;
using Features.Factory.Upgrade;
using JetBrains.Annotations;
using UnityEngine;

namespace Features.Factory
{
    internal interface IFactoryController
    {
    }

    internal class FactoryController : BaseController, IFactoryController
    {
        private readonly IFactoryView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly BaseMvcContainer _inventoryMvcContainer;
        private readonly IUpgradeHandlersRepository _upgradeHandlersRepository;


        public FactoryController(
            [NotNull] IFactoryView view,
            [NotNull] ProfilePlayer profilePlayer,
            [NotNull] BaseMvcContainer inventoryMvcContainer,
            [NotNull] IUpgradeHandlersRepository upgradeHandlersRepository)
        {
            Debug.Log("FactoryController");
            _view
                = view ?? throw new ArgumentNullException(nameof(view));

            _profilePlayer
                = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));

            _upgradeHandlersRepository
                = upgradeHandlersRepository ?? throw new ArgumentNullException(nameof(upgradeHandlersRepository));

            _inventoryMvcContainer
                = inventoryMvcContainer ?? throw new ArgumentNullException(nameof(inventoryMvcContainer));

            _view.Init(Apply, Back);
        }

        protected override void OnDispose()
        {
            _view.Deinit();
            base.OnDispose();
        }

        private void Apply()
        {
            _profilePlayer.currentRobot.Restore();

            UpgradeWithEquippedItems(
                _profilePlayer.currentRobot,
                _profilePlayer.Inventory.EquippedItems,
                _upgradeHandlersRepository.Items);

            _profilePlayer.CurrentState.Value = GameState.Start;
            Debug.Log("Apply. " +
                $"Current Speed: {_profilePlayer.currentRobot.Speed}. " +
                $"Current Jump Height: {_profilePlayer.currentRobot.JumpHeight}");
        }

        private void Back()
        {
            _profilePlayer.CurrentState.Value = GameState.Start;
            Debug.Log("Back. " +
                $"Current Speed: {_profilePlayer.currentRobot.Speed}. " +
                $"Current Jump Height: {_profilePlayer.currentRobot.JumpHeight}");
        }


        private void UpgradeWithEquippedItems(
            IUpgradable upgradable,
            IReadOnlyList<string> equippedItems,
            IReadOnlyDictionary<string, IUpgradeHandler> upgradeHandlers)
        {
            foreach (string itemId in equippedItems)
                if (upgradeHandlers.TryGetValue(itemId, out IUpgradeHandler handler))
                    handler.Upgrade(upgradable);
        }
    }
}
