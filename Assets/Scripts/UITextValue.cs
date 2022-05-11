using TMPro;
using UnityEngine;

public class UITextValue : MonoBehaviour
{
    [SerializeField]
    private Value value;

    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(value.value.ToString());
    }
}
