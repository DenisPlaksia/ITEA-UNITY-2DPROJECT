using UnityEngine;
using TMPro;

public class TimeShower : MonoBehaviour
{

    private TextMeshProUGUI _timeShower;
    [SerializeField] private TextMeshProUGUI _newRecordShow;
    private const string TimeCount = "TIME";
    void Start()
    {
        _timeShower = GetComponent<TextMeshProUGUI>();
        ShowTime();
    }

    private void Update()
    {
        RemoveRecord();
    }

    private void ShowTime()
    {
        _timeShower.text = Time.timeSinceLevelLoad.ToString();
        NewRecordCheck();
        PlayerPrefs.SetFloat(TimeCount, Time.timeSinceLevelLoad);
    }

    private void RemoveRecord()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.SetFloat(TimeCount, 1000f);
        }
    }

    private void NewRecordCheck()
    {
        if(Time.timeSinceLevelLoad < PlayerPrefs.GetFloat(TimeCount))
        {
            _newRecordShow.text = "New Record!!!!";
        }
    }
}
