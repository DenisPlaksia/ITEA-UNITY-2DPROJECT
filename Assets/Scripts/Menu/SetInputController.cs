using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetInputController : MonoBehaviour
{

    [SerializeField] private TMP_InputField _moveRightInput;
    [SerializeField] private TMP_InputField _moveLeftInput;
    [SerializeField] private TMP_InputField _moveShootInput;



    [SerializeField] private GameObject _setInputPanel;
    [SerializeField] private GameObject _settingMenu;
    [SerializeField] private Button _settingBackButton;


    private void Start()
    {
        _settingBackButton.onClick.AddListener(SettingBack);
    }

    private void SettingBack()
    {
        PlayerController.canMove = false;
        _setInputPanel.SetActive(false);
        _settingMenu.SetActive(true);
    }


    
}
