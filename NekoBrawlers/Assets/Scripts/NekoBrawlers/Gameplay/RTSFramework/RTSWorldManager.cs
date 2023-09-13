using Core.Pattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTSFramework.WorldManagment
{
    public class RTSWorldManager : Singleton<RTSWorldManager>
    {
        public GameObject WordOrigin;

        public RTSObjectSpawner RTSObjectSpawner;
    }
}

