using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActiveReload : MonoBehaviour
{
    private RectTransform progressTransform;
    [SerializeField] private Image reloadBar;
    [SerializeField] private Image SweetSpotBar;
    private Coroutine reloadCoroutine;

    private float maxReloadTime;
    void Start()
    {
        progressTransform = GetComponent<RectTransform>();
        maxReloadTime = progressTransform.rect.width;
        PlayerController.OnPlayerReload += HandlePlayerReload;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandlePlayerReload()
    {
        if (reloadCoroutine != null)
        {
            StopCoroutine(reloadCoroutine);
        }
        reloadCoroutine = StartCoroutine(StartReloadUI());
    }

    public IEnumerator StartReloadUI()
    {
        while (reloadBar.rectTransform.anchoredPosition.x < maxReloadTime)
        {
            reloadBar.rectTransform.anchoredPosition = new Vector2(
                reloadBar.rectTransform.anchoredPosition.x + 100 * Time.deltaTime,
                reloadBar.rectTransform.anchoredPosition.y
            );
            yield return null;
        }
        
        reloadBar.rectTransform.anchoredPosition = new Vector2(0, reloadBar.rectTransform.anchoredPosition.y);
    }
}
