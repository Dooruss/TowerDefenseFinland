using System.Runtime.Serialization;
using UnityEngine;

public class Enemy_1 : Entity
{
    private void Update()
    {
        CheckDeath();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        //+ add money for stuff
    }

}
