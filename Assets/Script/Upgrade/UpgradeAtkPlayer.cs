using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAtkPlayer : Upgrade
{
    public UpgradeAtkPlayer()
    {
        this.name = "Increase 2 atk";
    }

    public override void UpgradePlayer(Player player)
    {
        float atk = player.GetAtk();
        atk += 2; 
        player.SetAtk(atk);
    }


}
