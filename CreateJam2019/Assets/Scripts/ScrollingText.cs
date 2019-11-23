using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _moveSpeed;

    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        if (_endPosition.position.y - transform.position.y < 40)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        _text.transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
    }
}
