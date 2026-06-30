using UnityEngine;

public class Buy_Sounds : MonoBehaviour
{
    [SerializeField] AudioClip AudioClip;

    public void PlayClip()
    {
        AudioSource.PlayClipAtPoint(AudioClip, new Vector3(-31, 72, 39), 1f);
    }

}
