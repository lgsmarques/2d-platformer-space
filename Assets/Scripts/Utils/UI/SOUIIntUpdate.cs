using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;
    void Start()
    {
        uiTextValue.text = "x " + soInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = "x " + soInt.value.ToString();
    }
}
