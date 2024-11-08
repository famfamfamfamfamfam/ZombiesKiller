using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField]
    Button play, quit;
    private void Start()
    {
        play.onClick.AddListener(ToPlay);
        quit.onClick.AddListener(ToQuit);
    }

    void ToPlay()
    {
        SceneManager.LoadScene(1);
    }

    void ToQuit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(ToPlay);
        quit.onClick.RemoveListener(ToQuit);
    }
}
