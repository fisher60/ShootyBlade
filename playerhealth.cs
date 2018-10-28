using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


 public class playerhealth : MonoBehaviour
 {
 	public int startingHealth = 100;
 	public int currentHealth;
 	public Slider healthSilder;
 	public Image damageImage;
 	public AudioClip deathClip;
 	public float flashSpeed =5f;
 	public Color flashColour = new Color(1f, 0f, 0f,0.1f);
    [SerializeField]
    private GameObject damageObject;
    


 	//Animator anim;
 	//AudioSource playerAudio;
 	//PlayerMovement playerMovement;

 	bool isDead;
 	bool damaged;

 	void Awake ()
 	{
 		//anim = GetComponenet <Animator> ();
 		//playerAudio = GetComponenet <AudioSource> ();
 		//playerMovement = GetComponent <PlayerMovement> ();
 		//playerShooting = GetComponentInChildren <playerShooting> ();
 		currentHealth = startingHealth;
 	}

 	void Update ()
 	{
 		/*if(damaged)
 		{
 			damageImage.color = flashColour;
 		}
 		else
 		{
 			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

 		}*/

 		damaged = false;
 	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            TakeDamage(10);
        }
    }

 	public void TakeDamage (int amount)
 	{
 		damaged = true;
 		currentHealth -= amount;
 		healthSilder.value = currentHealth;
 		//playerAudio.Play();
 		if(currentHealth <= 0 && !isDead)
 		{
 			Death();
 		}
 	}
 	void Death()
 	{
 		isDead = true;
 		//playerShooting.DisableEffects();
 		//anim.SetTrigger("Die")
 		//playerAudio.clip = deathClip;
 		//playerAudio.Play();

 		//playerMovement.enabled = false;
 		//playerMovement.enabled = false;
 	}











 }


//unity3d.com/learn/tutorials/projects/survival-shooter/player-health