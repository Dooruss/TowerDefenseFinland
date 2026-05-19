using System;
using UnityEngine;

public class PenetrationDemo : MonoBehaviour
{
    public LayerMask obstacleLayers;

    public Color mtvColor = Color.yellow;

    public bool autoResolve = true;

    public bool smoothResolve = true;

    public event Action<Vector3> OnPenetrationStart;
    public event Action<Vector3> OnPenetrationStay;
    public event Action OnPenetrationEnd;

    Collider col;
    Vector3 lastCorrection;
    bool resolvingCollision;


    private void Start()
    {
        col = GetComponent<Collider>();
        OnPenetrationStart += lastCorrection =>
        {
            float penetrationDepth = lastCorrection.magnitude;
            Debug.Log($"Started penetration, MTV = {penetrationDepth:F3}");

        };
        OnPenetrationEnd += () => { Debug.Log("Penetration resolved"); };
    }

    private void Update()
    {
        bool colliding = col.GetPenetrationsInLayer(obstacleLayers, out Vector3 correction);

        correction += correction.normalized * 0.001f;
        lastCorrection = colliding ? correction : Vector3.zero;

        if (colliding)
        {
            if (!resolvingCollision) OnPenetrationStart?.Invoke(correction);
            else OnPenetrationStay?.Invoke(correction);

            resolvingCollision = true;

            if(autoResolve)
            {
                Vector3 delta = smoothResolve ? Vector3.Lerp(Vector3.zero, correction, 0.05f) : correction;
                transform.position += delta;
            }

            Debug.Log($"Colliding, MTV = {correction.magnitude:F3}");
        }
        else
        {
            if (resolvingCollision) OnPenetrationEnd?.Invoke();
            resolvingCollision = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (col == null) col = GetComponent<Collider>();
        if(col == null) return;

        if(lastCorrection != Vector3.zero)
        {
            Vector3 start = col.bounds.center;
            Vector3 end = start + lastCorrection;
            Gizmos.color = mtvColor;
            Gizmos.DrawSphere(end, 0.05f);
        }
    }
}
