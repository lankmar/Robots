using Tool;
using Profile;
using UnityEngine;
using Features.Inventory;
using Features.Factory.Upgrade;

namespace Features.Factory
{
    internal class FactoryMvcContainer : BaseMvcContainer
    {
        private static readonly ResourcePath _viewPath = new("Prefabs/Factory/FactoryView");
        private static readonly ResourcePath _dataSourcePath = new("Configs/Factory/UpgradeItemConfigDataSource");


        public FactoryMvcContainer(ProfilePlayer profilePlayer, Transform placeForUi) =>
            CreateController(profilePlayer, placeForUi);


        private FactoryController CreateController(ProfilePlayer profilePlayer, Transform placeForUi)
        {
            InventoryMvcContainer inventoryMvcContainer = CreateInventoryContainer(profilePlayer.Inventory, placeForUi);
            UpgradeHandlersRepository factoryRepository = CreateRepository();
            FactoryView factoryView = LoadView(placeForUi);

            return new FactoryController
            (
                factoryView,
                profilePlayer,
                inventoryMvcContainer,
                factoryRepository
            );
        }

        private InventoryMvcContainer CreateInventoryContainer(IInventoryModel model, Transform placeForUi)
        {
            var container = new InventoryMvcContainer(model, placeForUi);
            AddContainer(container);

            return container;
        }

        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeConfigs = LoadConfigs();
            var repository = new UpgradeHandlersRepository(upgradeConfigs);
            AddRepository(repository);

            return repository;
        }

        private UpgradeItemConfig[] LoadConfigs() =>
            ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);

        private FactoryView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<FactoryView>();
        }
    }
}
