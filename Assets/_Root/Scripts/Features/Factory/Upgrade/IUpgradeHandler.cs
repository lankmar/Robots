namespace Features.Factory.Upgrade
{
    internal interface IUpgradeHandler
    {
        void Upgrade(IUpgradable upgradable);
    }
}
