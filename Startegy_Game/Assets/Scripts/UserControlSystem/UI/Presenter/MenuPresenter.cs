using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UserControlSystem.UI.Presenter
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _backButton.OnClickAsObservable().Subscribe(_ =>
            {
                gameObject.SetActive(false);
                GamePauser.UnPause();
            });
            _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
        }
    }
}