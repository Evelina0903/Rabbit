using UnityEngine;
using TMPro;

public class UIBanner : MonoBehaviour
{
    private float lifeTime = 2.0f;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        lifeTime -= 1 * Time.deltaTime;
        if (lifeTime <= 0)
        {
            Color col = text.color;
            col.a -= (float)(0.5 * Time.deltaTime);
            text.color = col;
        }
        if (lifeTime < -3)
            Destroy(this.gameObject);
    }
}
