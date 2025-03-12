using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float JumpForce, Rotation;
    public Transform spawnPost;
    public bool isInit = false;
    public AudioManager Audio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
    
    }
    public void Init()
    {
        isInit = true;
    }
    void Update()
    {
        if (isInit)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        if (Input.GetMouseButtonDown(0)) {
            Audio.playAudio(Audio.wing);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * Rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameplayController.Instance.LoosePopUp();
        }
        else if(collision.CompareTag("ScoreZone"))
        {
            GameplayController.Instance.scoreIndex += 1;
        }else if (collision.CompareTag("ScoreZone1"))
        {
            GameplayController.Instance.scoreIndex += 2;
        }
        else if (collision.CompareTag("ScoreZone2"))
        {
            GameplayController.Instance.scoreIndex += 3;
        }
    }
    public void ReturnPos()
    {
        this.gameObject.transform.position = spawnPost.transform.position; 
    }
    

}
