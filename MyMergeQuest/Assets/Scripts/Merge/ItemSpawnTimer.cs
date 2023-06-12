using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawnTimer : MonoBehaviour
{
    [SerializeField] private Button spawnButton;

    private float timeToRefillButton = 3f;

    private float spawnTimerValue;

    private void Start()
    {
        spawnTimerValue = timeToRefillButton;
        spawnButton.interactable = true;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer() 
    {
        if (spawnTimerValue < timeToRefillButton) 
        {
            spawnButton.interactable = false;
            spawnTimerValue += Time.deltaTime;
            spawnButton.image.fillAmount = spawnTimerValue / timeToRefillButton;
        } 
        else if (spawnTimerValue >= timeToRefillButton)
        {
            spawnButton.interactable = true;
            spawnTimerValue = timeToRefillButton;
            spawnButton.image.fillAmount = 1;
        }
    }

    public void ResetTimer()
    {
        spawnTimerValue = 0;
        spawnButton.image.fillAmount = 0;
        
    }
}
