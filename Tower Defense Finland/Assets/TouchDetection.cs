using UnityEngine;
using UnityEngine.InputSystem;

public class TouchDetection : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    public float maxDistance = 500f;
    public float rotationSpeed = 10f;

    private Vector3 targetPoint;

    public static TouchDetection instance;
    public GameObject CurrentTower;

    public GameObject[] allCurrentTowerChildren;

    [SerializeField] private GameObject shop;

    [SerializeField] private GameObject shopPlacement;

    [SerializeField] private int chosenTower;

    [SerializeField] private LayerMask TowerLayer;

    private enum TypeTowers
    {
        UnderConstructionTower,
        ThorTower,
        AoeTower,
        DotTower
    }

    [SerializeField] private TypeTowers typeTowers;


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
            //Debug.Log("Geraakt object: " + hit.collider.gameObject.name);
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
        if (Physics.Raycast(cameraRay, out RaycastHit hit, maxDistance, TowerLayer))
        {
            targetPoint = hit.point;
            //interface zoeken
            //functien aanroepen

            if (hit.collider.gameObject.tag != "Tower" && hit.collider.gameObject.transform.parent.gameObject.tag == "Tower" && hit.collider.GetComponent<ObjectEventClick>() == null)
            {
                CurrentTower = hit.collider.gameObject.transform.parent.gameObject;
                Debug.Log("Geraakt object: " + hit.collider.gameObject.transform.parent.gameObject);


                Debug.Log("Geraakt object: " + hit.collider.gameObject.transform.parent.gameObject);
                if (CurrentTower != null && CurrentTower.gameObject != hit.collider.gameObject)
                {
                    if (CurrentTower.GetComponent<EventClick>() != null)
                    {
                        CurrentTower.GetComponent<EventClick>().ExitTower();
                    }
                    CurrentTower = null;
                }

                CurrentTower = hit.collider.gameObject;

                allCurrentTowerChildren = new GameObject[CurrentTower.transform.childCount];

                for (int i = 0; i < allCurrentTowerChildren.Length; i++)
                {
                    allCurrentTowerChildren[i] = CurrentTower.transform.GetChild(i).gameObject;
                }

                for (int j = 0; j < typeTowers.GetType().GetEnumValues().Length; j++)
                {
                    if(allCurrentTowerChildren != null)
                    {
                        if (allCurrentTowerChildren[0].gameObject.tag == typeTowers.GetType().GetEnumName(j))
                        {
                            chosenTower = j;
                            typeTowers = (TypeTowers)chosenTower;
                            break;
                        }
                    }
                    else
                    {
                        typeTowers = TypeTowers.UnderConstructionTower;
                    }
                }

                if (typeTowers == TypeTowers.UnderConstructionTower)
                {
                    if (CurrentTower.GetComponent<EventClick>() != null)
                    {
                        CurrentTower.GetComponent<EventClick>().ClickTower();
                    }
                }
            }
            else if (hit.collider.gameObject.tag == "Tower")
            {
                Debug.Log("Geraakt object: " + hit.collider.gameObject);
                if (CurrentTower != null && CurrentTower.gameObject != hit.collider.gameObject)
                {
                    if(CurrentTower.GetComponent<EventClick>() != null)
                    {
                        CurrentTower.GetComponent<EventClick>().ExitTower();
                    }
                    CurrentTower = null;
                }

                CurrentTower = hit.collider.gameObject;

                allCurrentTowerChildren = new GameObject[CurrentTower.transform.childCount];

                for (int i = 0; i < allCurrentTowerChildren.Length; i++)
                {
                    allCurrentTowerChildren[i] = CurrentTower.transform.GetChild(i).gameObject;
                }

                for (int j = 0; j < typeTowers.GetType().GetEnumValues().Length; j++)
                {
                    if (allCurrentTowerChildren[0].gameObject.tag == typeTowers.GetType().GetEnumName(j))
                    {
                        chosenTower = j;
                        typeTowers = (TypeTowers)chosenTower;
                        break;
                    }
                    else
                    {
                        typeTowers = TypeTowers.UnderConstructionTower;
                    }
                }

                if (typeTowers == TypeTowers.UnderConstructionTower)
                {
                    if (CurrentTower.GetComponent<EventClick>() != null)
                    {
                        CurrentTower.GetComponent<EventClick>().ClickTower();
                    }
                }
            }

            if (CurrentTower != null && hit.collider.gameObject.tag != "Tower" && hit.collider.gameObject.tag != "Tower Buttons")
            {
                if(CurrentTower.GetComponent<EventClick>() != null)
                {
                    CurrentTower.GetComponent<EventClick>().ExitTower();
                    CurrentTower = null;
                }
            }

            else
            {
                targetPoint = cameraRay.GetPoint(maxDistance);
            }
        }
    }
}