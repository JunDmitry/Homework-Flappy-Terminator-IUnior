using Assets.Scripts.UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private WaveGenerator _waveGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private PlayerInfoScreen _playerInfo;

    private void OnEnable()
    {
        _player.GameEnded += OnGameEnded;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _player.GameEnded -= OnGameEnded;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _waveGenerator.gameObject.SetActive(false);
        _startScreen.Open();
    }

    private void OnGameEnded()
    {
        Time.timeScale = 0;
        _endScreen.Open();
        _playerInfo.Close();
        _waveGenerator.gameObject.SetActive(false);
        _waveGenerator.Reset();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        BeginGame();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        BeginGame();
    }

    private void BeginGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        _waveGenerator.gameObject.SetActive(true);
        _waveGenerator.Restart();
        _playerInfo.Open();
    }
}