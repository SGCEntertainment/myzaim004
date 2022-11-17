using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource SFXSource { get; set; }

    private void Awake()
    {
        SFXSource = GameObject.Find("SFX").GetComponent<AudioSource>();

        AppManager.OnPressAction += () =>
        {
            if(SFXSource.isPlaying)
            {
                SFXSource.Stop();
            }

            SFXSource.Play();
        };
    }
}
