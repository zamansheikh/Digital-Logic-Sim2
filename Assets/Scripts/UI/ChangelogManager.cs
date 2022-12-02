using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangelogManager : MonoBehaviour
{
    [SerializeField] private GameObject changelogBoard;
    [SerializeField] private string currentGameVersion;
    [SerializeField] private string previousGameVersion;
    [SerializeField] private bool showChangelog = true;
    [SerializeField] private Toggle showChangelogToggle;

    void Start()
    {
        showChangelog = PlayerPrefs.GetInt("ShowChangelog") == 1 ? true : false;
        showChangelogToggle.isOn = showChangelog;
        changelogBoard.gameObject.SetActive(showChangelog);
        currentGameVersion = Application.version;
        previousGameVersion = PlayerPrefs.GetString("version");
        if(currentGameVersion != previousGameVersion)
        {
            if (showChangelog)
            {
                changelogBoard.SetActive(true);
                changelogBoard.GetComponent<Animator>().SetTrigger("Pop up");
            }
        }
        previousGameVersion = currentGameVersion;
        PlayerPrefs.SetString("version", previousGameVersion);
        PlayerPrefs.Save();
    }

    void Update()
    {

    }

    public void SetShowChangelog(bool value)
    {
        showChangelog = value;
        PlayerPrefs.SetInt("ShowChangelog", showChangelog ? 1 : 0);
    }

}
