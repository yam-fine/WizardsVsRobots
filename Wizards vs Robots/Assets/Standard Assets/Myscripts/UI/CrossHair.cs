using UnityEngine;

public class CrossHair : MonoBehaviour {

    [SerializeField] int minSize, maxSize, speed;
    RectTransform crosshair;
    //Player player;

	void Start () {
        crosshair = GetComponent<RectTransform>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    public void CrosshairBig()
    {
        //float size = Mathf.Lerp(crosshair.sizeDelta.x, maxSize, Time.deltaTime * speed);
        crosshair.sizeDelta = new Vector2(maxSize, maxSize);
    }

    public void CrosshairSmall()
    {
        //float size = Mathf.Lerp(crosshair.sizeDelta.x, minSize, Time.deltaTime * speed);
        crosshair.sizeDelta = new Vector2(minSize, minSize);
    }
}
