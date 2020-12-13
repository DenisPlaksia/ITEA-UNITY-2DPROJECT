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
        _timeShower.text = Time.time.ToString();
        NewRecordCheck();
        PlayerPrefs.SetFloat(TimeCount, Time.time);
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
        if(Time.time < PlayerPrefs.GetFloat(TimeCount))
        {
            _newRecordShow.text = "New Record!!!!";
        }
    }
}
