using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public static bool canSpawn = true;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private GameObject[] _obstaclePrefab;
    [SerializeField] private float _obstacleProbability;
    [SerializeField] private GameObject _investorTrust;
    [SerializeField] private float _trustProbability;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _spawnRate = 2.0f;
    [SerializeField] private float _spawnRateMax = 3.0f;
    [SerializeField] private float _spawnRateMin = 1.0f;
    private float _timer = 0.0f;
    private int _coinMax = 8;
    private int _coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canSpawn) return;

        _timer += Time.deltaTime;
        if(_timer >= _spawnRate)
        {
            float rand = Random.Range(0, _obstacleProbability + _trustProbability);
            Vector2 position = CalculateSpawnPosition();
            
            if (position != Vector2.zero && rand < _obstacleProbability || _coinCount >= _coinMax)
            {
                Instantiate(_obstaclePrefab[Random.Range(0, _obstaclePrefab.Length)], position + Vector2.left * Random.Range(3f,4.5f), Quaternion.identity);
                _spawnRate = Random.Range(_spawnRateMax, _spawnRateMin);
                _coinCount = 0;
            }
            else if (position != Vector2.zero && rand < _obstacleProbability + _trustProbability)
            {
                _coinCount++;
                Instantiate(_investorTrust, new Vector3(position.x, position.y, 0.1f), Quaternion.identity);
                _spawnRate = Random.Range(_spawnRateMax/4, _spawnRateMin/4);
            }
            
            _timer = 0.0f;
        }
    }

    Vector2 CalculateSpawnPosition()
    {
        Vector2 playerPosition = _pointer.transform.position;
        Vector2 playerDirection;
        if(_pointer._currentAngle > 0)
            playerDirection = Quaternion.Euler(0, 0, -5) * _pointer._direction;
        else 
            return Vector2.zero; //playerDirection = Quaternion.Euler(0, 0, -_pointer._currentAngle) * Vector2.right;
        Vector2 spawnPosition = playerPosition + playerDirection * _pointer._speed * 3f;
        return spawnPosition;
    }
}
