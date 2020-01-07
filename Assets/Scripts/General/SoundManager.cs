using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	AudioSource AudioSource;
	
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
	{
		AudioSource.clip = clip;
		AudioSource.Play();
	}
}
