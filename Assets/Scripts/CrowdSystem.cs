using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float goldenAngle;
    [SerializeField] float radius;

    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] Transform runnerParent;
    [SerializeField] GameObject RunnerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunner();
    }

    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * goldenAngle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * goldenAngle);

        return new Vector3(x, 0, z);
    }

    private void PlaceRunner()
    {
        for (int i = 0; i < runnerParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i);
            runnerParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnerParent.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch(bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
                break;
            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                break;
            case BonusType.Product:
                int runnersToAdd = (runnerParent.childCount * bonusAmount) - runnerParent.childCount;
                AddRunners(runnersToAdd);
                break;
            case BonusType.Division:
                int runnersToRemove = runnerParent.childCount - (runnerParent.childCount / bonusAmount);
                RemoveRunners(runnersToRemove);
                break;
        }
    }

    private void AddRunners(int bonusAmount)
    {
        for(int i = 0; i < bonusAmount; i++)
        {
            Instantiate(RunnerPrefab, runnerParent);
        }


        playerAnimator.Run();
    }

    private void RemoveRunners(int bonusAmount)
    {
        if(bonusAmount > runnerParent.childCount)
            bonusAmount = runnerParent.childCount;

        int runnerAmount = runnerParent.childCount;

        for(int i = runnerAmount - 1; i >= runnerAmount - bonusAmount; i--)
        {
            Transform runnerToDestroy = runnerParent.GetChild(i);
            runnerToDestroy.SetParent(null);
            Destroy(runnerToDestroy.gameObject);
        }
    }
}
