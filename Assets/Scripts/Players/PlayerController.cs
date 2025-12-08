using Assets.Scripts.Players;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent (typeof(NavMeshMouseResolver))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfig m_config; 
    [SerializeField] private NavMeshMouseResolver m_navMeshMouseResolver;
    [SerializeField] private PlayerMovement m_playerMovement;


    private void OnValidate()
    {
        if (!m_playerMovement)
        {
            m_playerMovement = GetComponent<PlayerMovement>();
        }
        if (!m_navMeshMouseResolver)
        {
            m_navMeshMouseResolver = GetComponent<NavMeshMouseResolver>();
        }
    }

    private void Start()
    {
        m_playerMovement.Initialize(m_config.speed);
        m_navMeshMouseResolver.Initialize(Camera.main);

    }

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3? navPoint = m_navMeshMouseResolver.GetNavMeshPoint(mousePosition);
            if (navPoint.HasValue)
            {
                m_playerMovement.SetDestination(navPoint.Value);
            }
        }
    }
}
