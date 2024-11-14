using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Doors : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] TMP_Text rightDoorText;
    [SerializeField] TMP_Text leftDoorText;


    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorAmount;

    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorAmount;

    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;

    private void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch(rightDoorBonusType)
        {
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorAmount;
                break;
            case BonusType.Difference:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorAmount;
                break;
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorAmount;
                break;
        }


        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorAmount;
                break;
            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorAmount;
                break;
        }
    }

    public int GetBonusAmount(float x)
    {
        if (x > 0)
            return rightDoorAmount;
        else
            return leftDoorAmount;
    }

    public BonusType GetBonusType(float x)
    {
        if(x > 0)
            return rightDoorBonusType;
        else 
            return leftDoorBonusType;
    }
}
