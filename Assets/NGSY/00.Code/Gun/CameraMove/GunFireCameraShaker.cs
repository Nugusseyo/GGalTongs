using Unity.Cinemachine;
using UnityEngine;

public class GunFireCameraShaker : MonoBehaviour
{
    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private float force = 0.2f;

    public void ShakeCamera()
    {
        impulseSource.GenerateImpulse(force);
    }
}
