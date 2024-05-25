using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundController : MonoBehaviour
{
    public AudioSource cow;
    public AudioSource roaster;
    public AudioSource click;
    public AudioSource dreamPiece;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);
            if (hit.collider != null && hit.collider.GetComponent<DreamPiece>() != null)
            {
                dreamPiece.Play();
            }
            else click.Play();
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
