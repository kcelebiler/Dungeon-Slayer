using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject hand_with_sword;
    public int health=100;
    public bool IsDead;
    public Text health_text;
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                hand_with_sword.GetComponent<Animator>().SetBool("IsAttacking",true);
            }
            else{
                hand_with_sword.GetComponent<Animator>().SetBool("IsAttacking",false);
            }
            health_text.text = health.ToString();
        }
        else
        {
            health_text.text = "0";
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            IsDead = true;
            hand_with_sword.GetComponent<Animator>().SetBool("IsDead",true);
        }
    }
}
