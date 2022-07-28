namespace Features.Factory.Upgrade
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        float JumpHeight { get; set; }
        float Armory { get; set; }
        void Restore();
    }
}
