using System;
using UnityEngine;


public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;
    
    private int _goodPoints;
    private int _badPoints;

    public enum FavorType
    {
        GOOD,
        BALANCED,
        BAD
    }

    public FavorType Favor;
    
    private int CheckFavor()
    {
        if (_goodPoints == _badPoints)
            return 0;
        if (_goodPoints > _badPoints)
            return _goodPoints - _badPoints;
        return -(_badPoints - _goodPoints);
    }
    
    private FavorType IsGood()
    {
        int res;
        res = CheckFavor();
        if (res == 0)
            return FavorType.BALANCED;
        if (res > 0)
            return FavorType.GOOD;
        return FavorType.BAD;
    }
    
    public void AddGoodPoints(int points)
    {
        if (points < 0)
            throw new Exception("negative value for number of points to add");
        _goodPoints += points;
        PointsManager.instance.changePoints(_goodPoints, _badPoints);
        Favor = IsGood();
    }
    
    public void AddBadPoints(int points)
    {
        if (points < 0)
            throw new Exception("negative value for number of points to add");
        _badPoints += points;
        PointsManager.instance.changePoints(_goodPoints, _badPoints);
        Favor = IsGood();
    }
    

    
    // Awake is called when an enabled script instance is being loaded
    public void Awake()
    {
        Favor = FavorType.BALANCED;
        instance = this;
        _goodPoints = 1;
        _badPoints = 1;
    }
}
