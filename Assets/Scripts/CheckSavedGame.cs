using UnityEngine;
using UnityEngine.UI;

public class CheckSavedGame : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    
    void Start()
    {
        if (PlayerPrefs.HasKey(NameHelper.XpPrefs))
        {
            continueButton.interactable = true;
        }
    }
}
