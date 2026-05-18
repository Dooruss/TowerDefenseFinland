using UnityEngine;
using UnityEngine.InputSystem.XR;

public class TowerShoot : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxDistance = 500f;
    public float timer = 0f;
    public float shootSpeed = 0.5f;
    public ParticleSystem particles;
    public int damage = 50;
    void Start()
    {
        // Haal of voeg een LineRenderer toe aan de controller
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // LineRenderer instellingen
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.002f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        //lineRenderer.material.color = new Color(1f, 0.31f, 0.31f, 0.25f); // Soft red with subtle transparency
        lineRenderer.material.color = new Color(1f, 0.31f, 0.31f, 0f); // Soft red with subtle transparency

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            IEnemy enemy = hit.rigidbody.GetComponent<IEnemy>();
            if (enemy != null && timer > shootSpeed)
            {
                Debug.Log("Hit Something");
                enemy.Kill(damage);
                particles.Play();
                timer = 0f;
            }
        }

        // Update de startpositie van de lijn (bij de controller)
        lineRenderer.SetPosition(0, transform.position);
        // Update lijn om te stoppen bij de hit locatie
        lineRenderer.SetPosition(1, hit.point);
        // Geen hit? Trek lijn naar max afstand en verberg de laser dot
        lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
    }
}
