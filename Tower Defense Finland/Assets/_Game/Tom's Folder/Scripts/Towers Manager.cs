using UnityEngine;
using UnityEngine.EventSystems;

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

    private void Update()
    {
        //if (Input.GetMouseButtonUp(0) && GetComponent<PhysicsRaycaster>().Raycast(out HitInfo != "Tower")
        //{
        //    Debug.Log(GetComponent<PhysicsRaycaster>().gameObject.tag);
        //}
    }
}
