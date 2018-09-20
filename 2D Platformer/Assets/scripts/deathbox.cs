using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbox : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D other){

        if (other.name == "Pc")
        {
            Debug.Log("Pc Enters Death Zone");
            Destroy(other);
        }

    }
}
