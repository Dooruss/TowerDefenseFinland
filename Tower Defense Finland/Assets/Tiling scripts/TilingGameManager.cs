using UnityEngine;
using UnityEngine.UI;

public class TilingGameManager : MonoBehaviour
{
    public float Health = 100f;
    [SerializeField] Image HealthBarFill;
   

    void Update()
    {
        if(Health <= 0)
        {
            Debug.Log("Game Over");
            Scene_Manager.LoadScene("You Died");
        }
    
     HealthBarFill.fillAmount = Health / 100f;
    
    }
}
