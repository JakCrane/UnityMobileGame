// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlanetPhysics : MonoBehaviour
// {
//     [SerializeField] int timeToDelete = 4;

//     void Start() 
//     {

//     }
    
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.Space)) { //if rocket disconnects from planet (probably not if space is pressed)
//             spawn new planet at planet_spawn_point 
//             minus 1 to all ttd values for all planets
//         }
//     }

    // public Vector3 CreatePlanetSpawnPoint() 
    // {
    //     if (total ttd >= 4) return; //cant have more than 5 planets (including ttd:0 that is vanishing)
    //     new_position = find planet object with lowest ttd and position relative to that using metric rand(between left and right barrier of view width with padding);
    //     return new_position;
    // } 
    // public void focus_planet() {
        // return [position_player, position_camera] //returns 2 values first for rocket to orbit second for camera to view
    


    // }
    // public void planet {
    //     init time_to_del = 4;
    //     initial position = planet_spawn_point();
    //     if (time_to_del == 0) {delete};
    //     if (time_to_del == 2) {focus_planet()}
    // }
    
//}
