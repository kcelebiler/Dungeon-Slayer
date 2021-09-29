using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public AudioClip whip_sound;
    public AudioClip slice_sound;
    public AudioSource audio;
    private bool colliding_with_enemy=false, isDestroyed=false;
    private GameObject enemy;
    private EnemyController enemyController;
    public GameManager gameManager;
    float audioStepLengthWalk = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsDead)
        {
            if(colliding_with_enemy && Input.GetKeyDown(KeyCode.Mouse0)){
                audio.clip=slice_sound;
                audio.Play();
                //Destroy(enemy.gameObject);
                enemyController.TakeDamage(30);
                isDestroyed=true;
            }
            else if(!colliding_with_enemy && Input.GetKeyDown(KeyCode.Mouse0)){
                audio.clip=whip_sound;
                audio.Play();
                isDestroyed=false;
            }
            if(isDestroyed) colliding_with_enemy=false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag=="Enemy"){
            enemyController = other.gameObject.GetComponent<EnemyController>();
            colliding_with_enemy=true;
            enemy=other.gameObject;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy"){
            enemyController = other.gameObject.GetComponent<EnemyController>();
            colliding_with_enemy=true;
            enemy=other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag=="Enemy"){
            colliding_with_enemy=false;
            //enemy=other;
        }
    }
}
