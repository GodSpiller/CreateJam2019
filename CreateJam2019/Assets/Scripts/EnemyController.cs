using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    private List<EnemyBehaviourScript> _enemies = new List<EnemyBehaviourScript>();

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _enemies.Add(transform.GetChild(i).GetComponent<EnemyBehaviourScript>());
    }

    void Update()
    {
        
    }

    public void CheckWinState()
    {
        if (_enemies.All(e => !e.IsAlive))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
