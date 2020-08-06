using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    bool isWalking = false;
    bool isRunning = false;
    bool isShooting = false;
    bool isIdle = false;
    
    public Transform player;
    public Rigidbody bullet;
    public Transform bulletOrigin;
    
    private NavMeshAgent enemy;
    
    public float coverRadius = 20.0f;
    public float runRadius = 12.0f;
    public float shootRadius = 5;
    public float maxDivergence = 0.5f;
    public float thrust = 100.0f;
 
    private Animator anim;
    
    Vector3 lookDirection;
    float relativeDistance;
    
    //public ShootFromGun other;
    public EnemyVision detection;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        relativeDistance = Vector3.Distance(enemy.transform.position, player.position);
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "Rifle Idle")
        {
            isIdle = true;
            isRunning = false;
            isShooting = false;
            isWalking = false;
        }
        else if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "Rifle Walk")
        {
            isIdle = false;
            isRunning = false;
            isShooting = false;
            isWalking = true;
        }   
        else if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "Crouched Run")
        {
            isIdle = false;
            isRunning = true;
            isShooting = false;
            isWalking = false;
        }
        else if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString() == "Firing Rifle")
        {
            isIdle = false;
            isRunning = false;
            isShooting = true;
            isWalking = false;
        }


        //Debug.Log(relativeDistance);
        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString());
        //Debug.Log(detection.isDetected);
        lookDirection = new Vector3(player.transform.position.x,0,player.transform.position.z);

        if (relativeDistance >= runRadius && relativeDistance < coverRadius && detection.isDetected == true) 
        {
            enemy.SetDestination(player.position);
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
            anim.SetBool("Shoot", false);
        }
        else if (relativeDistance < runRadius && relativeDistance >= shootRadius)
        {

            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
            anim.SetBool("Shoot", false);
            enemy.SetDestination(player.position);

        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            if (player != null)
            {
                enemy.transform.LookAt(lookDirection);
            }
        }
        
        if(isIdle == true && relativeDistance <= shootRadius && detection.isDetected == true)
        {
            anim.SetBool("Shoot", true);
            //Debug.Log(isShooting);
            Shoot();
        }
    } 

    void Shoot()
    {
        Vector3 divergence = Vector3.zero;
        divergence.x = (1 - 2 * Random.value) * maxDivergence;
        divergence.y = (1 - 2 * Random.value) * maxDivergence;

        Vector3 relativeDir = bulletOrigin.position + (player.position - bulletOrigin.position).normalized;

        Rigidbody newBullet = Instantiate(bullet, bulletOrigin.position, Quaternion.LookRotation(player.position - transform.position)) as Rigidbody;
        newBullet.transform.Rotate(divergence);
        newBullet.AddForce(-bulletOrigin.forward * thrust, ForceMode.Impulse);
        Destroy(newBullet.gameObject, 3);
    }
}