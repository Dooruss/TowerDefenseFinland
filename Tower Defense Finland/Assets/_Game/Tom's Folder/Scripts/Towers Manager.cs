using UnityEngine;

public class TowersManager : MonoBehaviour
{
    public static TowersManager instance;

    public GameObject CurrentTower;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(instance);
        }
    }
}
