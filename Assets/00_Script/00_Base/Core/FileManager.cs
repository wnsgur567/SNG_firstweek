using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public static class File_Extension
{

    public static List<string> File_Load(string _filePath, char _seperator = '\t')
    {
        string currentPath = Environment.CurrentDirectory;
        //Debug.Log(currentPath.ToString());
        string filePath = Path.Combine(currentPath, _filePath);
        StreamReader sr = null;
        try
        {
            sr = new StreamReader(new FileStream(filePath, FileMode.Open));
        }
        catch (FileLoadException e)
        {
            Debug.LogError(e.ToString());
        }

        List<string> loaded_data = new List<string>();

        while (sr.EndOfStream == false)
        {
            string s = sr.ReadLine();
            string[] line = s.Split(_seperator);

            foreach (var item in line)
            {
                loaded_data.Add(item);
            }
        }

        if (sr != null)
            sr.Close();

        return loaded_data;
    }
}

/////////////////////////////////////////////////////////////////////////

public struct Map_Info
{
    public int width { get; private set; }
    public int height { get; private set; }

    public List<int> tile_nums_back { get; private set; }
    public List<int> tile_nums_fore { get; private set; }

    public Map_Info(int _width, int _hegiht)
    {   // 모두 0으로 세팅
        width = _width;
        height = _hegiht;
        tile_nums_back = new List<int>(width * height);
        tile_nums_fore = new List<int>(width * height);
    }
}

/////////////////////////////////////////////////////////////////////////

public struct WayPoint_Info
{
    public Vector3 WayPoint;
}

public class FileManager : Singleton<FileManager>
{   // 게임 관련 정보 데이터를 불러옵니다
    // 리소스(이미지 및 사운드 등은 ResourceManager에서 관리)

    #region Tile_info(맵 정보 로드)
    public string map_info_path;
    public List<Map_Info> map_Info; // 각 스테이지 별로 보관

    void Load_MapInfo()
    {
        // 맵 정보 로드
        List<string> map_info_str = File_Extension.File_Load(map_info_path);

        map_Info = new List<Map_Info>();

        // 맵 정보 구조체에 담기
        int hegiht = int.Parse(map_info_str[0]);
        map_info_str.RemoveAt(0);
        int width = int.Parse(map_info_str[0]);
        map_info_str.RemoveAt(0);


        Map_Info tmp = new Map_Info(width, hegiht);
        for (int i = 0; i < map_info_str.Count; ++i)
        {
            int num = int.Parse(map_info_str[i]);
            int back = num / 1000;
            int fore = num % 1000;

            tmp.tile_nums_back.Add(back);
            tmp.tile_nums_fore.Add(fore);
        }
        map_Info.Add(tmp);
        // 맵 정보 로드 완료
    }

    #endregion

    public struct RoadInfo
    {
        public Vector3 starting_point;
        public List<WayPoint_Info> wayPoint_Infos;
    }

    #region EastWayPoint_info(East웨이포인트 정보 로드)

    public RoadInfo EastroadInfo;
    public string EastWayPoint_Path;

