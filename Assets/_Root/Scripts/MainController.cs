using Ui;
using Game;
using Profile;
using UnityEngine;
using Features.Factory;

internal class MainController : BaseController
{
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    private MainMenuController _mainMenuController;
    private SettingsMenuController _settingsMenuController;
    private GameController _gameController;
    private FactoryMvcContainer _factoryContainer;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;

        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }


    private void OnChangeGameState(GameState state)
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _factoryContainer?.Dispose();
        switch (state)
        {

            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                break;
            case GameState.Factory:
                _factoryContainer = new FactoryMvcContainer(_profilePlayer, _placeForUi);
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController (_placeForUi, _profilePlayer);
                break;
        }
    }
}
