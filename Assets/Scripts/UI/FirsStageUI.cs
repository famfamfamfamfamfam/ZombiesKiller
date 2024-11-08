using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FirsStageUI : MonoBehaviour, IOrderOfRunningStart, IToTheShootingSight, ICountdown
{
    [SerializeField]
    TextMeshProUGUI score, cd;
    [SerializeField]
    Button aim;

    public void Init()
    {
        GameManager.instance.HasChanged += ScoreText;
        aim.onClick.AddListener(HasClick);
        score.text = $"{GameManager.instance.score}";
    }

    void HasClick()
    {
        GameManager.instance.hasClick = true;
    }

    public bool Input()
    {
        return GameManager.instance.hasClick;
    }

    void ScoreText(string s)
    {
        if (s == "score")
            score.text = $"{GameManager.instance.score}";
    }

    public void CountdownText(int countNum)
    {
        cd.text = $"{countNum}";
    }

    void OnDisable()
    {
        GameManager.instance.HasChanged -= ScoreText;
    }

    void OnDestroy()
    {
        aim.onClick.RemoveListener(HasClick);
    }
}