    void Load_EastWayPoint()
    {
        // 맵 정보 로드
        List<string> waypoint_info_str = File_Extension.File_Load(EastWayPoint_Path);

        EastroadInfo.wayPoint_Infos = new List<WayPoint_Info>();

        // 맵 정보 구조체에 담기
        int count = int.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        Vector3 temp1;

        temp1.x = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.y = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.z = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        EastroadInfo.starting_point = temp1;

        WayPoint_Info temp = new WayPoint_Info();
        for (int i = 0; i < count; ++i)
        {
            temp.WayPoint.x = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.y = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.z = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);

            EastroadInfo.wayPoint_Infos.Add(temp);
        }
    }
    #endregion

    #region WestWayPoint_info(West웨이포인트 정보 로드)

    public RoadInfo WestroadInfo;
    public string WestWayPoint_Path;

    void Load_WestWayPoint()
    {
        // 맵 정보 로드
        List<string> waypoint_info_str = File_Extension.File_Load(WestWayPoint_Path);

        WestroadInfo.wayPoint_Infos = new List<WayPoint_Info>();

        // 맵 정보 구조체에 담기
        int count = int.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        Vector3 temp1;

        temp1.x = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.y = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.z = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        WestroadInfo.starting_point = temp1;

        WayPoint_Info temp = new WayPoint_Info();
        for (int i = 0; i < count; ++i)
        {
            temp.WayPoint.x = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.y = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.z = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);

            WestroadInfo.wayPoint_Infos.Add(temp);
        }
    }
    #endregion

    #region SouthWayPoint_info(South웨이포인트 정보 로드)

    public string SouthWayPoint_Path;

    public RoadInfo SouthroadInfo;

    void Load_SouthWayPoint()
    {
        // 맵 정보 로드
        List<string> waypoint_info_str = File_Extension.File_Load(SouthWayPoint_Path);

        SouthroadInfo.wayPoint_Infos = new List<WayPoint_Info>();

        // 맵 정보 구조체에 담기
        int count = int.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        Vector3 temp1;

        temp1.x = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.y = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.z = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        SouthroadInfo.starting_point = temp1;

        WayPoint_Info temp = new WayPoint_Info();
        for (int i = 0; i < count; ++i)
        {
            temp.WayPoint.x = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.y = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.z = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);

            SouthroadInfo.wayPoint_Infos.Add(temp);
        }
    }
    #endregion

    #region NorthWayPoint_info(North웨이포인트 정보 로드)

    public string NorthWayPoint_Path;

    public RoadInfo NorthroadInfo;

    void Load_NorthWayPoint()
    {
        // 맵 정보 로드
        List<string> waypoint_info_str = File_Extension.File_Load(NorthWayPoint_Path);

        NorthroadInfo.wayPoint_Infos = new List<WayPoint_Info>();

        // 맵 정보 구조체에 담기
        int count = int.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        Vector3 temp1;

        temp1.x = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.y = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);
        temp1.z = float.Parse(waypoint_info_str[0]);
        waypoint_info_str.RemoveAt(0);

        NorthroadInfo.starting_point = temp1;

        WayPoint_Info temp = new WayPoint_Info();
        for (int i = 0; i < count; ++i)
        {
            temp.WayPoint.x = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.y = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);
            temp.WayPoint.z = float.Parse(waypoint_info_str[0]);
            waypoint_info_str.RemoveAt(0);

            NorthroadInfo.wayPoint_Infos.Add(temp);
        }
    }
    #endregion

    public string WarriorPath;
    public string ArcherPath;
    public string WizardPath;
    public string KnightPath;
    public string GryphonPath;

    public struct Status_Info
    {
        public int Attack;
        public float AttackSpeed;
        public int Defence;
        public float Stamina;
        public float MoveSpeed;
        public int Range;
    }

    public struct Monster_Info
    {
        public int MonsNum;
        public Status_Info status;
    }

    public List<Monster_Info> MonsterList = new List<Monster_Info>();

    #region Warrior(전사 정보 로드)
    void Load_Warrior()
    {
        // 맵 정보 로드
        List<string> Warrior_info_str = File_Extension.File_Load(WarriorPath);
        Monster_Info mons = new Monster_Info();

        // 맵 정보 구조체에 담기
        mons.MonsNum = int.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);

        mons.status.Attack = int.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);
        mons.status.AttackSpeed = float.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);
        mons.status.Stamina = int.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);
        mons.status.Defence = int.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);
        mons.status.MoveSpeed = float.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);
        mons.status.Range = int.Parse(Warrior_info_str[0]);
        Warrior_info_str.RemoveAt(0);

        MonsterList.Add(mons);
    }
    #endregion

    #region Archer(궁수 정보 로드)
    void Load_Archer()
    {
        // 맵 정보 로드
        List<string> Archer_info_str = File_Extension.File_Load(ArcherPath);

        Monster_Info mons = new Monster_Info();

        // 맵 정보 구조체에 담기
        mons.MonsNum = int.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);

        mons.status.Attack = int.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);
        mons.status.AttackSpeed = float.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);
        mons.status.Stamina = int.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);
        mons.status.Defence = int.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);
        mons.status.MoveSpeed = float.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);
        mons.status.Range = int.Parse(Archer_info_str[0]);
        Archer_info_str.RemoveAt(0);

        MonsterList.Add(mons);
    }
    #endregion

    #region Wizard(메이지 정보 로드)
    void Load_Wizard()
    {
        // 맵 정보 로드
        List<string> Wizard_info_str = File_Extension.File_Load(WizardPath);

        Monster_Info mons = new Monster_Info();

        // 맵 정보 구조체에 담기
        mons.MonsNum = int.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);

        mons.status.Attack = int.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);
        mons.status.AttackSpeed = float.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);
        mons.status.Stamina = int.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);
        mons.status.Defence = int.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);
        mons.status.MoveSpeed = float.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);
        mons.status.Range = int.Parse(Wizard_info_str[0]);
        Wizard_info_str.RemoveAt(0);

        MonsterList.Add(mons);
    }
    #endregion

    #region Knight(기사 정보 로드)
    void Load_Knight()
    {
        // 맵 정보 로드
        List<string> Knight_info_str = File_Extension.File_Load(KnightPath);

        Monster_Info mons = new Monster_Info();

        // 맵 정보 구조체에 담기
        mons.MonsNum = int.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);

        mons.status.Attack = int.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);
        mons.status.AttackSpeed = float.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);
        mons.status.Stamina = int.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);
        mons.status.Defence = int.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);
        mons.status.MoveSpeed = float.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);
        mons.status.Range = int.Parse(Knight_info_str[0]);
        Knight_info_str.RemoveAt(0);

        MonsterList.Add(mons);
    }
    #endregion

    #region Gryphon(그리폰 정보 로드)
    void Load_Gryphon()
    {
        // 맵 정보 로드
        List<string> Gryphon_info_str = File_Extension.File_Load(GryphonPath);

        Monster_Info mons = new Monster_Info();

        // 맵 정보 구조체에 담기
        mons.MonsNum = int.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);

        mons.status.Attack = int.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);
        mons.status.AttackSpeed = float.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);
        mons.status.Stamina = int.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);
        mons.status.Defence = int.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);
        mons.status.MoveSpeed = float.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);
        mons.status.Range = int.Parse(Gryphon_info_str[0]);
        Gryphon_info_str.RemoveAt(0);

        MonsterList.Add(mons);
    }
    #endregion

    public string StageLinePath;
    public string StageStatusPath;

    public struct Line_Info
    {
        public List<int> EastLine;
        public List<int> WestLine;
        public List<int> NorthLine;
        public List<int> SouthLine;
    }

    public struct StageLine_Info
    {
        public int stageNum;
        public List<Line_Info> MonsLine;
    }

    public StageLine_Info stageline;
    #region Stage(스테이지 각 방향 몬스터 정보 로드)
    void Load_StageLine()
    {
        // 맵 정보 로드
        List<string> StageLine_info_str = File_Extension.File_Load(StageLinePath);

        stageline.stageNum = int.Parse(StageLine_info_str[0]);
        StageLine_info_str.RemoveAt(0);

        Line_Info[] line = new Line_Info[stageline.stageNum];

        stageline.MonsLine = new List<Line_Info>();

        for (int i = 0; i < stageline.stageNum; i++)
        {
            line[i].EastLine = new List<int>();
            line[i].WestLine = new List<int>();
            line[i].NorthLine = new List<int>();
            line[i].SouthLine = new List<int>();

            for (int j = 0; j < 7; j++)
            {
                line[i].EastLine.Add(int.Parse(StageLine_info_str[0]));
                StageLine_info_str.RemoveAt(0);
            }

            for (int j = 0; j < 7; j++)
            {
                line[i].WestLine.Add(int.Parse(StageLine_info_str[0]));
                StageLine_info_str.RemoveAt(0);
            }

            for (int j = 0; j < 7; j++)
            {
                line[i].SouthLine.Add(int.Parse(StageLine_info_str[0]));
                StageLine_info_str.RemoveAt(0);
            }

            for (int j = 0; j < 7; j++)
            {
                line[i].NorthLine.Add(int.Parse(StageLine_info_str[0]));
                StageLine_info_str.RemoveAt(0);
            }

            stageline.MonsLine.Add(line[i]);
        }
    }
    #endregion

    public struct StageStatus_Info
    {
        public float AttackIncrease;
        public float StaminaIncrease;
        public float DefenceIncrease;
    }

    public List<StageStatus_Info> stagestatusinfo;

    #region Gryphon(스테이지 스텟 퍼센트 정보 로드)
    void Load_StageStatus()
    {
        // 맵 정보 로드
        List<string> StageStatus_info_str = File_Extension.File_Load(StageStatusPath);

        stagestatusinfo = new List<StageStatus_Info>();

        StageStatus_Info status;

        // 정보 구조체에 담기
        for (int i = 0; i < 20; i++)
        {
            status.AttackIncrease = float.Parse(StageStatus_info_str[0]);
            StageStatus_info_str.RemoveAt(0);
            status.StaminaIncrease = float.Parse(StageStatus_info_str[0]);
            StageStatus_info_str.RemoveAt(0);
            status.DefenceIncrease = float.Parse(StageStatus_info_str[0]);
            StageStatus_info_str.RemoveAt(0);

            stagestatusinfo.Add(status);
        }
    }
    #endregion

    override protected void Awake()
    {
        Load_MapInfo();
        Load_EastWayPoint();
        Load_WestWayPoint();
        Load_SouthWayPoint();
        Load_NorthWayPoint();
        Load_Warrior();
        Load_Archer();
        Load_Wizard();
        Load_Knight();
        Load_Gryphon();
        Load_StageLine();
        Load_StageStatus();
    }
}
