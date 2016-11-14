using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

    public int bossHP, nextPhase, enemies, droppedMeteors;
    public bool goToNextPhase, countPhaseCriteara, check, meteorShower, hasShield, phase1, phase3, moveToFight, moveToHide;
    public BossShootingScript shootScript;
    public CrumbleDownStoneScript crumbeScript;
    public LootScript lootScript;
    public Transform playerPos;

    public Transform targetFight;
    public Transform targetHide;
    public float speed;

    private Transform p_Transform;

    public GameObject BossFireBox;
    public GameObject normalEnemyObj;
    public GameObject shieldEnemyObj;
    public GameObject ShieldRotationFieldObj;

    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public GameObject spawnpoint3;
    public GameObject spawnpoint4;
    public GameObject spawnpoint5;
    public GameObject spawnpoint6;
    public GameObject spawnpoint7;
    public GameObject spawnpoint8;

    public GameObject redExplosion;
    public GameObject yellowExplosion;

    public GameObject hideSpot;
    public GameObject fightSpot;
    

    // Use this for initialization
    void Start () {
        crumbeScript = gameObject.GetComponent<CrumbleDownStoneScript>();
        lootScript = GameObject.Find("Treasure_Chest_Gold").GetComponent<LootScript>();
        droppedMeteors = 0;
        enemies = 0;

        //animate boss going down and immume
        moveToHide = true;
        //iTween.MoveTo(gameObject, iTween.Hash("amount", new Vector3 (hideSpot.transform.position.x, hideSpot.transform.position.y, hideSpot.transform.position.z), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
        //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

        hasShield = false;
        goToNextPhase = false;
        shootScript = gameObject.GetComponentInChildren<BossShootingScript>();
        countPhaseCriteara = false;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        nextPhase = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (moveToFight)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetFight.position, step);
            if (transform.position == targetFight.position)
            {
                moveToFight = false;
            }

        }

        if (moveToHide)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetHide.position, step);
            if (transform.position == targetHide.position)
            {
                moveToHide = false;
            }
        }

        if (goToNextPhase)
        {
            nextPhase++;
            BossPhase(nextPhase);
            goToNextPhase = false;
        }

        //Check 1ste phase NO SHIELD
        if (bossHP <= 40 && phase1)
        {
            goToNextPhase = true;
            phase1 = false;
        }

        //Check 2nd phase NORMAL ENEMIES
        if (countPhaseCriteara && enemies == 0)
        {
            goToNextPhase = true;
            countPhaseCriteara = false;

        }

        //Check 3nd phase SHIELD ON BOSS
        if (bossHP <= 20 && phase3)
        {
            goToNextPhase = true;
            phase3 = false;
            //check = false;
        }

        //Check 4nd phase //SKIPPED FASE DUE TO DEADLINE
        if (meteorShower)
        {
            Debug.Log("Reading phase 4 status");
            if (enemies == 0)
            {
                Debug.Log("Reading inside this shit");
                goToNextPhase = true;
                check = false;
                meteorShower = false;
            }

            //if (droppedMeteors == 10)
            //{
            //    goToNextPhase = true;
            //    droppedMeteors = 0;
            //    meteorShower = false;
            //}
        }

        //Check 5nd phase
        if (bossHP <= 0)
        {
            //Instantiete chest
            lootScript.showChest = true;
            //Destroy boss
            Destroy(gameObject);
        }



        //When player is in range - start shooting
        //always look at player
        transform.LookAt(playerPos);


    }

    public void BossPhase(int phaseNumber)
    {
        if (phaseNumber == 1)
        {
            //give HP to boss
            moveToFight = true;
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, +15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

            //animate boss showing up

            //start shooting at player
            shootScript.mayShoot = true;
            phase1 = true;
        }

        if (phaseNumber == 2)
        {
            //give HP to boss 40 hp
            bossHP = 40;
            //animate boss going down and immume
            moveToHide = true;
            //iTween.MoveTo(gameObject, iTween.Hash("amount", GameObject.Find("BossPosition").transform.position, "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            //stop shooting at player
            shootScript.mayShoot = false;
            //monitor phase 2 - if all dead minions..than next phase
            enemies = 4;
            countPhaseCriteara = true;

            var NormalEnemy = Instantiate(normalEnemyObj, spawnpoint1.transform.position + new Vector3(0, 1.5f,0), spawnpoint1.transform.rotation) as GameObject;
            NormalEnemy.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            NormalEnemy.name = "NormalEnemy";

            var NormalEnemy2 = Instantiate(normalEnemyObj, spawnpoint2.transform.position + new Vector3(0, 1.5f, 0), spawnpoint2.transform.rotation) as GameObject;
            NormalEnemy2.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            NormalEnemy2.name = "NormalEnemy";

            var NormalEnemy3 = Instantiate(normalEnemyObj, spawnpoint3.transform.position + new Vector3(0, 1.5f, 0), spawnpoint3.transform.rotation) as GameObject;
            NormalEnemy3.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            NormalEnemy3.name = "NormalEnemy";

            var NormalEnemy4 = Instantiate(normalEnemyObj, spawnpoint4.transform.position + new Vector3(0, 1.5f, 0), spawnpoint4.transform.rotation) as GameObject;
            NormalEnemy4.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            NormalEnemy4.name = "NormalEnemy";

        }

        if (phaseNumber == 3)
        {
            //give 40 HP to boss
            bossHP = 40;
            //give boss shield with shield HP
            var ShieldRotationField = Instantiate(ShieldRotationFieldObj, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            ShieldRotationField.transform.parent = gameObject.transform;
            ShieldRotationField.name = "ShieldRotationField";

            //Set FireBox beyond shield field
            iTween.MoveAdd(BossFireBox, iTween.Hash("amount", new Vector3(0, 0, +2f), "time", 0.1f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

            //animate boss showing up
            moveToFight = true;
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, +15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            //start shooting at player
            shootScript.mayShoot = true;
            phase3 = true;
        }

        if (phaseNumber == 4)
        {
            //Set FireBox back
            iTween.MoveAdd(BossFireBox, iTween.Hash("amount", new Vector3(0, 0, -2f), "time", 0.1f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));

            //give 20 HP to boss
            bossHP = 20;
            //animate boss going down
            moveToHide = true;
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, -15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            //nextPhase++;

            //stop shooting at player
            shootScript.mayShoot = false;
            //When all stones are done start kill phase
            //Whean boss is 20 hp he will go down and starts Phase 2
            enemies = 4;
            var ShieldEnemy = Instantiate(shieldEnemyObj, spawnpoint5.transform.position + new Vector3(0, 1.5f, 0), spawnpoint5.transform.rotation) as GameObject;
            ShieldEnemy.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            ShieldEnemy.name = "NormalShieldEnemy";

            var ShieldEnemy2 = Instantiate(shieldEnemyObj, spawnpoint6.transform.position + new Vector3(0, 1.5f, 0), spawnpoint6.transform.rotation) as GameObject;
            ShieldEnemy2.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            ShieldEnemy2.name = "NormalShieldEnemy";

            var ShieldEnemy3 = Instantiate(shieldEnemyObj, spawnpoint7.transform.position + new Vector3(0, 1.5f, 0), spawnpoint7.transform.rotation) as GameObject;
            ShieldEnemy3.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            ShieldEnemy3.name = "NormalShieldEnemy";

            var ShieldEnemy4 = Instantiate(shieldEnemyObj, spawnpoint8.transform.position + new Vector3(0, 1.5f, 0), spawnpoint8.transform.rotation) as GameObject;
            ShieldEnemy4.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            ShieldEnemy4.name = "NormalShieldEnemy";

            check = true;
            meteorShower = true;
        }

        if (phaseNumber == 5)
        {
            //give 20 HP to boss
             bossHP = 20;
            moveToFight = true;
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, +15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
            //Boss is slow in firerate
            shootScript.fireRate = 150;
            //animate boss going up
            //iTween.MoveAdd(gameObject, iTween.Hash("amount", new Vector3(0, +15f, 0), "time", 1.5f, "easytype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 1.6f));
            //start shooting at player
            shootScript.mayShoot = true;

            //Show Treasure

        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            //BOSS collision with no shield
            if (col.gameObject.name == "fireProjectile(Clone)" && !hasShield)
            {
                iTween.PunchScale(GameObject.Find("Boss"), iTween.Hash("amount", new Vector3(0.05f, 0.20f, 0.05f), "time", 1f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none));
                bossHP--;
                // Crumble stone
                crumbeScript.CreateCrumble();

                Instantiate(redExplosion, transform.position, transform.rotation);
                Destroy(col.gameObject);
            }


            if (col.gameObject.name == "explosiveProjectile(Clone)" && !hasShield)
            {
                Instantiate(yellowExplosion, transform.position, transform.rotation);
                Destroy(col.gameObject);
            }

        }
    }
}
