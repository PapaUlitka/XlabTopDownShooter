using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent m_agent;

    private float m_speed;

    private void OnValidate()
    {
        if (!m_agent)
        {
            m_agent = GetComponent<NavMeshAgent>();
        }
    }

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {

    }
}
