using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ska ha objekt
public class QuestHandler : MonoBehaviour
{
    //private Cauldron cauldron;
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject level;
    private float timer;
    
    // seriaziblae field med levelobjektet med leveldata och levelstate på

    private void Start()
    {
        
        //this.timer = level.GetComponent<LevelData>().getTimer();
    }

    // laddar in info från leveldata, och spottar ut en quest

    // Completed Quest, om timer fortfarande har tid spottas ett till quest om quest är complete

    public void ResetScore() {
        //spara resultat för en stjärna

    }

}
