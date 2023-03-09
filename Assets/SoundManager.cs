using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioSource source;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        source.volume = DataHolder.Sound;
        if (!source.isPlaying)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.volume = DataHolder.Sound;
            source.Play();
        }
    }
}
