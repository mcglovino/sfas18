using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    // --------------------------------------------------------------

    // Events
    public delegate void PlayerDeath(int playerNum);
    public static event PlayerDeath OnPlayerDeath;

    // --------------------------------------------------------------

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PController playerController = other.gameObject.GetComponent<PController>();
            if(playerController)
            {
                // Kill the player
                playerController.Die();

                // Increase the score for the opposing player
                if(OnPlayerDeath != null)
                {
                    OnPlayerDeath(playerController.GetPlayerNum(false));
                }
            }
        }

        if (other.gameObject.tag == "Falling")
        {
            Falling fall = other.gameObject.GetComponent<Falling>();
            if (fall)
            {
                fall.Die();
            }
        }
    }
}
