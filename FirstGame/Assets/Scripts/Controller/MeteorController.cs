using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    float playTime = 0.0f;
    Vector3 movdir = new Vector3(0.3f, -0.4f, 0);
    string thisName;

    private void Awake()
    {
        thisName = gameObject.name; // 이름 활용
    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }

    void FixedUpdate()
    {
        gameObject.transform.position += movdir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
            return;
        Animator anim = gameObject.GetComponent<Animator>();
        anim.Play(thisName+"_End");
        movdir = Vector3.zero;
        GameObject parent = transform.parent.gameObject;
        if (parent)
            Destroy(parent, 1.2f);
        Destroy(gameObject, 0.4f);
    }
}
