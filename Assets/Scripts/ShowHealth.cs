using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHealth : MonoBehaviour
{
    TextMeshProUGUI myText;
    Player thePlayer;
    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = thePlayer.health.ToString();
    }
}
