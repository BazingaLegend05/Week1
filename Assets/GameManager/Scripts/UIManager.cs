using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;
    [SerializeField] TextMeshProUGUI timeValue;
    void Start()
    {
        UpdateScoreUI(0);
        UpdateTimeUI(0);
    }
    public void UpdateScoreUI(int value)
    {
        // "D5" - minimum of 5 digits, preceding shorter numbers with 0s
        scoreValue.text = value.ToString("D5");
    }
    public void UpdateTimeUI(float time)
    {
        int seconds = (int)time;
        timeValue.text = System.TimeSpan.FromSeconds(seconds)
        .ToString("hh':'mm':'ss");
    }
}
