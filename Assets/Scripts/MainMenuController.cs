using System;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();

        if (!String.IsNullOrEmpty(lastWinner))
            uiWinner.text = $"�ltimo vencedor: {lastWinner}";
        else
            uiWinner.text = String.Empty;
    }
}
