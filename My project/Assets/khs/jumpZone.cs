using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jumpZone : MonoBehaviour
{
    [SerializeField] float min;
    [SerializeField] float max;
    private Rigidbody rigid;
    private Follow follow;
    private NavMeshAgent navMesh;
    private Vector3 cubePos;
    private bool isCanJump;
    private Transform targetTransform;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        follow = GetComponent<Follow>();
        navMesh = GetComponent<NavMeshAgent>();
        if (transform == null) targetTransform = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        float force = Random.Range(min, max);
        Debug.Log("jumpzone");
        if (staticValues.playerOnCubePos!=cubePos && isCanJump &&other.tag == "jumpzone")
        {
            Debug.Log("jumpzone");
            StartCoroutine(jump(force));
            isCanJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCanJump = true;
        cubePos = collision.transform.position;
        //Debug.Log("OnCollisionEnter");
        if (collision.gameObject.tag == "cube1" || collision.gameObject.tag == "cube2")
        {
            navMeshOnOff();
            
        }

        else if (collision.gameObject.tag == "Player")
        {
          //  Destroy(gameObject);
        }
    }
    IEnumerator jump(float force)
    {
        yield return new WaitForSeconds(1f);

        navMeshOnOff();
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        Vector3 movement = force * Vector3.Normalize(staticValues.playerOnCubePos - transform.position);
        Debug.Log(movement);
        
        rigid.velocity = force*(Vector3.forward+Vector3.up)+new Vector3(movement.x, 0,0);
    }

    private void navMeshOnOff()
    {
        //if (follow.enabled) 
            follow.enabled = !follow.enabled;
        //if (navMesh.enabled)
        {
            //navMesh.isStopped = !navMesh.isStopped;
            navMesh.enabled = !navMesh.enabled;
        }
        rigid.velocity = Vector3.zero;
    }
}
