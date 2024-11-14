using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] GameObject menu;
    [SerializeField] Slider progressBar;
    [SerializeField] TMP_Text levelText;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        progressBar.value = 0;

        levelText.text = "Level: " + (ChunkManager.Instance.GetLevel() + 1);
    }

    private void Update()
    {
        UpdateProgressBar();
    }

    public void PlayButtonPressed()
    {
        GameManager.Instance.SetGameState(GameState.Game);
        menu.SetActive(false);
    }

    public void UpdateProgressBar()
    {
        float progress = PlayerController.Instance.transform.position.z / ChunkManager.Instance.GetFinishZ();

        progressBar.value = progress;
    }
}
