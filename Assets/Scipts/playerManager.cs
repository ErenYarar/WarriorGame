using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerManager : MonoBehaviour
{
    public GameObject blood;
    public float health;
    Animator playerAnimator;
    Rigidbody2D playerRB;
    bool dead = false;
    public Slider slider;
    Transform muzzle;
    public Transform floatingText;

    //// Respawn///
    public int Respawn;

    ////// attack ///
    bool attack;
    bool attackTwo;
    public Transform attackPos;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
 
    // Rock Attack
    [SerializeField]
    private GameObject[] ammo;
    private int ammoAmount;
    public Transform rock;
    Transform namlu;
    public float rockSpeed;  

    //dead screen
    public GameObject deadMenuUI;

    void Start()
    {
        //Oyunun başında 0 mermi olacak
        for(int i = 0; i<= 2; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }
        ammoAmount = 0;

        namlu = transform.GetChild(2);
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        slider.maxValue = health;
        slider.value = health;
    }

    
    void Update()
    {
        SwordInput();
        if(Input.GetKeyDown(KeyCode.C) && ammoAmount > 0)
        {
            ShotRock();
        }

        //Yeniden dolması için 
        if(Input.GetKey(KeyCode.R))
        {
            ammoAmount = 3;
            for (int i = 0; i <= 2; i++)
            {
                ammo[i].gameObject.SetActive(true);
            }
        }     
    }

    void ShotRock()
    {
        Transform tempRock;
        tempRock = Instantiate(rock, namlu.position, Quaternion.identity);
        tempRock.GetComponent<Rigidbody2D>().AddForce(namlu.forward * rockSpeed);
        ammoAmount -= 1;
        ammo[ammoAmount].gameObject.SetActive(false);
        //playerRockSound
        soundManager.PlaySound("playerRock");
    }

    private void FixedUpdate() 
    {
        SwordAttack();
        ResetValues();
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        playerAnimator.SetTrigger("playerHit");
        soundManager.PlaySound("playerHit");
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
            dead = true;                    
            Deadscreen();    
            //playerAnimator.SetTrigger("playerDeath"); 
            //SceneManager.LoadScene("LoadingScreen");
        }
    }

    void Deadscreen()
    {
        soundManager.PlaySound("playerDeath");
        deadMenuUI.SetActive(true);       
        Time.timeScale = 0f;
        //SceneManager.LoadScene(Respawn);
    }

    void SwordAttack()
    {  
        if(attack && !this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("playerAttack"))
        {
            playerAnimator.SetTrigger("playerAttack");
            playerRB.velocity = Vector2.zero;  
            soundManager.PlaySound("playerAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);  
            /*
            foreach (Collider2D enemy in hitEnemies)
            {
                //enemy.GetComponent<enemySlime2Manager>().GetDamage(10);
                enemy.GetComponent<birdManager>().GetDamage(10);
            }  */ 
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                if(hitEnemies[i].GetComponent<birdManager>())
                {
                    hitEnemies[i].GetComponent<birdManager>().GetDamage(10);
                }
                if(hitEnemies[i].GetComponent<enemySlime2Manager>())
                {
                    hitEnemies[i].GetComponent<enemySlime2Manager>().GetDamage(10);
                }
                if(hitEnemies[i].GetComponent<enemyManager>())
                {
                    hitEnemies[i].GetComponent<enemyManager>().GetDamage(10);
                }
                
            }       
        } 
        if(attackTwo && !this.playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("playerAttackTwo"))
        {
            playerAnimator.SetTrigger("playerAttackTwo");
            playerRB.velocity = Vector2.zero;  
            soundManager.PlaySound("playerAttack3");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);   
            /*
            foreach (Collider2D enemy in hitEnemies)
            {
                //enemy.GetComponent<enemySlime2Manager>().GetDamage(10);
                enemy.GetComponent<birdManager>().GetDamage(10);
            } */
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                if(hitEnemies[i].GetComponent<birdManager>())
                {
                    hitEnemies[i].GetComponent<birdManager>().GetDamage(10);
                }
                if(hitEnemies[i].GetComponent<enemySlime2Manager>())
                {
                    hitEnemies[i].GetComponent<enemySlime2Manager>().GetDamage(10);
                }
                if(hitEnemies[i].GetComponent<enemyManager>())
                {
                    hitEnemies[i].GetComponent<enemyManager>().GetDamage(10);
                }
            }     
        } 
    }
    private void OnDrawGizmosSelected() 
    {
        if(attackPos == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void SwordInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            attack = true;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            attackTwo = true;
        }
    }
    void ResetValues()
    {
        attack = false;
        attackTwo = false;
    }
}
