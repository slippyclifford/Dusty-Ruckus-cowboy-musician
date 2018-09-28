using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject currentCheckPoint;
    private Rigidbody2D Pc;

    //particles 
    public GameObject deathParticle;
    public GameObject respawnParticle;

    //Respawn Delay
    public float respawnDelay;

    //Point Penalty on Death
    public int pointPenaltyOnDeath;

    // Store Gravity Value
    private float gravityStore;

    // Use this for initialization

    void Start () {
        player = findObjectOfType<Rigidbody2D>();

    }
    public void RespawnPc(){
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnnumerator RespawnPlayerCo(){
        //Generate Death Particle
        Instantiate(deathParticle, Pc.transform.position, pc.transform.rotation);
                     //Hide Player
                     Pc.enabled = false;
        Pc.GetComponent<Renderer> ().enabled = false;
        //Gravity Reset 
        gravityStore = Pc.GetComponent<Rigidbody2D>().gravityScale;
        Pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Pc.Getcomponent <Rigidbody2D> ().velocity = Vector2.zero;
        //Point Penalty 
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //Debug Message
        Debug.Log ("Player Respawn")
             //Respawn Delay
             yield return new WaitForSeconds(respawnDelay);
    }