using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
/*
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
*/

public class upgradeManager : MonoBehaviour {

    static upgradeManager instance;

    public int maxBoosts; // 1
    public float groundSpeedReduction; // 4
    public float launchForce; // 18
    public float enemySpeedReduction; // 1.2
    public float truckFrequency; // .025
    public float bombEnemyFrequency; // .06

    public int maxBoostsIndex = 0;
    public int groundSpeedReductionIndex = 0;
    public int launchForceIndex = 0;
    public int enemySpeedReductionIndex = 0;
    public int truckFrequencyIndex = 0;
    public int bombEnemyFrequencyIndex = 0;
    public float highScore;
    public int playerScore;

    public Image birdImg;

    void Awake () {

        if (instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
            loadData();
            // pull all info from backend
        }
    }
	
	void Update () {
		
	}

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/upgradeManager.dat", FileMode.OpenOrCreate);
        UpgradeData upgrade = new UpgradeData();
        upgrade.maxBoosts = this.maxBoosts;
        upgrade.groundSpeedReduction = this.groundSpeedReduction;
        upgrade.launchForce = this.launchForce;
        upgrade.enemySpeedReduction = this.enemySpeedReduction;
        upgrade.truckFrequency = this.truckFrequency;
        upgrade.bombEnemyFrequency = this.bombEnemyFrequency;
        upgrade.maxBoostsIndex = this.maxBoostsIndex;
        upgrade.groundSpeedReductionIndex = this.groundSpeedReductionIndex;
        upgrade.launchForceIndex = this.launchForceIndex;
        upgrade.enemySpeedReductionIndex = this.enemySpeedReductionIndex;
        upgrade.truckFrequencyIndex = this.truckFrequencyIndex;
        upgrade.bombEnemyFrequencyIndex = this.bombEnemyFrequencyIndex;
        upgrade.highScore = this.highScore;
        upgrade.playerScore = this.playerScore;
        bf.Serialize(fs, upgrade);
        fs.Close();
    }

    public void loadData()
    {
        if (File.Exists(Application.persistentDataPath + "/upgradeManager.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/upgradeManager.dat", FileMode.Open);
            UpgradeData upgrade = (UpgradeData) bf.Deserialize(fs);
            this.maxBoosts = upgrade.maxBoosts;
            this.groundSpeedReduction = upgrade.groundSpeedReduction;
            this.launchForce = upgrade.launchForce;
            this.enemySpeedReduction = upgrade.enemySpeedReduction;
            this.truckFrequency = upgrade.truckFrequency;
            this.bombEnemyFrequency = upgrade.bombEnemyFrequency;
            this.maxBoostsIndex = upgrade.maxBoostsIndex;
            this.groundSpeedReductionIndex = upgrade.groundSpeedReductionIndex;
            this.launchForceIndex = upgrade.launchForceIndex;
            this.enemySpeedReductionIndex = upgrade.enemySpeedReductionIndex;
            this.truckFrequencyIndex = upgrade.truckFrequencyIndex;
            this.bombEnemyFrequencyIndex = upgrade.bombEnemyFrequencyIndex;
            this.highScore = upgrade.highScore;
            this.playerScore = upgrade.playerScore;
            fs.Close();
        }
    }

    public int getPlayerScore()
    {
        return this.playerScore;
    }

    public void setPlayerScore(int newScore)
    {
        playerScore = newScore;
    }
}

[Serializable]
class UpgradeData
{
    public int maxBoosts; 
    public float groundSpeedReduction; 
    public float launchForce; 
    public float enemySpeedReduction; 
    public float truckFrequency; 
    public float bombEnemyFrequency; 

    public int maxBoostsIndex = 0;
    public int groundSpeedReductionIndex = 0;
    public int launchForceIndex = 0;
    public int enemySpeedReductionIndex = 0;
    public int truckFrequencyIndex = 0;
    public int bombEnemyFrequencyIndex = 0;
    public float highScore;
    public int playerScore;
}
