using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour {
   
    public PlayerControl Pc;

    public bool isfollowing;

    //camera position offset
    public float xoffset;

    public float yoffset; 

    //use this for initialization
    void Start () {
        Pc = FindObjectOfType<PlayerControl>();
        isfollowing = true;
    
    }
	
	// Update is called once per frame
	void Update () {
        if(isfollowing){
            transform.position = new Vector3(Pc.transform.position.x + xoffset, Pc.transform.position.y + yoffset, transform.position.z);
        }
	}
}
