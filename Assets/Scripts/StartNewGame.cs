using UnityEngine;

public class StartNewGame : MonoBehaviour
{
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteKey(NameHelper.LevelPrefs);
        PlayerPrefs.DeleteKey(NameHelper.XpPrefs);
        PlayerPrefs.DeleteKey(NameHelper.GoldPrefs);
    }
}
