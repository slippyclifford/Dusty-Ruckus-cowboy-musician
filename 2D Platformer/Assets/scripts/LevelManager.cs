using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject CurrentCheckPoint;
    public Rigidbody2D Pc;
    public GameObject PC2;

    //particles 
    public GameObject Death_PS;
    public GameObject Respawn_PS;

    //Respawn Delay
    public float RespawnDelay;

    //Point Penalty on Death
    public int pointPenaltyOnDeath;

    // Store Gravity Value
    private float GravityStore;

    // Use this for initialization

    void Start()
    {
     //Pc = FindObjectOfType<Rigidbody2D>

    }
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo()
    {
        //Generate Death Particle
        Instantiate(Death_PS, Pc.transform.position, Pc.transform.rotation);
        //Hide Player
        //Pc.enabled = false;
        PC2.SetActive(false);
        Pc.GetComponent<Renderer>().enabled = false;
        //Gravity Reset 
        GravityStore = Pc.GetComponent<Rigidbody2D>().gravityScale;
        Pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Point Penalty 
        Score_Manager.AddPoints(-pointPenaltyOnDeath);
        //Debug Message
        Debug.Log("Pc Respawn");
             //Respawn Delay
             yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        Pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
        //Match Pcs transform position
        Pc.transform.position = CurrentCheckPoint.transform.position;
        //Show Pc
        //Pc.enabled = true;
        PC2.SetActive(true);
        Pc.GetComponent<Renderer>().enabled = true;
        //spawn Pc 
        Instantiate(Respawn_PS, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
    }
}