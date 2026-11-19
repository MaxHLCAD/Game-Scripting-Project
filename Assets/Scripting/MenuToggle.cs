using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    [SerializeField] private GameObject toggle;

    public void ToggleOn()
    {
        toggle.SetActive(true);
    }

    public void ToggleOff()
    {
        toggle.SetActive(false);
    }

    public void Toggle()
    {
        toggle.SetActive(toggle.activeSelf);
    }



}
