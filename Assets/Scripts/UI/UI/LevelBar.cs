using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField]
    private Image uiFillImage;
    [SerializeField]
    private Text uiStartText;
    [SerializeField]
    private Text uiNextText;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform endLineTransform;

    private Vector3 endLinePosion;
    private float fullDistance;


    private void Start()
    {
        endLinePosion = endLineTransform.position;
        fullDistance = GetDistance();
        SetLevelText();
    }
    public void SetLevelText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        uiStartText.text = level.ToString();
        uiNextText.text = (level + 1).ToString();
    }
    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, endLinePosion);
    }
    private void UptadeProgressValue(float value)
    {
        uiFillImage.fillAmount = value;
    }
    private void Update()
    {
        float newDistance = GetDistance();
        float progresValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
        UptadeProgressValue(progresValue);

    }
}
