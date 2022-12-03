using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip TreeHitClip;
    [SerializeField] private AudioClip RocksHitClip;

    private void OnCollisionEnter(Collision OrtherObject)
    {
        if (OrtherObject.gameObject.tag == "Tree") Source.PlayOneShot(TreeHitClip);
        else if (OrtherObject.gameObject.tag == "Stone") Source.PlayOneShot(RocksHitClip);
    }
}
  