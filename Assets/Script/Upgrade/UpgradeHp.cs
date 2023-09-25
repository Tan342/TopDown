using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHp : Upgrade
{
    public UpgradeHp()
    {
        this.name = "Increase Hp 20%";
    }

    public override void UpgradePlayer(Player player)
    {
        float hp = player.GetMaxHp();
        hp += hp*0.2f;
        player.SetMaxHp(hp);
    }

}
