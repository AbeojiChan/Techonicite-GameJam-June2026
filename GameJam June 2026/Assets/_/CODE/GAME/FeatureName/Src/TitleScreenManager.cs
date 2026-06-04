using UnityEngine;
using Levels.Runtime;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private LevelData m_level01;

    public async void OnStartClicked()
    {
        await LevelManager.Load(m_level01);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}