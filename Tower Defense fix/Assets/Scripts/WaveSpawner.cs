using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public Text waveCountdownText;
    public Text waveCountdownTextWin;
    public Text waveCountdownTextOver;

    public int waveIndex = 0;
    private int totalEnemies = 100;
    public int counter=0;
    public GameObject panelWIN;
    void Update()
    {
        /*if (EnemiesAlive > 0)
		{
			return;
		}*/
        if (waveIndex >= 9)
        {
            panelWIN.SetActive(true);
            waveCountdownTextWin.text = "" + 9;
            Time.timeScale = 0;
        }

        if (countdown <= 0f)
        {
            if (!GameManager.GameIsOver)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
        }

        if (GameManager.GameIsOver)
        {
            waveCountdownTextOver.text = "" + waveIndex;
            countdown = 0;
        }
        else
		    countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
        
        PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}


		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, enemy.transform.rotation);

	}

}
