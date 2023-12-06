using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : Pickup , ICollectable
{
    public int experienceGranted;
    public void Collect()
    {
        PlayerStats player = FindAnyObjectByType<PlayerStats>();
        player.IncreaseExperience(experienceGranted);
    }

}
 