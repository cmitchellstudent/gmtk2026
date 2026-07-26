using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings")]
public class Settings : ScriptableObject
{
    [SerializeField] private float volumeSetting;

    public void SetVolume(float val)
    {
        if (val >= 0)
        {
            volumeSetting = 0;
        } else if (val <= -60)
        {
            volumeSetting = -60;
        }
        else
        {
            volumeSetting = val;
        }
    }

    public float GetVolume()
    {
        return volumeSetting;
    }
}
