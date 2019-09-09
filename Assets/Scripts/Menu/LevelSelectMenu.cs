using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelectMenu : MonoBehaviour
{
    EventSystem events;

    private void Start()
    {
        events = FindObjectOfType<EventSystem>();
    }
    private void Update()
    {
        if (events.currentSelectedGameObject == null)
        {
            events.SetSelectedGameObject(events.firstSelectedGameObject);
        }
    }
    public void SetLevel(int level)
    {
        GameManager.startLevel = level;
    }
}
