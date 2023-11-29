using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;
    float speed = 20;
    float rotSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var move = speed * Time.deltaTime;
        var rot = rotSpeed * Time.deltaTime;

        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * ver * move);
        transform.Rotate(new Vector3(0, hor * rot , 0));
        if (Input.GetKey(KeyCode.Space)) rigidbody.velocity = Vector3.up * 3;

        animator.SetFloat("speed", ver * move);

    }
}
