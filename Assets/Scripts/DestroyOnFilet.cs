using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFilet : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Filet")
            {
                Destroy(gameObject);
            }
    }
}
