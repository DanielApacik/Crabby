using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badToppings : MonoBehaviour
{
    public static badToppings instance;

    private AudioSource badSound;
    public AudioClip clunk1;
    public AudioClip clunk2;

    int randomSOUND;

    private void Start()
    {
        badSound = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void PlayBadSound()
    {
        randomSOUND = Random.Range(0, 4);

        if (randomSOUND == 0 || randomSOUND == 1)
        {
            badSound.GetComponent<AudioSource>().clip = clunk1;
            badSound.Play();
        }

        if (randomSOUND == 2 || randomSOUND == 3)
        {
            badSound.GetComponent<AudioSource>().clip = clunk2;
            badSound.Play();
        }
    }
}
