using System.Collections;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    [SerializeField] float destroyMeAfter;

    private void Start()
    {
        StartCoroutine(IWantToDie());
    }

    IEnumerator IWantToDie()
    {
        yield return new WaitForSeconds(destroyMeAfter);

        Destroy(gameObject);
    }
}
