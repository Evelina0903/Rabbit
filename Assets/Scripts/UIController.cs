using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject[] heartsUI;
    [SerializeField] UIBanner gameOverBanner;
    [SerializeField] UIBanner[] effectsBanners;
    [SerializeField] TextMeshProUGUI countText;

    private void Start() 
    {
        EventController.OnPlayerHealthChange.AddListener(UpdateHearts);
        EventController.OnPlayerDie.AddListener(SpawnGameOverBanner);
        
        EventController.OnHealEffectApplied.AddListener(SpawnHealEffectBanner);
        EventController.OnSpeedEffectApplied.AddListener(SpawnSpeedEffectBanner);
        EventController.OnSlowEffectApplied.AddListener(SpawnSlowEffectBanner);
        EventController.OnReverseEffectApplied.AddListener(SpawnReverseEffectBanner);
    }

    private void UpdateHearts(int health)
    {
        foreach (GameObject h in heartsUI)
            h.SetActive(false);

        for (int i = 0; i < 3 - health; i++)
            heartsUI[i].SetActive(true);
    }

    private void SpawnGameOverBanner()
    {
        Instantiate(gameOverBanner, this.transform).transform.localPosition = new Vector3(0, 0, 0);
    }

    private void SpawnHealEffectBanner()
    {
        Instantiate(effectsBanners[0], this.transform).transform.localPosition = new Vector3(0, 230, 0);
    }

    private void SpawnSpeedEffectBanner()
    {
        Instantiate(effectsBanners[1], this.transform).transform.localPosition = new Vector3(0, 230, 0);
    }

    private void SpawnSlowEffectBanner()
    {
        Instantiate(effectsBanners[2], this.transform).transform.localPosition = new Vector3(0, 230, 0);
    }

    private void SpawnReverseEffectBanner()
    {
        Instantiate(effectsBanners[3], this.transform).transform.localPosition = new Vector3(0, 230, 0);
    }

    public void UpdateCountText(int count)
    {
        string str = "Зубастый съел " + count;
        if (count % 10 == 1 && count % 100 != 11)
            str += " морковку";
        else if ((count % 10 >= 2 && count % 10 <= 4) && (count % 100 < 12 || count % 100 > 14))
            str += " морковки";
        else if (count % 10 == 0 || (count % 10 >= 5 && count % 10 <= 9) || (count % 100 >= 11 && count % 100 <= 19))
            str += " морковок";

        countText.text = str;
    }

    public void ResetUI()
    {
        foreach (GameObject h in heartsUI)
            h.SetActive(false);

        UpdateCountText(0);
    }

    public void ChangeMode()
    {
        EventController.OnGameModeChanged.Invoke();
    }
}
