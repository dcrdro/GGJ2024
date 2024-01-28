using UnityEngine;

namespace EnemyLogic.UI
{
  public class EnemyInterface : MonoBehaviour
  {
    [SerializeField]
    private ActionProgressBar _actionProgressBar;

    [SerializeField]
    private ActionProgressBar _healthProgressBar;
    
    #region Properties

    public ActionProgressBar ActionProgressBar => _actionProgressBar;
    public ActionProgressBar HealthProgressBar => _healthProgressBar;

    #endregion
  }
}