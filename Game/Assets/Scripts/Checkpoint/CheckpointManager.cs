using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{

    [Header("Prefabs")]
    [SerializeField] GameObject playerPrefab;

    [Header("Transforms")]
    [Tooltip("Uses this transform if left null")]
    [SerializeField] Transform originalSpawn;



    Vector3 defaultSpawnPositon { get => originalSpawn != null ? originalSpawn.position : transform.position; }


    static CheckpointManager instance;
    public static CheckpointManager Instance { get => instance; }

    public static string CheckpointPlayerPrefKey = "checkpoint";
    public static string CheckpointPlayerPrefDefault = "undefined";

    private static string getPrefKey(string sceneName)
    {
        return CheckpointPlayerPrefKey +"_"+ sceneName;
    }
    private static void clearSave(string sceneName)
    {
        string key = getPrefKey(sceneName);
        PlayerPrefs.DeleteKey(key);

    }

    public static void clearSaves(IEnumerable<string> sceneNames)
    {
        foreach (var item in sceneNames)
        {
            clearSave(item);
        }
    }


    private static string getCurrentPrefKey()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        return CheckpointPlayerPrefKey + "_" + activeScene.name;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            this.gameObject.SetActive(false);
            Debug.LogWarning($"Multiple instances of {nameof(CheckpointManager)}");
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        SpawnPlayer();
    }


    public void SetCheckpoint(Checkpoint checkpoint)
    {
        var checkpoints = FindObjectsOfType<Checkpoint>();


        foreach (var item in checkpoints.Where(c=>c!= checkpoint))
        {
            item.DeselectCheckpoint();
        }
        checkpoint.SelectCheckpoint();
        saveCheckpoint(checkpoint);

    }

    private void saveCheckpoint(Checkpoint checkpoint)
    {
        PlayerPrefs.SetString(CheckpointManager.getCurrentPrefKey(), checkpoint.Identifier);
    }

    private Checkpoint getSavedCheckpoint()
    {

        string identifier = PlayerPrefs.GetString(CheckpointManager.getCurrentPrefKey(), CheckpointManager.CheckpointPlayerPrefDefault);
        var checkpoints = FindObjectsOfType<Checkpoint>();

        Checkpoint check =  checkpoints.Where(c => c.Identifier == identifier).FirstOrDefault();
        return check;
    }



    private GameObject SpawnPlayer()
    {
        
        if (playerPrefab == null)
        {
            Debug.LogWarning("Failed to spawn player no preafab");
            return null;
        }


        var checkpoint = getSavedCheckpoint();
        Vector3 spawnPosition= checkpoint == null? defaultSpawnPositon: checkpoint.SpawnPositon;

        return Instantiate(playerPrefab, spawnPosition, Quaternion.identity);


    }



}
