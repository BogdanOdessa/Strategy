using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstractions;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;
using Zenject;

public class GameOverScreenPresenter : MonoBehaviour
{
    [Inject] private IGameStatus _gameStatus;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _view;
    [SerializeField] private GameObject[] _UIItems;

    [Inject]
    private void Init()
    { 
        _gameStatus.Status.ObserveOnMainThread().Subscribe(result =>
        {
            _text.text = result == 0 ? "Game Over.Draw!" : $"Game over. Team №{result} wins!";
            _view.SetActive(true);
            
            foreach (var go in _UIItems)
                go.SetActive(false);
            GamePauser.Pause();
        });
    }
}
