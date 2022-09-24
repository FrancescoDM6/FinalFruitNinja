using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
        public static MainManager Instance;

        public int score;
        public int hiscore;

        private void Awake(){
            

            if (Instance != null){
                
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            
        }

        // private void change(){
        //     MainMenu scorechange = FindObjectOfType<MainMenu>();
        //     scorechange.HighScore(score);
        // }

        private void Update(){
            if (score > hiscore){
                    hiscore = score;
            }
        }


}
