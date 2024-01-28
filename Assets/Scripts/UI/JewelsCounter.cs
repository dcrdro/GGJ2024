using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class JewelsCounter : MonoBehaviour
  {
    public static JewelsCounter Instance;
    
    [SerializeField]
    private Text _counter;

    #region Fields

    private float _currentJewelsCount;
    private float _maxJewelsCount;

    #endregion
    
    private void Awake() => 
      Instance = this;

    public void Initialize()
    {
      _maxJewelsCount = JewelsContainer.Instance.Length;
      _currentJewelsCount = _maxJewelsCount;
      UpdateText();
    }

    public void DecreaseJewelsCount()
    {
      _currentJewelsCount -= 1;
      UpdateText();
    }
    
    public void UpdateText() => 
      _counter.text = $"{_currentJewelsCount}/{_maxJewelsCount}";
  }
}