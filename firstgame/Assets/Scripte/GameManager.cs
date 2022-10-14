using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int RndNmbr;
    public InputField InputField;
    public Text AffichageText;
    public Button SubmitButton;
    public GameObject QuitButton;
    public Transform buttonLowLetPos;
    public GameObject RestartButton;
    public Text Essaie;
    public int NmbrEssaie = 0;
    public int EssaieMax = 10;
    public Text inputFieldPlaceHolder;


    Vector3 quitButtonCenterPos;
    int EssaieRestant
    {
        get
        {
            return EssaieMax - NmbrEssaie;
        }
    }
    void Start()
    {
        quitButtonCenterPos = QuitButton.transform.position;
        NewGame();
        
    }

    void ResetUI()
    {
        InputField.gameObject.SetActive(true);
        SubmitButton.gameObject.SetActive(true);
        QuitButton.transform.position = buttonLowLetPos.position;
        (RestartButton).gameObject.SetActive(false);
        Essaie.text = EssaieMax + " Essaie(s) restant";
        AffichageText.text = "";
    }

    public void ResetInputField()
    {
        inputFieldPlaceHolder.enabled = true;
        InputField.text = "";
    }
    public void NewGame()
    {
        RndNmbr = GetRndNumber();
        ResetUI();
    }
    int GetRndNumber()
    {
        //RND
        System.Random rnd = new System.Random();
        int RndNumber = rnd.Next(101);

        return RndNumber;
    }
    public void Submit()
    {
        string UserInput = InputField.text;
        int UserNmbr;
        ResetInputField();

        if (!Int32.TryParse(UserInput, out UserNmbr))
        {
            AffichageText.text = ("Veuillez entrer un chiffre.");
        }
        else
        {
            NmbrEssaie++;
            Essaie.text = EssaieRestant + " Essaie(s) restant";
            if (UserNmbr > RndNmbr)
            {
                AffichageText.text = "C'est moins.";
            }
            else if (UserNmbr < RndNmbr)
            {
                AffichageText.text = "C'est plus.";
            }
            else if (UserNmbr == RndNmbr)
            {
                AffichageText.text = "Bravo ! Le nombre était bien " + (RndNmbr) + ".";
                QuitButton.transform.position = quitButtonCenterPos;
                (SubmitButton).gameObject.SetActive(false);
                (InputField).gameObject.SetActive(false);
                (QuitButton).gameObject.SetActive(true);
                (RestartButton).gameObject.SetActive(true);
            }
            if (NmbrEssaie == EssaieMax)
            {
                AffichageText.text = "Perdu ! Le nombre était " + (RndNmbr) + ".";
                QuitButton.transform.position = quitButtonCenterPos;
                (SubmitButton).gameObject.SetActive(false);
                (InputField).gameObject.SetActive(false);
                (QuitButton).gameObject.SetActive(true);
                (RestartButton).gameObject.SetActive(true);
            }
        }
    }
}