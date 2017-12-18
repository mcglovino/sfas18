using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    public float RotPerSec = 1;
    public bool rot = true;

    protected void Update()
    {
        if (!rot)
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotPerSec);
    }
}