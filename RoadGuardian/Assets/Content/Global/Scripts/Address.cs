using System.Collections.Generic;

namespace Content.Global.Scripts
{
    public static class Address
    {
        public static List<string> AllKeys = new() {
            "InteractConfiguration",
            "BootstrapScene",
            "GlobalScene",
            "Player",
            "PlayerCamera",
        };
        
        public static class Configurations 
        {
            public const System.String InteractConfiguration = "InteractConfiguration"; 
            public const System.String PlayerDataConfiguration = "PlayerDataConfiguration";
            public const System.String EnemyDataConfiguration = "EnemyDataConfiguration";
            public const System.String TurretDataConfiguration = "TurretDataConfiguration";
            public const System.String SurfaceDataConfiguration = "SurfaceDataConfiguration";
            public const System.String LevelBuilderConfiguration = "LevelBuilderConfiguration";
            public static List<string> AllKeys = new() 
            {
                "InteractConfiguration",
                "PlayerDataConfiguration",
                "EnemyDataConfiguration",
                "TurretDataConfiguration",
                "SurfaceDataConfiguration",
                "LevelBuilderConfiguration",
            };
        }
        
        public static class Scenes 
        { 
            public const System.String BootstrapScene = "BootstrapScene"; 
            public const System.String GlobalScene = "GlobalScene";
            public const System.String MainScene = "MainScene";
            public static List<string> AllKeys = new() 
            {
                "BootstrapScene",
                "GlobalScene",
                "MainScene",
            }; 
        }
        
        public static class Prefabs 
        { 
            public const System.String Player = "Player";
            public const System.String Enemy = "Enemy";
            public const System.String PlayerCamera = "PlayerCamera"; 
            public static System.String Bullet = "Bullet";
            public static System.String Surface = "Surface";
            public static System.String UIRoot = "UIRoot";
            public static System.String DistanceWindow = "DistanceWindow";
            public static System.String PlayerHealthBarWindow = "PlayerHealthBarWindow";
            public static System.String GameOutcomeWindow = "GameOutcomeWindow";
            public static System.String IntroductionWindow = "IntroductionWindow";
            public static List<string> AllKeys = new() 
            {
                "Player",
                "Enemy",
                "PlayerCamera",
                "Bullet",
                "Surface",
                "UIRoot",
                "DistanceWindow",
                "PlayerHealthBarWindow",
                "GameOutcomeWindow",
                "IntroductionWindow",
            };
        }
        
        public static class Assets { }
    }
}