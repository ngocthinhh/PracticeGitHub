using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum State
{
    Ready,
    Login,
    Ingame
}

public class AccountManager : MonoBehaviour
{
    DataHelper DataHelper = new DataHelper();

    [Header("Data")]
    [SerializeField] private string username;
    public string Username {  get { return username; } }
    [SerializeField] private State accountState;

    [Header("Ready Panel")]
    [SerializeField] private GameObject readyPanel;
    [SerializeField] private Button clickBtn;

    [Header("InGame Panel")]
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private TextMeshProUGUI usernameText;

    [Header("Login Panel")]
    [SerializeField] private GameObject loginPanel;
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private Button loginBtn;

    void Start()
    {
        SwitchPanel(State.Ready);
    }

    void SwitchPanel(State newState)
    {
        readyPanel.gameObject.SetActive(false);
        loginPanel.gameObject.SetActive(false);
        ingamePanel.gameObject.SetActive(false);

        // Last
        switch (accountState)
        {
            case State.Ready:
                break;
            case State.Login:
                break;
            case State.Ingame:
                break;
        }

        accountState = newState;

        // First
        switch (accountState)
        {
            case State.Ready:
                readyPanel.gameObject.SetActive(true);
                ReadyEvent();
                break;
            case State.Login:
                loginPanel.gameObject.SetActive(true);
                LoginEvent();
                break;
            case State.Ingame:
                ingamePanel.gameObject.SetActive(true);
                IngameEvent();
                break;
        }
    }

    #region Ready Func
    void ReadyEvent()
    {
        username = "";

        clickBtn.onClick.AddListener(() =>
        {
            WhatNext();
        });
    }
    void WhatNext()
    {
        bool isExist = CheckExistUser();

        if (isExist)
        {
            SwitchPanel(State.Ingame);
        }
        else
        {
            SwitchPanel(State.Login);
        }
    }
    bool CheckExistUser()
    {
        string name = DataHelper.LoadDataString("Username");
        if (string.IsNullOrEmpty(name)) return false;

        username = name;
        return true;
    }
    #endregion

    #region Login Func
    void LoginEvent()
    {
        usernameInput.text = "";

        loginBtn.onClick.AddListener(() =>
        {
            CheckUsernameInput(usernameInput.text);
            SwitchPanel(State.Ingame);
        });
    }
    void CheckUsernameInput(string value)
    {
        if (string.IsNullOrEmpty(value)) return;

        DataHelper.SaveData("Username", value);
        username = value;
    }
    #endregion

    #region Ingame Func
    void IngameEvent()
    {
        usernameText.text = username;
    }
    #endregion
}
