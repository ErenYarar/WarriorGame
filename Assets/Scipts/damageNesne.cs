using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class damageNesne : MonoBehaviour
{
    public float damage;
    bool getColliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(other.tag == "Enemy" && !getColliderBusy)
        {
            other.GetComponent<enemySlime2Manager>().GetDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            getColliderBusy = false;
        }
        if(other.tag == "Enemy")
        {
            getColliderBusy = false;
        }
    }
}
