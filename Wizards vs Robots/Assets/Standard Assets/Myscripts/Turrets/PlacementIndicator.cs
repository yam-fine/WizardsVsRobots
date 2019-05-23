using System.Collections.Generic;
using UnityEngine;

public class PlacementIndicator : MonoBehaviour
{
    List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    MeshRenderer topMR, baseMR;
    Material[] topGoodMat, topBadMat, topDissolveMat, topStartingMats;
    Material[] baseGoodMat, baseBadMat, baseDissolveMat, baseStartingMats;

    [SerializeField] Material goodPlacement, badPlacement;
    [SerializeField] Material dissolve;
    [SerializeField] GameObject turretTop, turretBase;

    public GameObject TurretTop { get => turretTop; }
    public GameObject TurretBase { get => turretBase; }
    public Material Dissolve { get => dissolve; }

    void Start()
    {
        topMR = turretTop.GetComponent<MeshRenderer>();
        baseMR = turretBase.GetComponent<MeshRenderer>();

        topStartingMats = topMR.materials;
        baseStartingMats = baseMR.materials;

        topGoodMat = new Material[topStartingMats.Length];
        topBadMat = new Material[topStartingMats.Length];
        topDissolveMat = new Material[topStartingMats.Length];
        baseGoodMat = new Material[baseStartingMats.Length];
        baseBadMat = new Material[baseStartingMats.Length];
        baseDissolveMat = new Material[baseStartingMats.Length];

        for (int i = 0; i < topStartingMats.Length; i++)
        {
            topGoodMat[i] = goodPlacement;
            topBadMat[i] = badPlacement;
            topDissolveMat[i] = dissolve;
        }

        for (int i = 0; i < baseStartingMats.Length; i++)
        {
            baseGoodMat[i] = goodPlacement;
            baseBadMat[i] = badPlacement;
            baseDissolveMat[i] = dissolve;
        }

        ChangeMat(true);
    }

    private void OnTriggerStay(Collider other)
    {
        ChangeMat(false);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeMat(true);
    }

    void ChangeMat(bool canPlace)
    {
        if (canPlace)
        {
            topMR.materials = topGoodMat;
            baseMR.materials = baseGoodMat;
        }
        else
        {
            topMR.materials = topBadMat;
            baseMR.materials = baseBadMat;
        }
    }

    public void SetDissolve()
    {
        topMR.materials = topDissolveMat;
        baseMR.materials = baseDissolveMat;
    }

    public void SetOriginalMaterials()
    {
        topMR.materials = topStartingMats;
        baseMR.materials = baseStartingMats;

        enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}