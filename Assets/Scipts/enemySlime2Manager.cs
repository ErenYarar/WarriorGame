using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemySlime2Manager : MonoBehaviour
{
    public float health, damage;
    public GameObject blood;
    Animator enemyAnimator;
    bool getColliderBusy = false;
    public Slider slider;

    // Düşman Hareketi
    public float speed;
    bool facingRight = true;
    public Transform groundDetec;

    //Düşman Hareketi sol - sağ belirleme
 

    void Start()
    {
        ////
        enemyAnimator = GetComponent<Animator>();
        slider.maxValue = health;
        slider.value = health;
    }

    void Update()
    {  
        characterMove();
    }  
    void characterMove()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetec.position, Vector2.down, 2f);
        if(groundInfo.collider == false)
        {
            if(facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
            } else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }
        }
        enemyAnimator.SetFloat("enemyWalk", speed);
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
        slider.value = health;
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
