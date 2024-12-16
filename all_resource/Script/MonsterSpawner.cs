using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _monsterReference;
    private GameObject _spawnMonster;

    [SerializeField] private Transform _leftPos, _rightPos;
    private int _randomIndex;
    private int _randomSide;

    private void Start()
    {
        StartCoroutine(SpawnMonster());

    }



    private IEnumerator SpawnMonster()
    {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            _randomIndex = Random.Range(0, _monsterReference.Length);
            _randomSide = Random.Range(0, 2);

            _spawnMonster = Instantiate(_monsterReference[_randomIndex]);

            if (_randomSide == 0)
            {
                _spawnMonster.transform.position = _leftPos.position;
                _spawnMonster.GetComponent<Monster>()._speed = Random.Range(4, 10);
            }
            else
            {
                _spawnMonster.transform.position = _rightPos.position;
                _spawnMonster.GetComponent<Monster>()._speed = -Random.Range(4, 10);
                _spawnMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
