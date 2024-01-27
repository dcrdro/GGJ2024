
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text title;
    public Text count;
    public Image icon;

    public ResourceType Type { get; set; }

    public void SetTitle(string name) => title.text = name;
    public void SetCount(int n)
    {
        count.text = $"x{n}";
        var c = icon.color;
        c.a = n == 0 ? 0.25f : 1; ;
        icon.color = c;
    }

    public void SetIcon(Sprite i) => icon.sprite = i;
}
