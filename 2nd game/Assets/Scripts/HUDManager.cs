using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public GameObject gameOverPanel;
    public GameObject gameStartPanel;

    private void Start()
    {
        UpdateGameOverPanel(false);
    }
    public void UpdateCounter(string txt)
    {
        counterText.text = "Enemy destroyed: " + txt;
    }
    public void UpdateGameOverPanel(bool status)
    {
        gameOverPanel.SetActive(status);
        gameStartPanel.SetActive(!status);
    }
}
