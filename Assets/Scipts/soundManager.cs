using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, playerAttackSound, enemyDeathSound, enemyHitSound, playerAttackSound2, playerRockSound, playerDeathSound, gameOverSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip> ("playerHit");
        jumpSound = Resources.Load<AudioClip> ("playerJump");
        playerAttackSound = Resources.Load<AudioClip> ("playerAttack");
        playerAttackSound2 = Resources.Load<AudioClip> ("playerAttack3");
        enemyDeathSound = Resources.Load<AudioClip> ("enemyDeath");
        enemyHitSound = Resources.Load<AudioClip> ("enemyHit");
        playerRockSound = Resources.Load<AudioClip> ("playerRock");
        playerDeathSound = Resources.Load<AudioClip> ("playerDeath");
        gameOverSound = Resources.Load<AudioClip> ("gameOver");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "playerJump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "playerAttack":
                audioSrc.PlayOneShot(playerAttackSound);
                break;
            case "playerAttack3":
                audioSrc.PlayOneShot(playerAttackSound2);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "playerRock":
                audioSrc.PlayOneShot(playerRockSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
        }
    }
}
