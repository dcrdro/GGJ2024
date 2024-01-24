using UnityEngine;

namespace EnemyLogic.UI
{
  public class EnemyInterface : MonoBehaviour
  {
    [SerializeField]
    private ActionProgressBar _actionProgressBar;

    #region Properties

    public ActionProgressBar ActionProgressBar => _actionProgressBar;

    #endregion
  }
}