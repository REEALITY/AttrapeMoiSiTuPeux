using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    public GameObject Bomb;
    public GameObject Calice;
    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;
    public bool CanIShoot;
    public ParticleSystem explosion;
    public AudioClip Boom;

    private float TimerMax;
    private float Timer;
    private int myRandomBall;
    private ParticleSystem fire;
    private AudioSource FireSFX;
    private float TProjectile = 6.0f;

    private void Start()
    {
        fire = GetComponent<ParticleSystem>();
        TimerMax = Random.Range(3, 10);
        CanIShoot = true;
        FireSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (CanIShoot)
        {
            Timer -= Time.deltaTime;
            if ((int)Timer <= 0)
            {
                TimerMax = Random.Range(3, 10);
                myRandomBall = Random.Range(0, 4);
                switch (myRandomBall)
                {
                    case 3:
                        //The Bullet instantiation happens here.
                        GameObject Temporary_Bullet_Handler5;
                        fire.Play(true);
                        explosion.Play(true);
                        FireSFX.PlayOneShot(Boom);
                        Temporary_Bullet_Handler5 = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                        Temporary_Bullet_Handler5.transform.Rotate(Vector3.left * 90);

                        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                        Rigidbody Temporary_RigidBody5;
                        Temporary_RigidBody5 = Temporary_Bullet_Handler5.GetComponent<Rigidbody>();

                        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                        Temporary_RigidBody5.AddForce(transform.forward * Bullet_Forward_Force);

                        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                        Destroy(Temporary_Bullet_Handler5, TProjectile);
                        break;
                    case 2:
                        //The Bullet instantiation happens here.
                        GameObject Temporary_Bullet_Handler3;
                        fire.Play(true);
                        explosion.Play(true);
                        FireSFX.PlayOneShot(Boom);
                        Temporary_Bullet_Handler3 = Instantiate(Calice, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                        Temporary_Bullet_Handler3.transform.Rotate(Vector3.left * 90);

                        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                        Rigidbody Temporary_RigidBody3;
                        Temporary_RigidBody3 = Temporary_Bullet_Handler3.GetComponent<Rigidbody>();

                        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                        Temporary_RigidBody3.AddForce(transform.forward * Bullet_Forward_Force);

                        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                        Destroy(Temporary_Bullet_Handler3, TProjectile);
                        break;
                    case 1:
                        //The Bullet instantiation happens here.
                        GameObject Temporary_Bullet_Handler;
                        fire.Play(true);
                        explosion.Play(true);
                        FireSFX.PlayOneShot(Boom);
                        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

                        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                        Rigidbody Temporary_RigidBody;
                        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

                        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                        Destroy(Temporary_Bullet_Handler, TProjectile);
                        break;
                    case 0:
                        //The Bullet instantiation happens here.
                        GameObject Temporary_Bullet_Handler2;
                        fire.Play(true);
                        explosion.Play(true);
                        FireSFX.PlayOneShot(Boom);
                        Temporary_Bullet_Handler2 = Instantiate(Bomb, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
                        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
                        Temporary_Bullet_Handler2.transform.Rotate(Vector3.left * 90);

                        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
                        Rigidbody Temporary_RigidBody2;
                        Temporary_RigidBody2 = Temporary_Bullet_Handler2.GetComponent<Rigidbody>();

                        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
                        Temporary_RigidBody2.AddForce(transform.forward * Bullet_Forward_Force);

                        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                        Destroy(Temporary_Bullet_Handler2, TProjectile);
                        break;
                    default:
                        break;
                }
                Timer = TimerMax;
            }
        }
        if (GetComponentInParent<Timer>().tgame <= 1)
        {
            CanIShoot = false;
        }
    }
}
