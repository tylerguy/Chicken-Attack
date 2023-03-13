using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    // get the player object
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get currenth health from the player object
        float CurrentHealth = player.currentHealth;
        // get max health from the player object
        float MaxHealth = player.maxHealth;

        // get child object with the name "HealthFill"
        Transform healthFill = transform.Find("HealthFill");
        // get the scale of the healthFill object
        Vector3 healthScale = healthFill.localScale;
        // set the x scale of the healthFill object to the current health
        healthScale.x = CurrentHealth / MaxHealth;
        // set the scale of the healthFill object to the new scale
        healthFill.localScale = healthScale;
    }
}
