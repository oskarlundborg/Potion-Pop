using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSound : MonoBehaviour
{
    public AudioClip ingredientAudioClip;
    public AudioClip iceAudioClip;
    public AudioClip magnetAudioClip;


    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            if (collision.GetComponent<Ingredient>().GetIngredientName() == "ice")
            {
                //random pitch när det plockas upp? 
                //audioSource.pitch = (Random.Range(0.7f, 1.3f));
                audioSource.PlayOneShot(iceAudioClip);
            }
            else if (collision.GetComponent<Ingredient>().GetIngredientName() == "magnet")
            {
                audioSource.PlayOneShot(magnetAudioClip);

            }
            else
            {
                audioSource.PlayOneShot(ingredientAudioClip);
            }

        }

    }
}