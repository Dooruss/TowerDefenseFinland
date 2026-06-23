using UnityEngine;

public class TilingGameManager : MonoBehaviour
{
    public float Health = 100f;
   

    void Update()
    {
        if(Health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
