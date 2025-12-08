using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TargetMarker m_targetMarker;
    [SerializeField] private NavMeshAgent m_agent;

    private float m_speed;

    private void OnValidate()
    {
        if (!m_agent)
        {
            m_agent = GetComponent<NavMeshAgent>();
        }
    }

    public void SetDestination(Vector3 navMeshPoint)
    {
        m_targetMarker.Show(navMeshPoint);
        m_agent.SetDestination(navMeshPoint);
    }

    private void Awake()
    {
        Initialize(m_speed);
    }
    public void Initialize(float speed)
    {
        m_speed = speed;
        m_agent.speed = speed;
    }
}
