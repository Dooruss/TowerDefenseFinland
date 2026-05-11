using Cinemachine;
using System.Runtime.Serialization;
using UnityEngine;

public class Enemy_1 : Entity
{
    private void Update()
    {
        CheckDeath();
        if (cartScript.m_Position == 1 && !IsParalelTrack)
        {
            //OnDeath(true);
        }
        else if (cartScript.m_Position == 1 && IsParalelTrack)
        {
            if (cartScript.m_Path == AllPaths[0])
            {
                int RandomNumber = Random.Range(1, 2);
                cartScript.m_Position = 0;
                cartScript.m_Path = AllPaths[RandomNumber];
            }
            else if (cartScript.m_Path == AllPaths[1] || cartScript.m_Path == AllPaths[2])
            {
                cartScript.m_Position = 0;
                cartScript.m_Path = AllPaths[3];
            }
            else
            {
                OnDeath(true);
            }
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
