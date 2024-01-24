using UnityEngine;
using UnityEngine.UI;

namespace EnemyLogic.UI
{
  public class ActionProgressBar : MonoBehaviour
  {
    [SerializeField]
    private Image _indicator;

    public void Toggle(bool state) => 
      gameObject.SetActive(state);

    public void SetValue(float value)
    {
      value = Mathf.Clamp01(value);
      _indicator.fillAmount = value;
    }
  }
}