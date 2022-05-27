using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    public AudioClip ingredientAudioClip;
    public AudioClip iceAudioClip;
    public AudioClip magnetAudioClip;
    public AudioClip slowAudioClip;
    public AudioClip fastAudioClip;

    public AudioClip healthyAudioClip;
    public AudioClip sickAudioClip;
    public AudioClip walkingAudioClip;



    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //random pitch när det plockas upp? 
        audioSource.pitch = (Random.Range(0.7f, 1.3f));
        if (collision.CompareTag("Ingredient"))
        {
            audioSource.PlayOneShot(ingredientAudioClip);
        }
        else if (collision.CompareTag("Special"))
        {
            SpecialIdentifier(collision.GetComponent<Ingredient>().GetIngredientName());
        }
    }
    //POWERUPS
    private void SpecialIdentifier(string name)
    {
        if (name == "ice")
        { //1
            audioSource.PlayOneShot(iceAudioClip);
        }
        else if (name == "slow")
        { //2
            audioSource.PlayOneShot(slowAudioClip);
        }
        else if (name == "fast")
        { //3
            audioSource.PlayOneShot(fastAudioClip);
        }
        else if (name == "magnet")
        { //4
            audioSource.PlayOneShot(magnetAudioClip);
        }
    }


    public void HealthySound()
    {
       audioSource.PlayOneShot(healthyAudioClip);

    }

    public void SickSound()
    {
        audioSource.PlayOneShot(sickAudioClip);

    }

    public void WalkingSound()
    {
        audioSource.PlayOneShot(walkingAudioClip);

    }
}