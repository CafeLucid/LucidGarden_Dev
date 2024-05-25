using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundController : MonoBehaviour
{
    public AudioSource cow;
    public AudioSource roaster;
    public AudioSource click;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            click.Play();
        }
    }

    private void FixedUpdate()
    {
        if (!cow.isPlaying && !roaster.isPlaying)
        {
            int random = Random.Range(0, 1000);
            if (random == 1) cow.Play();
            else if (random == 2) roaster.Play();
        }
    }
}
