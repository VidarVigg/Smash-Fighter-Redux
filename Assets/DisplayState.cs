using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayState : MonoBehaviour
{
    public static DisplayState INSTANCE;
    public TextMeshProUGUI text;

    private void Awake()
    {
        INSTANCE = this;
    }
    public void Display(string state)
    {
        text.text = state;
    }
}
