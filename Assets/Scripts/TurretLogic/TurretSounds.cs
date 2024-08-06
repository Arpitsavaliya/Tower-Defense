using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip shootingSFX;

    public void PlayShootingSFX()
    {
        if (BackgroundMusicManager.Instance != null)
        {
            BackgroundMusicManager.Instance.PlayOneShot(shootingSFX);
        }
    }
}
