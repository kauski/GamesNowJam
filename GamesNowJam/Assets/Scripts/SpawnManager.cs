//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnManager : MonoBehaviour
//{
//    private GameObject[] spawnPosChild;
//    private List<GameObject> objectPoolChild = new List<GameObject>();
//    public GameObject[] childPrefab;
   

//    private List<GameObject> objectPoolGuardian = new List<GameObject>();
//    public GameObject[] guardianPrefab;
//    private GameObject[] spawnPosGuardian;


    
//    // Start is called before the first frame update
//    void Start()
//    {
//        spawnPosChild = GameObject.FindGameObjectsWithTag("SpawnPositionChild");
//        spawnPosGuardian = GameObject.FindGameObjectsWithTag("SpawnPositionGuardian");
//        CreateObjects(childPrefab, spawnPosChild, objectPoolChild);
//        CreateObjects(guardianPrefab, spawnPosGuardian, objectPoolGuardian);
//        Spawn(childPrefab, spawnPosChild[1], objectPoolChild);
//    }

    
//    void CreateObjects(GameObject[] prefab, GameObject[] position, List<GameObject> pool)
//    {
//        for (int i = 0; i < position.Length; i++)
//        {
           

//            Quaternion rot = position[i].transform.rotation;
//           Vector3 pos = position[i].transform.position;
//            int rand = Random.Range(0, prefab.Length);
         
//            GameObject createObject = Instantiate(prefab[rand], pos, rot);

            
//            createObject.SetActive(false);
//            pool.Add(createObject);

//        }


//    }
//   public void Spawn(GameObject[] prefab, GameObject[] position, List<GameObject> list)
//    {
//        GameObject reuseObject = GetInactiveObject(list, prefab);
//        if (reuseObject != null)
//        {
//            int rand = Random.Range(0, position.Length);
//            reuseObject.transform.SetPositionAndRotation(position[rand].transform.position, position[rand].transform.rotation);
//            reuseObject.SetActive(true);
//            ActivateChildren(reuseObject);
//        }
//    }
//    void ActivateChildren(GameObject parent)
//    {
//        foreach (Transform child in parent.transform)
//        {
//            child.gameObject.SetActive(true);
//        }
//    }
//    GameObject GetInactiveObject(List<GameObject> list, GameObject[] prefab)
//    {
//        //returns random inactive object, if not any available, adds 1 to the list.
//        int rand = Random.Range(0, list.Count);

//        for (int i = 0; i < list.Count; i++)
//        {
//            int index = (rand + i) % list.Count;
//            if (!list[index].activeInHierarchy)
//            {
//                return list[index];
//            }
//        }

//        int random = Random.Range(0, prefab.Length);
//        GameObject newGameObject = Instantiate(prefab[random], Vector3.zero, Quaternion.identity);
//        newGameObject.SetActive(false);
//        list.Add(newGameObject);

//        return newGameObject;
//    }
//}
