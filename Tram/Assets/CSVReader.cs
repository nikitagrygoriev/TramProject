using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 
using System; 


public class General : MonoBehaviour
    {
        void Start (){ 

  } 

  void Update (){ }
        public List<string> loadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> searchList = new List<string>();
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
            }
            return searchList;
        }
        public void Main(string[] args){
            List<string> tst = new List<string>();
            tst = loadCsvFile("Assets/final/1nie.csv");
            Console.WriteLine(String.Join("; ", tst));
        }
    }
