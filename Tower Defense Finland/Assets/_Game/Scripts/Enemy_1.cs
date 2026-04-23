using Cinemachine;
using System.Runtime.Serialization;
using UnityEngine;

public class Enemy_1 : Entity
{
    private void Update()
    {
        CheckDeath();
        if (cartScript.m_Position == 1)
        {
            OnDeath(true);
        }
    }

    public override void OnDeath(bool AttacksTower)
    {
        if (AttacksTower == true)
        {
            //dmgs tower
            print("Attacked tower / reached the end");
        }
        base.OnDeath(AttacksTower);
    }

}
