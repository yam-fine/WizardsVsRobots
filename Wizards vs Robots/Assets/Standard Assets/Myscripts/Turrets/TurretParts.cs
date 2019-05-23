using UnityEngine;

public class TurretParts : MonoBehaviour
{
    [SerializeField] GameObject turretHead, turretBase;

    public GameObject TurretHead { get => turretHead; }
    public GameObject TurretBase { get => turretBase; }
}