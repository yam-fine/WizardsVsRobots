using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int coins;
    [SerializeField] TextMeshProUGUI coinsText;

    public int Coins { get => coins; set { coins += value; coinsText.text = coins.ToString(); } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
