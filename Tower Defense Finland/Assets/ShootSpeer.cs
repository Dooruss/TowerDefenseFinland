using Unity.VisualScripting;
using UnityEngine;

public class ShootSpeer : MonoBehaviour
{
    public Transform objectToHit;
    private Vector3 targetPosition;
    public float speed = 10;
    void Update()
    {
        if (objectToHit == null)
        {
            Debug.Log("Object is gone!");
            Destroy(this.gameObject);
        }
        else
        {
            targetPosition = objectToHit.position;
            transform.LookAt(objectToHit);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (this.gameObject.transform.position == targetPosition)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
