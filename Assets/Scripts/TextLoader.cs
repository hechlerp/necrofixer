﻿/* Text Loader
 * load text in for Dialog
 * 
 * Scott Tongue
 * 2020
 */


using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace Dialog {

    public static class TextLoader 
    {
        private const string _textPath = "TextData/TextScript";
        private static Dictionary<int, string> _dialogDictionary;


       

        #region public

        /// <summary>
        /// Load in dialog text,  
        /// </summary>
        public  static void LoadDialog()
        {
            if (_dialogDictionary == null)
                _dialogDictionary = new Dictionary<int, string>();
            else
                _dialogDictionary.Clear();
            LoadData();
            System.GC.Collect();
        }

        /// <summary>
        /// Get Dialog text 
        /// </summary>
        /// <param name="ID">ID of dialog </param>
        /// <returns>returns dialog or error message if missing</returns>
        public static string GetDialog(int ID)
        {
            if(_dialogDictionary == null)
                Debug.LogError("ERORR: DATA hasn't been loaded");
       

            if (_dialogDictionary.ContainsKey(ID))
                return _dialogDictionary[ID];
      
            else
            {
                Debug.LogWarning(ID + " ID field doesn't exist");
                return "Missing Text Data in ID " + ID;
            }
        }

        #endregion

        #region private 


        /// <summary>
        /// load in data from cvs file and formats it for our Dictionary
        /// </summary>
        private static void LoadData()
        {
            TextAsset ScriptData = Resources.Load<TextAsset>(_textPath);
            string[] textData = ScriptData.text.Split( '\n' );

            int id = 0;
            string text;
            char[] splitChar = new char[1] { ',' };

            for(int i = 1; textData.Length > i; i++)
            {
               
                string[] dialog = textData[i].Split(splitChar, 2, System.StringSplitOptions.None);

                //skip if there is no id
                if (!dialog[0].Equals(""))
                {
                    //check to see if there dialog 
                    if (dialog.Length == 0)
                    {
                        if (dialog[1].Equals(""))
                            Debug.LogWarning(id + "is missing dialog please fill out ");
                    }
                    else
                    {

                        int.TryParse(dialog[0], out id);
                        text = dialog[1];

                        if (!_dialogDictionary.ContainsKey(id))
                            _dialogDictionary.Add(id, text);
                        else
                            Debug.LogWarning(id + "id already exist please check id number ");
                    }
                }
            }
        }
        #endregion
    }
}