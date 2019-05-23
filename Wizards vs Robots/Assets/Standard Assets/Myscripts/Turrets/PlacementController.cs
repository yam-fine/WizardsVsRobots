using System.Collections;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField] GameObject placeablePrefab;
    [SerializeField] KeyCode newObjectHotKey = KeyCode.A;

    GameObject currentPlaceableObject;
    Turret turret;
    PlacementIndicator indicator;
    bool placingTurret = false;

    public bool PlacingTurret { get => placingTurret;}

    private void Update()
    {
        HandleHotKey();

        if (currentPlaceableObject != null)
        {
            MoveObject();

            if (Input.GetMouseButtonUp(0))
            {
                OnPlacement();
            }
        }
    }

    private void OnPlacement()
    {
        currentPlaceableObject = null;

        indicator.SetDissolve();
        StartCoroutine(Dissolve());
        placingTurret = false;
    }

    IEnumerator Dissolve()
    {
        float time = 2;

        while (time >= 0)
        {
            indicator.Dissolve.SetFloat("_FillAmount", time / 2);

            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        indicator.Dissolve.SetFloat("_FillAmount", 0);
        indicator.SetOriginalMaterials();

        turret.enabled = true;
    }

    private void MoveObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3( 0.5f, 0.5f, 0));
        RaycastHit hit;
        LayerMask mask = 9 | 11;

        if (Physics.Raycast(ray, out hit, 500, mask))
        {
            currentPlaceableObject.transform.position = hit.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            indicator.TurretTop.transform.LookAt(Camera.main.transform);
        }
    }

    void HandleHotKey()
    {
        if (Input.GetKeyDown(newObjectHotKey))
        {
            if (currentPlaceableObject == null)
            {
                placingTurret = true;
                currentPlaceableObject = Instantiate(placeablePrefab);

                turret = currentPlaceableObject.GetComponent<Turret>();
                indicator = currentPlaceableObject.GetComponent<PlacementIndicator>();
                turret.enabled = false;
            }
            else
            {
                placingTurret = false;
                Destroy(currentPlaceableObject);
            }
        }
    }


}