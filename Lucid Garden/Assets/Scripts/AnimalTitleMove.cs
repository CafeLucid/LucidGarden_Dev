using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalTitleMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        float randomTime = Random.Range(0f, 2f);
        Invoke("Move", randomTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        anim.SetBool("isIdle", false);
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        if (direction.x < 0 && math.abs(direction.y) < math.abs(direction.x)) anim.SetBool("isLeft", true);
        else if (direction.x > 0 && math.abs(direction.y) < math.abs(direction.x)) anim.SetBool("isRight", true);
        else if (direction.y < 0 && math.abs(direction.x) < math.abs(direction.y)) anim.SetBool("isDown", true);
        else if (direction.y > 0 && math.abs(direction.x) < math.abs(direction.y)) anim.SetBool("isUp", true);
        rb.AddForce(direction * 60f);
        Invoke("Stop", 2f);
    }
    public void Stop()
    {
        anim.SetBool("isLeft", false);
        anim.SetBool("isRight", false);
        anim.SetBool("isDown", false);
        anim.SetBool("isUp", false);
        anim.SetBool("isIdle", true);
        rb.velocity = Vector2.zero;
        Invoke("Move", 0.5f);
    }
}
