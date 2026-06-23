using Unity.AI.Navigation.Editor;
using UnityEngine;
using UnityEngine.AI;

public class RunningEnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    private Transform End;

    private void Start()
    {
        End = GameObject.Find("END").GetComponent<Transform>();
    }
    void Update()
    {
        agent.SetDestination(End.position);
    }
}
