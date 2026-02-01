using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button buttonResume;
    [SerializeField] private Button buttonMainMenu;

    private void OnEnable()
    {
        if (EventBus.Instance != null)
        {
            EventBus.Instance.OnGamePaused += ShowPausePanel;
            EventBus.Instance.OnGameResumed += HidePausePanel;
        }
    }

    private void OnDisable()
    {
        if (EventBus.Instance != null)
        {
            EventBus.Instance.OnGamePaused -= ShowPausePanel;
            EventBus.Instance.OnGameResumed -= HidePausePanel;
        }
    }

    private void Start()
    {
        buttonResume.onClick.AddListener(OnResumeClicked);
        buttonMainMenu.onClick.AddListener(OnMainMenuClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogWarning("Cant toggle pause");
            return;
        }
        if (GameManager.Instance.CurrentGameState == GameState.Playing)
            GameManager.Instance.Pause();
        else if (GameManager.Instance.CurrentGameState == GameState.Paused)
            GameManager.Instance.Resume();
    }

    private void ShowPausePanel()
    {
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    void HidePausePanel()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
    void OnResumeClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.Resume();
    }
    void OnMainMenuClicked()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.MainMenu();
    }
}
