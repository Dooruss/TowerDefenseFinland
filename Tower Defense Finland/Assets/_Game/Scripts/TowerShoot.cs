using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Rendering;

public class TowerShoot : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxDistance = 500f;
    public float timer = 0f;
    public float shootSpeed = 0.5f;
    public ParticleSystem particles;
    public int damage = 10;
    [SerializeField] private AudioClip shootSound;

    [Header("Rotation")]
    [SerializeField] GameObject Base;
    [SerializeField] GameObject target;
    float strength = 4f;
    public List<GameObject> EnemyList;
    void Start()
    {
        // Haal of voeg een LineRenderer toe aan de controller
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // LineRenderer instellingen
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = new Color(1f, 0.31f, 0.31f, 0f); // Soft red with subtle transparency

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            Debug.Log("Hit Something");
            IEnemy enemy = hit.collider.GetComponent<IEnemy>();
            if (enemy != null && timer > shootSpeed)
            {
                Debug.Log("Hit Something and damaged!");
                AudioSource.PlayClipAtPoint(shootSound, new Vector3(-31, 72, 39), 0.7f);
                enemy.Kill(damage);
                if (EnemyList.Count > 0 && EnemyList[0] == null)
                {
                    EnemyList.RemoveAt(0);
                    Debug.Log("Remove Enemy");
                }
                particles.Play();
                timer = 0f;
            }
        }

        EnemyList.RemoveAll(e => e == null);
        if (EnemyList.Count > 0)
        {
            target = EnemyList[0];
            RotateTowerToEnemy();
            Debug.Log("Do that plz");
        }
        


        // Update de startpositie van de lijn (bij de controller)
        lineRenderer.SetPosition(0, transform.position);
        // Update lijn om te stoppen bij de hit locatie
        lineRenderer.SetPosition(1, hit.point);
        // Geen hit? Trek lijn naar max afstand en verberg de laser dot
        lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);

    }

    private void RotateTowerToEnemy()
    {
        if (target == null || Base == null) return;
        // Bereken de rotatie die de Base nodig heeft om richting target te kijken
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - Base.transform.position);

        // Lerp-factor geclampt tussen 0 en 1
        float t = Mathf.Min(strength * Time.deltaTime, 1f);

        // Pas de rotatie toe op de Base, niet op de root van de tower
        Base.transform.rotation = Quaternion.Lerp(Base.transform.rotation, targetRotation, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //get the name and then remove it
            string EnemeyName = other.name;
            //the word enemy is a placeholder variable representing each individual element in the EnemyList as the list is being searched.
            GameObject EnemyOBJ = EnemyList.FirstOrDefault(enemy => enemy.name == EnemeyName);
            EnemyList.Remove(EnemyOBJ);
        }

    }
}
