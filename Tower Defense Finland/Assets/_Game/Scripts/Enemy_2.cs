using Cinemachine;
using System.Runtime.Serialization;
using UnityEngine;

public interface IEnemy2
{
    void Kill(int damage);
}
public class Enemy_2 : Entity, IEnemy
{
    private TowerShoot[] AllTowers;

    private void Update()
    {
        UpdateHealthBar();
        CheckDeath();
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

    public override void ExtraStartFunc()
    {
       // alltowers being put in a array
       // AllTowers = FindObjectsOfType<TowerShoot>();
    }

}
