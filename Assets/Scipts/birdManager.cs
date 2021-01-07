using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class birdManager : MonoBehaviour
{
    public float health, damage;
    public GameObject blood;
    Animator playerAnimator;
    bool getColliderBusy = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !getColliderBusy)
        {
            getColliderBusy = true;
            other.GetComponent<playerManager>().GetDamage(damage);
        }  
        else if(other.tag == "Rock")
        {
            GetDamage(other.GetComponent<rockManager>().rockDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            getColliderBusy = false;
        }

    }

    public void GetDamage(float damage)
    {
        soundManager.PlaySound("enemyHit");
        if((health - damage) >= 0)
        {
            health -= damage;
        }
        else{
            health = 0;
        }
        AmIdead();
    }

    void AmIdead()
    {
        if(health <= 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            soundManager.PlaySound("enemyDeath");
            Destroy(gameObject);
        }
    }

    

}
