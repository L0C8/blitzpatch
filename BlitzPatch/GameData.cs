using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlitzPatch
{
    internal class GameData
    {

        public static readonly string[] factions =
        {
            "Allied", 
            "Soviet",
            "Axis"
        };

        public static readonly string[] units_ger = {   "pz_i",
                                                        "pz_ii_a",
                                                        "ww2_gr_assaultsq1_t3",
                                                        "ww2_gr_assaultsq2_t3",
                                                        "ww2_gr_mgsq1_t3",
                                                        "ww2_gr_atsq1_t3",
                                                        "ww2_gr_regsq2_t3",
                                                        "pz_38",
                                                        "renault_r35",
                                                        "cv3_carro",
                                                        "sdkfz_231",
                                                        "ww2_gr_minefieldatsquad_t2",
                                                        "ww2_gr_minefieldaisquad_t2",
                                                        "gr_athedgehogfarmx4",
                                                        "gr_barbedwire",
                                                        "at_rifle_gr_t2",
                                                        "pillbox_mg34_t2",
                                                        "hmg_gr_t3",
                                                        "charb1bis_gr",
                                                        "pz_iv_e",
                                                        "t_15",
                                                        "sdkfz_222",
                                                        "opel_aa_flak_38",
                                                        "stug_iii_a",
                                                        "at_gun_pak37_moving_t3",
                                                        "mortar_gr_t3",
                                                        "hw_sfh18_moving_t3",
                                                        "aarifle_gr_moving_t3",
                                                        "stug_iii_g",
                                                        "semovente_75",
                                                        "sturer_emil",
                                                        "sdkfz_251",
                                                        "ab_41",
                                                        "pz_iii_f",
                                                        "hotchkiss_h39",
                                                        "pz_vi_porsche",
                                                        "ww2_gr_mgsq1_t5",
                                                        "ww2_gr_atsq2_t5",
                                                        "ww2_gr_regsq3_t5",
                                                        "ww2_gr_regsq4_t5",
                                                        "ww2_gr_assaultsq1_t5",
                                                        "ww2_gr_assaultsq2_t5",
                                                        "ww2_gr_snipesquad_t5",
                                                        "ww2_gr_minefieldatsquad_t4",
                                                        "ww2_gr_minefieldaisquad_t4",
                                                        "at_rifle_gr_t4",
                                                        "pillbox_mg34_t4",
                                                        "hmg_gr_t5",
                                                        "nashorn",
                                                        "stug_iv",
                                                        "wespe",
                                                        "sdkfz_251_21",
                                                        "pz_iii",
                                                        "pz_iii_no_shields",
                                                        "pz_ii_luchs",
                                                        "pz_vi_tiger",
                                                        "at_gun_pak37_moving_t5",
                                                        "mortar_gr_t5",
                                                        "hw_sfh18_moving_t5",
                                                        "aarifle_gr_moving_t5",
                                                        "hetzer",
                                                        "hummel",
                                                        "ferdinand",
                                                        "sdkfz_250",
                                                        "sdkfz_234_puma",
                                                        "pz_iv",
                                                        "pz_vi_kingtiger",
                                                        "ww2_gr_atsq2_t7",
                                                        "ww2_gr_regsq3_t7",
                                                        "ww2_gr_regsq4_t7",
                                                        "ww2_gr_atsq3_t7",
                                                        "ww2_gr_mgsq2_t7",
                                                        "ww2_gr_assaultsq2_t7",
                                                        "ww2_gr_assaultsq3_t7",
                                                        "ww2_gr_minefieldatsquad_t6",
                                                        "ww2_gr_minefieldaisquad_t6",
                                                        "at_rifle_gr_t6",
                                                        "pillbox_mg34_t6",
                                                        "hmg_gr_t7",
                                                        "jagdtiger",
                                                        "sturmtiger",
                                                        "ostwind",
                                                        "wirbelwind",
                                                        "pz_v",
                                                        "jagdpanther",
                                                        "pz_viii_maus",
                                                        "panzerwerfer",
                                                        "at_gun_pak37_moving_t7",
                                                        "mortar_gr_t7",
                                                        "hw_sfh18_moving_t7",
                                                        "aarifle_gr_moving_t7",
                                                        "ww2_gr_artillery2support_t3",
                                                        "ww2_gr_artillery2support_t5",
                                                        "ww2_gr_artillery2support_t7",
                                                        "ww2_gr_smokescreen2_t3",
                                                        "ww2_gr_spyplane_t3",
                                                        "ww2_gr_spyplane_t6",
                                                        "ww2_gr_dropplane_t3",
                                                        "ww2_gr_dropplane_t5",
                                                        "ww2_gr_dropplane_t7",
                                                        "ww2_gr_fighter_t3",
                                                        "ww2_gr_fighter_t5",
                                                        "ww2_gr_fighter_t7",
                                                        "ww2_gr_attackplane_t3",
                                                        "ww2_gr_attackplane_t5",
                                                        "ww2_gr_attackplane_t7",
                                                        "ww2_gr_bomber_t3",
                                                        "ww2_gr_bomber_t5",
                                                        "ww2_gr_bomber_t7" };

        public static readonly string[] units_ald = {  "mk_vi_b",
                                                        "ww2_us_assaultsq1_t3",
                                                        "ww2_us_mgsq1_t3",
                                                        "ww2_us_atsq1_t3",
                                                        "ww2_us_regsq2_t3",
                                                        "carden_loyd",
                                                        "panhard_178",
                                                        "mk_ix_valentine",
                                                        "mk_i_a9",
                                                        "mk_ii_matilda_ii",
                                                        "ww2_us_minefieldatsquad_t2",
                                                        "ww2_us_minefieldaisquad_t2",
                                                        "us_athedgehogfarmx4",
                                                        "us_barbedwire",
                                                        "at_rifle_us_t2",
                                                        "pillbox_m2browning_t2",
                                                        "hmg_us_t3",
                                                        "m2_halftrack",
                                                        "studebaker_aa_m1",
                                                        "charb1bis",
                                                        "m3a1_stuart",
                                                        "somua_s35",
                                                        "at_gun_m3_37mm_moving_t3",
                                                        "mortar_us_t3",
                                                        "hw_m114_155mm_moving_t3",
                                                        "aarifle_us_moving_t3",
                                                        "t49_gmc",
                                                        "humber",
                                                        "m3_lee",
                                                        "crusader",
                                                        "m5a1_stuart",
                                                        "ww2_us_mgsq1_t5",
                                                        "ww2_us_atsq2_t5",
                                                        "ww2_us_atsq3_t5",
                                                        "ww2_us_regsq3_t5",
                                                        "ww2_us_assaultsq1_t5",
                                                        "ww2_us_snipesquad_t5",
                                                        "ww2_us_minefieldatsquad_t4",
                                                        "ww2_us_minefieldaisquad_t4",
                                                        "at_rifle_us_t4",
                                                        "pillbox_m2browning_t4",
                                                        "hmg_us_t5",
                                                        "m10_td",
                                                        "m7_priest",
                                                        "m3_m16",
                                                        "m22_locust",
                                                        "m4a1_sherman",
                                                        "m4a4",
                                                        "m6a2e1",
                                                        "churchill",
                                                        "at_gun_m3_37mm_moving_t5",
                                                        "mortar_us_t5",
                                                        "hw_m114_155mm_moving_t5",
                                                        "aarifle_us_moving_t5",
                                                        "m18_hellcat",
                                                        "m36_jackson",
                                                        "m3_halftrack",
                                                        "m4a1_76_w_sherman",
                                                        "m24_chaffee",
                                                        "m26_pershing",
                                                        "t26e1_superpershing",
                                                        "ww2_us_mgsq2_t7",
                                                        "ww2_us_atsq2_t7",
                                                        "ww2_us_regsq3_t7",
                                                        "ww2_us_assaultsq2_t7",
                                                        "ww2_us_minefieldatsquad_t6",
                                                        "ww2_us_minefieldaisquad_t6",
                                                        "at_rifle_us_t6",
                                                        "pillbox_m2browning_t6",
                                                        "hmg_us_t7",
                                                        "t95_td",
                                                        "m19_40mm",
                                                        "m8_greyhound",
                                                        "m4a4_firefly",
                                                        "m4a3e8_sherman",
                                                        "shermancalliope",
                                                        "at_gun_m3_37mm_moving_t7",
                                                        "mortar_us_t7",
                                                        "hw_m114_155mm_moving_t7",
                                                        "aarifle_us_moving_t7",
                                                        "ww2_us_artillery2support_t3",
                                                        "ww2_us_artillery2support_t5",
                                                        "ww2_us_artillery2support_t7",
                                                        "ww2_us_smokescreen2_t3",
                                                        "ww2_us_spyplane_t3",
                                                        "ww2_us_spyplane_t6",
                                                        "ww2_us_dropplane_t3",
                                                        "ww2_us_dropplane_t5",
                                                        "ww2_us_dropplane_t7",
                                                        "ww2_us_fighter_t3",
                                                        "ww2_us_fighter_t5",
                                                        "ww2_us_fighter_t7",
                                                        "ww2_us_attackplane_t3",
                                                        "ww2_us_attackplane_t5",
                                                        "ww2_us_attackplane_t7",
                                                        "ww2_us_bomber_t3",
                                                        "ww2_us_bomber_t5",
                                                        "ww2_us_bomber_t7"};

        public static readonly string[] units_sov = {  "t_26",
                                                        "ww2_ru_atsq1_t3",
                                                        "ww2_ru_mgsq1_t3",
                                                        "ww2_ru_assaultsq1_t3",
                                                        "ww2_ru_regsq2_t3",
                                                        "ww2_ru_regsq3_t3",
                                                        "t_27",
                                                        "bt_7",
                                                        "ww2_ru_minefieldatsquad_t2",
                                                        "ww2_ru_minefieldaisquad_t2",
                                                        "ru_athedgehogfarmx4",
                                                        "ru_barbedwire",
                                                        "at_rifle_ru_t2",
                                                        "pillbox_dshk_t2",
                                                        "hmg_ru_t3",
                                                        "zis_30",
                                                        "su_76",
                                                        "ba_30",
                                                        "zis_42_aa_72k",
                                                        "t_50",
                                                        "t_70",
                                                        "kv_1",
                                                        "kv_2",
                                                        "at_gun_19k_45mm_moving_t3",
                                                        "mortar_ru_t3",
                                                        "hw_ml_20_moving_t3",
                                                        "aarifle_ru_moving_t3",
                                                        "su_85",
                                                        "ba_64",
                                                        "t_80",
                                                        "t_34_76_hpz",
                                                        "ww2_ru_mgsq1_t5",
                                                        "ww2_ru_mgsq2_t5",
                                                        "ww2_ru_atsq2_t5",
                                                        "ww2_ru_regsq3_t5",
                                                        "ww2_ru_assaultsq1_t5",
                                                        "ww2_ru_snipesquad_t5",
                                                        "ww2_ru_snipesquad2_t5",
                                                        "ww2_ru_minefieldatsquad_t4",
                                                        "ww2_ru_minefieldaisquad_t4",
                                                        "at_rifle_ru_t4",
                                                        "pillbox_dshk_t4",
                                                        "hmg_ru_t5",
                                                        "m3_m16_ru",
                                                        "su_122",
                                                        "su_100_y",
                                                        "t_34_76",
                                                        "t_34_76_ecran_premium",
                                                        "kv_85",
                                                        "su_14",
                                                        "at_gun_19k_45mm_moving_t5",
                                                        "mortar_ru_t5",
                                                        "hw_ml_20_moving_t5",
                                                        "aarifle_ru_moving_t5",
                                                        "isu_122",
                                                        "m3_halftrack_ru",
                                                        "t_34_85",
                                                        "is_2",
                                                        "ww2_ru_mgsq2_t7",
                                                        "ww2_ru_atsq2_t7",
                                                        "ww2_ru_regsq3_t7",
                                                        "ww2_ru_minefieldatsquad_t6",
                                                        "ww2_ru_minefieldaisquad_t6",
                                                        "ww2_ru_assaultsq2_t7",
                                                        "at_rifle_ru_t6",
                                                        "pillbox_dshk_t6",
                                                        "hmg_ru_t7",
                                                        "su_100",
                                                        "isu_152",
                                                        "zsu_37",
                                                        "t_44",
                                                        "is_3",
                                                        "bm13nkatyusha",
                                                        "at_gun_19k_45mm_moving_t7",
                                                        "mortar_ru_t7",
                                                        "hw_ml_20_moving_t7",
                                                        "aarifle_ru_moving_t7",
                                                        "ww2_ru_artillery2support_t3",
                                                        "ww2_ru_artillery2support_t5",
                                                        "ww2_ru_artillery2support_t7",
                                                        "ww2_ru_smokescreen2_t3",
                                                        "ww2_ru_spyplane_t3",
                                                        "ww2_ru_spyplane_t6",
                                                        "ww2_ru_dropplane_t3",
                                                        "ww2_ru_dropplane_t5",
                                                        "ww2_ru_dropplane_t7",
                                                        "ww2_ru_fighter_t3",
                                                        "ww2_ru_fighter_t5",
                                                        "ww2_ru_fighter_t7",
                                                        "ww2_ru_attackplane_t3",
                                                        "ww2_ru_attackplane_t5",
                                                        "ww2_ru_attackplane_t7",
                                                        "ww2_ru_bomber_t3",
                                                        "ww2_ru_bomber_t5",
                                                        "ww2_ru_bomber_t7"};

        public static readonly string campaign_ger = "GR_ParisGate";

        public static readonly string campaign_ald = "US_RoadToRome";
        
        public static readonly string campaign_sov = "RU_BerlinFall";

        public static readonly string[] mission_ger = {     "Poland_mission",
                                                            "Arras",
                                                            "Africa",
                                                            "Daugavpils",
                                                            "Sevastopol_mission",
                                                            "ElAlamein_mission",
                                                            "Ardennes_mission"
                                                        };

        public static readonly string[] mission_ald = {     "Libya_mission",
                                                            "Crete",
                                                            "Tobruk",
                                                            "Lightfoot",
                                                            "Anzio",
                                                            "Normandy",
                                                            "Bastogne"
                                                        };
       
        public static readonly string[] mission_sov = {     "Luga",
                                                            "Rjev",
                                                            "Sevastopol_ru",
                                                            "Stalingrad",
                                                            "Kursk",
                                                            "Warsaw",
                                                            "Berlin2",
                                                            "Berlin"
                                                        };

        public static readonly string[] pvp_maps = {
                                                        "ww2_cp2_t5_6",
                                                        "ww2_cp2_t5_9",
                                                        "ww2_cp3_t7_1"
                                                    };

        public static readonly string[] pvp_maps_ids = {
                                                            "ww2_cp1_t3_4",
                                                            "ww2_cp2_t5_9",
                                                            "ww2_cp3_t7_1"
                                                       };
        
        // data for a_1_j
        public class UserProgress
        {
            public class Scenario
            {
                public bool Unlocked { get; set; }
                public bool Complete { get; set; }
                public string Id { get; set; }
            }

            public class VisitedTier
            {
                public bool AuthComplete { get; set; }
                public int TierType { get; set; }
                public int FactionType { get; set; }
                public int Level { get; set; }
                public string PvpMapId { get; set; }
                public DateTime LastActivity { get; set; }
                public TimeSpan TimeInTier { get; set; }
            }

            public class FactionProgress
            {
                public List<string> UnlockedPvpMaps { get; set; }
                public WinLoseStats WinLoseStat { get; set; }
                public int CurrentTier { get; set; }
                public int FactionType { get; set; }
                public PvpMapIds PvpMapId { get; set; }
                public DateTime LastLoadedDate { get; set; }
                public int TutorialStep { get; set; }
            }

            public class WinLoseStats
            {
                public int winAtt { get; set; }
                public int winDef { get; set; }
                public int loseAtt { get; set; }
                public int loseDef { get; set; }
                public int TotalBattles { get; set; }
            }

            public class PvpMapIds
            {
                public string Early { get; set; }
                public string Middle { get; set; }
                public string Late { get; set; }
            }

            public class PvEMission
            {
                public string MissionId { get; set; }
                public string CampaignId { get; set; }
                public bool IsMainObjectivesCompleted { get; set; }
                public bool IsOptionalObjectivesCompleted { get; set; }
                public bool IsChallengesCompleted { get; set; }
                public int MaxAchievedStars { get; set; }
            }

            public class Achievement
            {
                public string Id { get; set; }
                public int Count { get; set; }
            }
        }

        // data for a_2_j
        public class UserMap 
        {
            public class Maps
            {

            }

            public class Units
            {

            }

            public class SupportsReserve
            {

            }
        }

        // data for maps
        public class MapEra
        {
            public int Epoch { get; set; }
            public DateTime ShieldEndTime { get; set; }
            public DateTime MmLockEndTime { get; set; }
            public DateTime LastLoadedTime { get; set; }
            public DateTime ActivityTime { get; set; }
            public DateTime MigrationTime { get; set; }
            public int DailyAttacks { get; set; }
            public int Power { get; set; }
            public string SceneName { get; set; }

        }

            // data for unit
            public class Unit
        {
            public double exp { get; set; }
            public int expLvl { get; set; }
            public string id { get; set; }
            public int idOnServer { get; set; }
            public UnitOnMaps unitOnMaps { get; set; }
        }
        public class UnitOnMaps
        {
            public MapData Unknown { get; set; } = new MapData();
            public MapData Early { get; set; } = new MapData();
            public MapData Middle { get; set; } = new MapData();
            public MapData Late { get; set; } = new MapData();
        }
        public class MapData
        {
            public int Parent { get; set; } = -1;
            public Position Pos { get; set; } = new Position();
            public double Angle { get; set; } = 0.0;
            public int Modes { get; set; } = 0;
        }
        public class Position
        {
            public double X { get; set; } = 0.0;
            public double Y { get; set; } = 0.0;
            public double Z { get; set; } = 0.0;
        }
    }

}
 