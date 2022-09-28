using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class LevelCompleteManager : IDisposable

{
    /*private Vector3 _startPosition;
    private LevelObjectView _characterView;
    private List<LevelObjectView> _deathZones;
    private List<LevelObjectView> _winZones;
    public LevelCompleteManager(LevelObjectView characterView,
    List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
    {
       // _startPosition = characterView.Transform.position;
        characterView.OnLevelObjectContact += OnLevelObjectContact;
        _characterView = characterView;
        _deathZones = deathZones;
        _winZones = winZones;
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_deathZones.Contains(contactView))
        {
           // _characterView.Transform.position = _startPosition;
        }
    }
    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }*/
    private List<LevelObjectView> _levelObjectViews;

    public LevelCompleteManager(List<LevelObjectView> levelObjectViews)
    {
       _levelObjectViews = levelObjectViews;

        foreach (var levelObjectView in _levelObjectViews)
        {
            levelObjectView.OnLevelObjectContact += OnLevelObjectContact;
        }
    }
    private void OnLevelObjectContact(LevelObjectView contactView)
    {
        if (_levelObjectViews.Contains(contactView))
            Object.Destroy(contactView.gameObject);
    }
    public void Dispose()
    {
        foreach (var levelObjectView in _levelObjectViews)
            levelObjectView.OnLevelObjectContact -= OnLevelObjectContact;
    }
}

