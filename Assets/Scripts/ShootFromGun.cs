using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFromGun : MonoBehaviour
{
    public Transform player;
    //public GameObject enemy;
    public Rigidbody bullet;
    public Transform enemy;
    //public Transform bulletOrigin;
    public static float maxDivergence = 1.0f;
    public float thrust = 1000.0f;
    public float waitTime = 1.0f;
    public float nextShootTime = 0.0f;
    private bool fired = false;
    //private Animator anim;

    void Start()
    {
        //anim = enemy.GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void Shoot()
    {
        Vector3 divergence = Vector3.zero;
        divergence.x = (1 - 2 * Random.value) * maxDivergence;
        divergence.y = (1 - 2 * Random.value) * maxDivergence;

        Vector3 relativeDir = this.transform.position + this.transform.forward.normalized;

        Rigidbody newBullet = Instantiate(bullet, enemy.position, Quaternion.LookRotation(player.position - transform.position)) as Rigidbody;
        newBullet.transform.Rotate(divergence);
        newBullet.AddForce(this.transform.forward * thrust, ForceMode.Impulse);
        Destroy(newBullet.gameObject, 5);
        /*anim.SetBool("isShooting", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);*/
    }


}
