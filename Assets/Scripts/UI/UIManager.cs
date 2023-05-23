using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image sanityBar;
    [SerializeField] private ScriptableFloat playerSanity;
    [SerializeField] private TMP_Text remainingPactsText;
    [SerializeField] private TMP_Text purifiedPactsText;
    [SerializeField] private LevelsInformation levelInfo;
    private void Start()
    {
        remainingPactsText.text = "/ "+levelInfo.MaxPacts;
    }

    private void OnEnable()
    {
        PlayerStatus.OnPlayerDamage += UpdateSanityBar;
        EvilPactLogic.OnPurifyPact += UpdatePurifiedPacts;
    }

    private void OnDisable()
    {
        PlayerStatus.OnPlayerDamage -= UpdateSanityBar;
        EvilPactLogic.OnPurifyPact -= UpdatePurifiedPacts;
    }

    void UpdateSanityBar()
    {
        sanityBar.fillAmount = playerSanity.Value / playerSanity.InitialValue;
    }

    void UpdatePurifiedPacts()
    {
        purifiedPactsText.text = levelInfo.PurifiedPacts.ToString();
    }
}
