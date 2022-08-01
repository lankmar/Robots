using Profile;
using UnityEngine;

internal class EntryPoint : MonoBehaviour
{
    [Header("Initial Settings")]
    [SerializeField] private ConfigurationProfilePlayer _configurationProfilePlayer;

    [Header("Scene Objects")]
    [SerializeField] private Transform _placeForUi;

    private MainController _mainController;


    private void Awake()
    {
        var profilePlayer = CreateProfilePlayer(_configurationProfilePlayer);
        _mainController = new MainController(_placeForUi, profilePlayer);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }


    private ProfilePlayer CreateProfilePlayer(ConfigurationProfilePlayer configurationProfilePlayer) =>
        new ProfilePlayer
        (
            
            configurationProfilePlayer.Robot.Speed,
            configurationProfilePlayer.Robot.JumpHeight,
            configurationProfilePlayer.Robot.Type,
            configurationProfilePlayer.Robot.Armory,
            configurationProfilePlayer.State
        );
}
