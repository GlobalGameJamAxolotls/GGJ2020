using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public List<AudioSource> source = new List<AudioSource>();
    public void PlaySound(sounds _s)
    {
        switch(_s)
        {
            case sounds.footstepsA:
                if (!source[(int)_s].isPlaying)
                    source[(int)_s].Play();

                break;

            case sounds.footstepsB:
                if (!source[(int)_s].isPlaying)
                    source[(int)_s].Play();
                break;
            case sounds.JumpA:
            case sounds.JumpB:
            case sounds.SwitchA:
            case sounds.SwitchB:
                source[(int)_s].Play();
                break;
        }

    }

    public void StopSounds(sounds _s)
    {
        source[(int)_s].Stop();
    }
         
 }

[System.Serializable]
public enum sounds
{
    footstepsA = 0,
    footstepsB,
    SwitchA,
    SwitchB,
    JumpA,
    JumpB,
}