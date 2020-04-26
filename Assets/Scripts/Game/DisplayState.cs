using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayState : MonoBehaviour
{

    public TextMeshProUGUI text;

    public void Display(string state)
    {
        text.text = state;
    }
}
