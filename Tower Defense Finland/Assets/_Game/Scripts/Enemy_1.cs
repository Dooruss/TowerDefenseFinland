using Cinemachine;
using System.Runtime.Serialization;
using UnityEngine;

public interface IEnemy
{
    void Kill(int damage);
}
public class Enemy_1 : Entity, IEnemy
{

    private void Update()
    {
        UpdateHealthBar();
        CheckDeath();
        if (cartScript.m_Position == 1 && !IsParalelTrack)
        {
            // Als het geen parelel is (gwn 1 lijn) en de cart is op positie 1 (eind) dan gaat de cart dood en valt het aan op de toren
            OnDeath(true);
        }
        else if (cartScript.m_Position == 1 && IsParalelTrack) //als het wel paralel is
        {
            if (cartScript.m_Path == AllPaths[0]) // Als het bij het einde van de eerste 'lijn' is
            {
                int RandomNumber = Random.Range(1, 3); // kiest links of rechts
                cartScript.m_Position = 0;
                cartScript.m_Path = AllPaths[RandomNumber]; // gaat naar 1 of 2
            }
            else if (cartScript.m_Path == AllPaths[1] || cartScript.m_Path == AllPaths[2]) // aan het einde van links of rechts
            {
                cartScript.m_Position = 0;
                cartScript.m_Path = AllPaths[3]; // ga naar de laatste lijn
            }
            else
            {
                OnDeath(true); // als het dan bij het einde van de laatste lijn is , gaat het dood en valt het aan op de toren
            }
        }
    }

    public override void OnDeath(bool AttacksTower)
    {
        if (AttacksTower == true)
        {
            MainTower.MainCurrentHealth -= AttackPower;
            print("Attacked tower / reached the end");
        }
        base.OnDeath(AttacksTower);
    }

    public void Kill(int damage)
    {
        //damage
        TakeDamage(damage);
    }

}
