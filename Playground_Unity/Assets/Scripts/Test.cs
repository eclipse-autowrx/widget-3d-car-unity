using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    //public Dictionary<string, Func<string,GameObject>> entitiesActions;
    //public List<IToggleable> toggleEntities;
    void Start()
    {
        //Debug.Log("this is test 1");
        //entitiesActions = new Dictionary<string, Func<string, GameObject>>()
        //{
        //    {"row2_door3", name => GetComponentCarByName(name)},
        //    //{"mirror_right",name => GetComponentCarByName(name)},
        //};

        //MoveCar(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if(entitiesActions.TryGetValue(entityName,out var actions))
    //{
    //   GameObject entitys = actions.Invoke(entityName);
    //    if (bool.TryParse(action, out var result))
    //    {
    //        IToggleable toggleFunctions = entitys.GetComponent<IToggleable>();
    //        if (toggleFunctions != null)
    //        {
    //            toggleFunctions.ActiveFunction(result);
    //        }
    //    }
    //    else
    //    {
    //        IActions actionName = entitys.GetComponent<IActions>();
    //        if (actionName != null)
    //        {
    //            actionName.ActiveFunctionsByAction(action, options);
    //        }
    //    }
    //}


    //public GameObject GetComponentCarByName(string name)
    //{
    //    foreach (var item in arrComponent)
    //    {
    //        if (name == item.name)
    //        {
    //            return item;
    //        }
    //    }
    //    return null;
    //}


    //public void PerformDoorAction(Door door, string action, string options)
    //{
    //    switch (action)
    //    {
    //        case "open_door":
    //            door.OpenDoor(); // Open the door
    //            break;
    //        case "close_door":
    //            door.CloseDoor(); // Close the door
    //            break;
    //        case "lock_door":
    //            door.LockDoor(); // Lock the door
    //            break;
    //        case "unlock_door":
    //            door.UnLockDoor(); // Unlock the door
    //            break;
    //    }
    //}
}
