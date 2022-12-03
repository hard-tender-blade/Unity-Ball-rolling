using UnityEngine;
using UnityEngine.UI;

public class StarPickUp : MonoBehaviour
{
    [SerializeField] private GameObject StarsCounterUI;
    [SerializeField] private AudioSource CoinPickedUpSource;
    private int StarCount = 0;

    private void OnTriggerEnter(Collider OtherObject)
    {
        if (OtherObject.gameObject.tag == "Star")
        {
            OtherObject.gameObject.SetActive(false);
            StarCount++;
            StarsCounterUI.GetComponent<Text>().text = $"{StarCount}/10";
            CoinPickedUpSource.Play();
        }
    }
}
