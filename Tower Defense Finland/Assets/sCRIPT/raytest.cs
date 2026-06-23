using UnityEngine;

public class raytest : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxDistance = 500f;
    public float timer = 0f;
    public float shootSpeed = 0.5f;
    public ParticleSystem particles;
    public int damage = 50;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = new Color(1f, 0.31f, 0.31f, 1f);
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Always start the line at this object's position
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit hit;
        
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // Draw line to the hit point
            lineRenderer.SetPosition(1, hit.point);
            Debug.Log("yay" + hit.collider.gameObject.name + "was hit");

            IEnemy enemy = hit.collider.GetComponent<IEnemy>();
            if (enemy != null && timer > shootSpeed)
            {
                Debug.Log("Hit enemy and damaged!");
                enemy.Kill(damage);

                if (particles != null)
                    particles.Play();

                timer = 0f;
            }
        }
        else
        {
            // No hit — draw line to max distance
            lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
        }
    }
}