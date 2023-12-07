using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 20;
    [SerializeField] float jumpForce = 3;

    Animator animator;
    Rigidbody Rigid;
    bool isGround = true;
    float coyoteTime = 0.5f;
    float rotSpeed = 100;
    MapManager mapManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mapManager = FindAnyObjectByType<MapManager>();
        Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGround) coyoteTime -= Time.deltaTime;

        var move = speed * Time.deltaTime;
        var rot = rotSpeed * Time.deltaTime;

        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");
        //var horTmp = Input.getbu

        transform.Translate(Vector3.forward * ver * move);
        transform.Rotate(new Vector3(0, hor * rot, 0));

    }
    private void FixedUpdate()
    {


        if (coyoteTime>0 && Input.GetKey(KeyCode.Space) ) Rigid.velocity = Vector3.up * jumpForce;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            coyoteTime = 0.5f;
        }
        if(collision.gameObject.tag == "cube1" || collision.gameObject.tag == "cube2") 
        {
            staticValues.playerOnCubePos = collision.gameObject.transform.position;
            mapManager.setPlayerPosition(collision.gameObject.transform.position);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGround = true;
        coyoteTime = 0.5f;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
        staticValues.playerOnCubePos = Vector3.down;
    }
}
