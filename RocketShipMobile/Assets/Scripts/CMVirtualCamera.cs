using UnityEngine;
using Cinemachine;

public class CMVirtualCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] PlayerInput player;
    GameObject lastTouchedPlanet;

    void Awake() 
    {
        player = FindObjectOfType<PlayerInput>();

        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain);
        if (brain == null)
        {
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }
    }

    void Start() 
    {
        lastTouchedPlanet = player.targetPlanet;
    }

    void Update() 
    {
        CheckPlayerStatus();
        virtualCamera.Follow = lastTouchedPlanet.transform;
    }

    void CheckPlayerStatus()
    {
        if (lastTouchedPlanet != player.targetPlanet && player.targetPlanet != null)
        {
            lastTouchedPlanet = player.targetPlanet;
        }
    }
}
