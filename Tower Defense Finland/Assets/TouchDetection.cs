using UnityEngine;
using UnityEngine.InputSystem;

public class TouchDetection : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    public float maxDistance = 500f;
    public float rotationSpeed = 10f;

    private Vector3 targetPoint;

    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.002f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = new Color(1f, 0.31f, 0.31f, 0.25f);

        targetPoint = transform.position + transform.forward * maxDistance;
    }

    private void Update()
    {
        CheckForTouchInput();
        UpdateLaser();
    }

    private void UpdateLaser()
    {
        Vector3 direction = targetPoint - transform.position;
        //turn raycast depening on mouse pos
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        lineRenderer.SetPosition(0, transform.position);
        //draw lazer not further than hit object
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);
            Debug.Log("Geraakt object: " + hit.collider.gameObject.name);
        }
        //draw raycast if nothing is hit
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
        }
    }

    private void CheckForTouchInput()
    {
        // Muis klik
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectObject(Mouse.current.position.ReadValue());
        }
    }

    private void DetectObject(Vector2 screenPos)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(screenPos);

        //logic here
        if (Physics.Raycast(cameraRay, out RaycastHit hit, maxDistance))
        {
            targetPoint = hit.point;
            Debug.Log("Geraakt object: " + hit.collider.gameObject.name);
            //interface zoeken
            //functien aanroepen
        }
        else
        {
            targetPoint = cameraRay.GetPoint(maxDistance);
        }
    }
}