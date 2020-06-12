using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioSource startScreenMusic;
    [SerializeField] Sprite[] audioIcons;

    void Start()
    {

    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ChangeAudioLevels();
        }
    }
    private void ChangeSprite(int arrayNumber)
    {
        GetComponent<Image>().sprite = audioIcons[arrayNumber];
    }

    private void ChangeVolumeLevels(float volumeLevel)
    {
        startScreenMusic.volume = volumeLevel; 
    }

    public void ChangeAudioLevels()
    {
        if (GetComponent<Image>().sprite == audioIcons[0])
        {
            ChangeSprite(1);
            ChangeVolumeLevels(0.6f);
        }
        else if (GetComponent<Image>().sprite == audioIcons[1])
        {
            ChangeSprite(2);
            ChangeVolumeLevels(0.2f);
        }
        else if (GetComponent<Image>().sprite == audioIcons[2])
        {
            ChangeSprite(3);
            ChangeVolumeLevels(0f);
        }
        else if (GetComponent<Image>().sprite == audioIcons[3])
        {
            ChangeSprite(0);
            ChangeVolumeLevels(1f);
        }
    }
}
