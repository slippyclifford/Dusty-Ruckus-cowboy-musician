using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject CurrentCheckPoint;
    public Rigidbody2D Pc;

    //particles 
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    //Respawn Delay
    public float respawnDelay;

    //Point Penalty on Death
    public int pointPenaltyOnDeath;

    // Store Gravity Value
    private float gravityStore;

    // Use this for initialization

    void Start()
    {
        //Pc = FindObjectOfType<Rigidbody2D>();

    }
    public void RespawnPc()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo()
    {
        //Generate Death Particle
        Instantiate(DeathParticle, Pc.transform.position, Pc.transform.rotation);
        //Hide Player
        //Pc.enabled = false;
        Pc.GetComponent<Renderer>().enabled = false;
        //Gravity Reset 
        gravityStore = Pc.GetComponent<Rigidbody2D>().gravityScale;
        Pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Point Penalty 
        Score_Manager.AddPoints(-pointPenaltyOnDeath);
        //Debug Message
        Debug.Log("Player Respawn");
             //Respawn Delay
             yield return new WaitForSeconds(respawnDelay);
        //Gravity Restore
        Pc.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //Match Pcs transform position
        Pc.transform.position = CurrentCheckPoint.transform.position;
        //Show Pc
        //Pc.enabled = true;
        Pc.GetComponent<Renderer>().enabled = true;
        //spawn Pc 
        Instantiate(RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
    }
}