﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class JGameManager
{
    #region Properties
	internal int currentLevelID = 1;
	internal int deathNb = 0;

    private List<string> _gameModeList = null;
    private JGameMode _currentGameMode = null;
    #endregion

    #region Class Methods
    internal JGameManager()
    {
        _gameModeList = new List<string>();
    }

    internal void Manage()
    {
        if(_currentGameMode != null)
            _currentGameMode.Manage();
    }

    ~JGameManager()
    {
        _gameModeList.Clear();
        _gameModeList = null;
    }
    #endregion

    #region Methods
    internal JGameMode GetCurrentGameMode
    {
        get
        {
            return _currentGameMode;
        }
    }

    internal void registerGameMode(JGameMode a_gameMode)
    {
        _currentGameMode = a_gameMode;
        _currentGameMode.Enter();
    }

    internal void changeGameMode(string a_gameModeName)
    {
        if(_currentGameMode != null)
            _currentGameMode.Exit();
        Application.LoadLevel(a_gameModeName);
    }
    #endregion
}
