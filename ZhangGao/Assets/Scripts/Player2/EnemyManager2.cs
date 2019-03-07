using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{

    [SerializeField] GameObject squid;
    [SerializeField] GameObject crab;
    [SerializeField] GameObject octopus;
    [SerializeField] float Shootinginterval;

    [SerializeField] float spatialInterval = 1f; //for interval between each enemy in a row
    [SerializeField] float timeInterval = 0.2f; // for interval between moves (coroutine)

    int step = 10; //move steps for one row
    int rows = 4; //flag for moving down
    int rows2 = 4;
    float direct = 0.2f; //how far for each move

    List<Enemy> enemies1; // save enemies into a list
    List<Enemy> enemies2; // save enemies into a list
    List<Enemy> enemies3; // save enemies into a list
    List<Enemy> enemies4; // save enemies into a list
    List<Enemy> enemies5; // save enemies into a list
    List<List<Enemy>> enemies;
    List<Enemy> shootingEnemies;

    Coroutine movingHorizontally;
    Coroutine goingDown;

    float timer;
    float shootTimer;
    bool speedUp = true;

    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        step = 10;
        direct = 0.2f;
        timeInterval = 0.2f;
        audioManager2.musicPlayInterval2 = 0.85f;
        SpriteAnimi.moveInterval = 1f;
        enemies1 = new List<Enemy>(); // save enemies into a list
        enemies2 = new List<Enemy>(); // save enemies into a list
        enemies3 = new List<Enemy>(); // save enemies into a list
        enemies4 = new List<Enemy>(); // save enemies into a list
        enemies5 = new List<Enemy>(); // save enemies into a list
        enemies = new List<List<Enemy>>();
        shootingEnemies = new List<Enemy>();

        // instiate five rows of enemies (can simplify later by putting prefabs into a list)
        for (int i = 0; i < 11; i++)
        {
            GameObject newEnemy = Instantiate(squid, transform.position + new Vector3(i * spatialInterval, 0f, 0f),
                                              Quaternion.identity) as GameObject;
            newEnemy.transform.parent = gameObject.transform;
            enemies1.Add(newEnemy.GetComponent<Enemy>());
        }
        enemies.Add(enemies1);
        for (int i = 0; i < 11; i++)
        {
            GameObject newEnemy = Instantiate(crab, transform.position + new Vector3(i * spatialInterval, -0.7f, 0f),
                                              Quaternion.identity) as GameObject;
            newEnemy.transform.parent = gameObject.transform;
            enemies2.Add(newEnemy.GetComponent<Enemy>());
        }
        enemies.Add(enemies2);
        for (int i = 0; i < 11; i++)
        {
            GameObject newEnemy = Instantiate(crab, transform.position + new Vector3(i * spatialInterval, -1.4f, 0f),
                                              Quaternion.identity) as GameObject;
            newEnemy.transform.parent = gameObject.transform;
            enemies3.Add(newEnemy.GetComponent<Enemy>());
        }
        enemies.Add(enemies3);
        for (int i = 0; i < 11; i++)
        {
            GameObject newEnemy = Instantiate(octopus, transform.position + new Vector3(i * spatialInterval, -2.1f, 0f),
                                              Quaternion.identity) as GameObject;
            newEnemy.transform.parent = gameObject.transform;
            enemies4.Add(newEnemy.GetComponent<Enemy>());
        }
        enemies.Add(enemies4);
        for (int i = 0; i < 11; i++)
        {
            GameObject newEnemy = Instantiate(octopus, transform.position + new Vector3(i * spatialInterval, -2.8f, 0f),
                                              Quaternion.identity) as GameObject;
            newEnemy.transform.parent = gameObject.transform;
            enemies5.Add(newEnemy.GetComponent<Enemy>());
            shootingEnemies.Add(newEnemy.GetComponent<Enemy>());
        }
        enemies.Add(enemies5);
    }

    void Update()
    {
        if (step!=0){
            movingHorizontally = StartCoroutine(Move());
        }
        if (step==0){
            StopCoroutine(movingHorizontally);
        }
        if (step==0 && rows2!=-1){
            goingDown = StartCoroutine(GoDown());
        }
        if (rows2 == -1){
            StopCoroutine(goingDown);
            direct = -direct;
            step = 10;
            rows2 = 4;
        }
        ShootingDown();

    }
    private void FixedUpdate()
    {
        if (PlayerProjectile2.deadEnemyNumber2 %11==0 && PlayerProjectile2.deadEnemyNumber2 != 0 && speedUp == true)
        {
            timeInterval -= 0.04f;
            audioManager2.musicPlayInterval2 -= 0.15f;
            SpriteAnimi.moveInterval -= 0.20f;
            speedUp = false;
        }
        if(PlayerProjectile2.deadEnemyNumber2 % 12 == 0)
        {
            speedUp = true;
        }

    }

    IEnumerator Move()
    {

        if(Time.time - timer >timeInterval){
            for (int i = 0; i < 11;i++){
                enemies[rows][i].EnemyMove(direct);
            }
            rows--;
            timer = Time.time;
            if (rows == -1)
            {
                rows = 4;
                step--;
            }
        }
        yield return new WaitForSeconds(timeInterval);
    }

    IEnumerator GoDown()
    {
        if (Time.time - timer > timeInterval)
        {
            for (int i = 0; i < 11; i++)
            {
                enemies[rows2][i].MoveDown();
            }
            rows2--;
            timer = Time.time;
        }
        yield return new WaitForSeconds(timeInterval);
    }

    void ShootingDown()
    {
        if (Time.time-shootTimer>Shootinginterval )
        {
            int shootIndex = Random.Range(0, 11);
            int shootingRow = 4;
            while(enemies[shootingRow][shootIndex].enemyDie == true){
                shootingRow--;
                if(shootingRow==-1){
                    break;
                }
            }
            if (shootingRow!=-1){
                enemies[shootingRow][shootIndex].EnemyFire();
            }
            shootTimer = Time.time;
        }

    }
}
