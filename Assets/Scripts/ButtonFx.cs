using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour
{
    [SerializeField] AudioSource myAudio;
    [SerializeField] AudioClip hoverAudio;
    [SerializeField] AudioClip clickAudio;
    
    public void SoundOnHover()
    {
        myAudio.PlayOneShot(hoverAudio);
    }

    public void SoundOnClick()
    {
        myAudio.PlayOneShot(clickAudio);
    }
}
