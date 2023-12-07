using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class jumpZone : MonoBehaviour
{
    [SerializeField] float min;
    [SerializeField] float max;
    private Rigidbody rigid;
    private Follow follow;
    [SerializeField] private NavMeshAgent navMesh;
    private Vector3 cubePos;
    private bool isCanJump = true;
    [SerializeField] private Transform targetTransform;
    public GameObject flash;
    private Vector3 initPos;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        follow = GetComponent<Follow>();
        navMesh = GetComponent<NavMeshAgent>();
        targetTransform = GameObject.FindWithTag("Player").transform;
        initPos = transform.position;
    }
    private void Update()
    {
        if (transform.position.y < -10) Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {

        float force = Random.Range(min, max);
        //Debug.Log("jumpzone");
        if (staticValues.playerOnCubePos != cubePos && isCanJump && other.tag == "jumpzone" && transform.rotation.x < 90 && transform.rotation.x > -90)
        {
            //Debug.Log("jumpzone");
            isCanJump = false;
            StartCoroutine(jump(force));

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerStat>().TakeDamage(50);
            //Instantiate(flash, transform.position,Quaternion.identity);

            Destroy(gameObject);
            return;
        }

        rigid.isKinematic = true;
        navMesh.enabled = true;
        navMesh.isStopped = false;
        follow.enabled = true;
        //targetTransform = GameObject.FindWithTag("Player").transform;
        navMesh.SetDestination(targetTransform.position);
        isCanJump = true;
        cubePos = collision.transform.position;
        if (collision.gameObject.tag == "cube1" || collision.gameObject.tag == "cube2")
        {
            follow.enabled = true;
            navMesh.enabled = true;
            navMesh.isStopped = false;
            navMesh.speed = 7;


        }
    }
    IEnumerator jump(float force)
    {
        yield return new WaitForSeconds(1f);
        rigid.isKinematic = false;
        follow.enabled = false;

        navMesh.isStopped = true;
        navMesh.enabled = false;

        rigid.velocity = Vector3.zero;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);

        Vector3 tmp = force * Vector3.Normalize(staticValues.playerOnCubePos - transform.position);
        rigid.velocity = new Vector3(tmp.x, 0, -tmp.z);
        Vector3 movement = force * Vector3.Normalize(staticValues.playerOnCubePos - transform.position);
        Debug.Log(movement);

        rigid.velocity = force * (Vector3.forward + Vector3.up) + new Vector3(movement.x, 0, 0);
    }

    private void navMeshOnOff()
    {
        follow.enabled = !follow.enabled;

        navMesh.isStopped = !navMesh.isStopped;
        navMesh.enabled = !navMesh.enabled;

        rigid.velocity = Vector3.zero;
    }
}
