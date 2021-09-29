using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject Door1, Door2;
    private bool EnteredRoom;
    public int EnemyCount;
    Vector3 destination1, destination2, destination3, destination4;
    void Start()
    {
        EnteredRoom = false;
        destination1 = new Vector3(Door1.transform.position.x, Door1.transform.position.y + 1.6f, Door1.transform.position.z);
        destination2 = new Vector3(Door2.transform.position.x, Door2.transform.position.y + 1.6f, Door2.transform.position.z);
        destination3 = new Vector3(Door1.transform.position.x, Door1.transform.position.y - 1.6f, Door1.transform.position.z);
        destination4 = new Vector3(Door2.transform.position.x, Door2.transform.position.y - 1.6f, Door2.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnteredRoom)
        {
            Door1.transform.position = Vector3.Lerp(Door1.transform.position, destination1, 0.02f);
            Door2.transform.position = Vector3.Lerp(Door2.transform.position, destination2, 0.02f);
        }

        if (EnemyCount == 0)
        {
            Door1.transform.position = Vector3.Lerp(Door1.transform.position, destination3, 0.02f);
            Door2.transform.position = Vector3.Lerp(Door2.transform.position, destination4, 0.02f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" ){
            EnteredRoom = true;
            Debug.Log("entered room");
        }
    }
}
