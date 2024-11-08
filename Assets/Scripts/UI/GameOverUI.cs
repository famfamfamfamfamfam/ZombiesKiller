using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    Button menu, replay;
    [SerializeField]
    TextMeshProUGUI stt;

    private void OnEnable()
    {
        stt.text = GameManager.instance.gameResult;
        menu.onClick.AddListener(ToBackToMenu);
        replay.onClick.AddListener(ToRerunTheGame);
    }

    void ToBackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    void ToRerunTheGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        menu.onClick.RemoveListener(ToBackToMenu);
        replay.onClick.RemoveListener(ToRerunTheGame);
    }
}
