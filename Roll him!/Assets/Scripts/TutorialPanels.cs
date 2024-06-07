using UnityEngine;

public class TutorialPanels : MonoBehaviour
{
    [Header("- - - - - - GameObject - - - - - -")]
    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject tutorialPanel;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FirstTutor"))
        {
            tutorialPanel.SetActive(false);
        }

        else
        {
            tutorialPanel.SetActive(true);
        }   
    }
    public void CloseButton()
    {
        GUI.SetActive(true);
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("FirstTutor", System.Convert.ToInt32(tutorialPanel));
    }
}
