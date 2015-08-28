using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Net;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Security.Cryptography;

namespace Pikabot4
{
    class clsFunctions
    {
        //public const string authorizedUserList = @"http://dl.dropbox.com/u/6323987/MouseHunt/PikabotEnvironmentVariables/accounts.txt";
        public const string authorizedUserList = @"http://dl.dropbox.com/u/3876484/Mousehunt/PikabotEnvironmentVariables/accounts.dat";
        public const string authorizedUserListAlt = @"http://dl.dropbox.com/u/9094768/PikabotEnvironmentVariables/authusers.txt";
        public const string newsURL = @"http://dl.dropbox.com/u/6323987/MouseHunt/PikabotEnvironmentVariables/news.htm";
        public const string talkURL = @"http://dl.dropbox.com/u/6323987/MouseHunt/PikabotEnvironmentVariables/talk.htm";
        public const string announcementURL = @"http://dl.dropbox.com/u/6323987/MouseHunt/PikabotEnvironmentVariables/announcement.txt";
        public const string announcementURLAlt = @"http://dl.dropbox.com/u/9094768/PikabotEnvironmentVariables/announcement.txt";
        public const string logFile = @"events.log";
        public static string krHTMPath;
        
        public static clsWeb cWeb;
        public static string cCookie = "";
        public static string HTMLData;
        public static int screenWidth;
        public static int screenHeight;
        public static int processInstance;
        public static string announcement;

        public static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;

                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;

                    case 90:
                        operatingSystem = "Me";
                        break;

                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;

                    case 4:
                        operatingSystem = "NT 4.0";
                        break;

                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;

                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else
                            operatingSystem = "7";
                        break;

                    default:
                        break;
                }
            }

            //Return the information we've gathered.
            return operatingSystem;
        } //End getOSInfo

        public static string generateUserAgent()
        {
            if (getOSInfo() == "7")
                //return "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2)";
                return "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            else if (getOSInfo() == "Vista")
                return "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; SLCC2)";
            else if (getOSInfo() == "XP")
                return "Mozilla/4.0 (compatible; MSIE 5.1; Windows NT 5.1; Trident/4.0; SLCC2)";
            else
                return "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT; Trident/4.0; SLCC2)";
        }

        public static string getWebDocument(string url)
        {
            string strResult = "";

            WebResponse objResponse;
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);

            objResponse = objRequest.GetResponse();

            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                sr.Close();
            }

            return strResult;
        } //End getWebDocument

        public static List<string> getWebDocumentByLine(string url)
        {
            string currentLine = "";
            List<string> strList = new List<String>();

            WebResponse objResponse;

            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);

            objResponse = objRequest.GetResponse();

            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                while ((currentLine = sr.ReadLine()) != null)
                {
                    strList.Add(currentLine);
                }
                sr.Close();
            }

            return strList;
        } //End getWebDocument

        public static Image checkMouseImage(string mouseCode)
        {
            switch (mouseCode)
            {
                case "log_bronze":
                    return Properties.Resources.log_bronze;
                case "log_silver":
                    return Properties.Resources.log_silver;
                case "log_gold":
                    return Properties.Resources.log_gold;
                case "log_titlechange":
                    return Properties.Resources.log_titleup;
                case "log_cheesecraft":
                    return Properties.Resources.log_cheesecraft;
                case "log_goldplus":
                    return Properties.Resources.log_goldplus;
                case "log_itemplus":
                    return Properties.Resources.log_itemplus;
                case "log_travel":
                    return Properties.Resources.log_travel;
                case "log_catchfailuredamage":
                    return Properties.Resources.log_pillage;
                case "log_catchfailure":
                    return Properties.Resources.log_steal;
                case "log_attractionfailurestale":
                    return Properties.Resources.log_stalecheese;
                case "log_attractionfailure":
                    return Properties.Resources.log_steal;
                case "log_captchasolved":
                    return Properties.Resources.log_KR;
                case "log_ballot":
                    return Properties.Resources.ballot_ticket;
                case "white":
                    return Properties.Resources.mouse_white_journal;
                case "grey":
                    return Properties.Resources.mouse_grey_journal;
                case "brown":
                    return Properties.Resources.mouse_brown_journal;
                case "moosker":
                    return Properties.Resources.mouse_moosker_journal;
                case "wiggler":
                    return Properties.Resources.mouse_wiggler_journal;
                case "sylvan":
                    return Properties.Resources.mouse_sylvan_journal;
                case "dwarf":
                    return Properties.Resources.mouse_dwarf_journal;
                case "mutated_white":
                    return Properties.Resources.mouse_mutated_white_journal;
                case "mutated_grey":
                    return Properties.Resources.mouse_mutated_grey_journal;
                case "mole":
                    return Properties.Resources.mouse_mole_journal;
                case "hapless":
                    return Properties.Resources.mouse_hapless_journal;
                case "swabbie":
                    return Properties.Resources.mouse_swabbie_journal;
                case "frog":
                    return Properties.Resources.mouse_frog_journal;
                case "steel":
                    return Properties.Resources.mouse_steel_journal;
                case "granite":
                    return Properties.Resources.mouse_granite_journal;
                case "worker":
                    return Properties.Resources.mouse_worker_journal;
                case "chameleon":
                    return Properties.Resources.mouse_chameleon_journal;
                case "pinchy":
                    return Properties.Resources.mouse_pinchy_journal;
                case "briegull":
                    return Properties.Resources.mouse_gull_journal;
                case "bionic":
                    return Properties.Resources.mouse_bionic_journal;
                case "cupid":
                    return Properties.Resources.mouse_cupid_journal;
                case "bear":
                    return Properties.Resources.mouse_bear_journal;
                case "gold":
                    return Properties.Resources.mouse_gold_journal;
                case "hollowhead":
                    return Properties.Resources.mouse_hollowhead_journal;
                case "shaman":
                    return Properties.Resources.mouse_shaman_journal;
                case "treant":
                    return Properties.Resources.mouse_treant_journal;
                case "diamond":
                    return Properties.Resources.mouse_diamond_journal;
                case "elf":
                    return Properties.Resources.mouse_elf_journal;
                case "birthday":
                    return Properties.Resources.mouse_birthday_journal;
                case "nibbler":
                    return Properties.Resources.mouse_nibbler_journal;
                case "glitchpaw":
                    return Properties.Resources.mouse_glitchpaw_journal;
                case "wicked_witch_of_whisker_woods":
                    return Properties.Resources.mouse_witch_journal;
                case "elven_princess":
                    return Properties.Resources.mouse_elvenprincess_journal;
                case "ninja":
                    return Properties.Resources.mouse_ninja_journal;
                case "pirate":
                    return Properties.Resources.mouse_pirate_journal;
                case "abominable_snow":
                    return Properties.Resources.mouse_abominable_snow_journal;
                case "shipwrecked":
                    return Properties.Resources.mouse_shipwrecked_journal;
                case "giant_snail":
                    return Properties.Resources.mouse_giantsnail_SW4MP_journal;
                case "foxy":
                    return Properties.Resources.mouse_foxy_journal;
                case "salt_water_snapper":
                    return Properties.Resources.mouse_snapper_journal;
                case "narrator":
                    return Properties.Resources.mouse_nerg_narrator_8IPEQQ_journal;
                case "taleweaver":
                    return Properties.Resources.mouse_elub_taleweaver_123SD9_journal;
                case "trailblazer":
                    return Properties.Resources.mouse_derr_trailblazer_897DCS_journal;
                case "pathfinder":
                    return Properties.Resources.mouse_nerg_pathfinder_9FJVCD_journal;
                case "scout":
                    return Properties.Resources.mouse_elub_scout_8GHQW1_journal;
                case "goblin":
                    return Properties.Resources.mouse_goblin_journal;
                case "zombie":
                    return Properties.Resources.mouse_zombie_journal;
                case "ghost":
                    return Properties.Resources.mouse_ghost_journal;
                case "bat":
                    return Properties.Resources.mouse_bat_journal;
                case "eagle_owl":
                    return Properties.Resources.mouse_owl_journal;
                case "cyclops":
                    return Properties.Resources.mouse_cyclops_journal;
                case "caretaker":
                    return Properties.Resources.mouse_nerg_caretaker_92JF8C_journal;
                case "alchemist":
                    return Properties.Resources.mouse_elub_alchemist_7GHHGH_journal;
                case "wordsmith":
                    return Properties.Resources.mouse_derr_wordsmith_10CJD8_journal;
                case "cook":
                    return Properties.Resources.mouse_cook_journal_E23GC;
                case "healer":
                    return Properties.Resources.mouse_derr_healer_92JDC8_journal;
                case "skeleton":
                    return Properties.Resources.mouse_skeleton_journal;
                case "keepers_assistant":
                    return Properties.Resources.mouse_keepassist_journal;
                case "mermaid":
                    return Properties.Resources.mouse_mermaid_journal;
                case "finder":
                    return Properties.Resources.mouse_nerg_finder_938DJCS_journal;
                case "pack":
                    return Properties.Resources.mouse_elub_pack_8FHTYY_journal;
                case "keeper":
                    return Properties.Resources.mouse_keeper_journal;
                case "bottled":
                    return Properties.Resources.mouse_bottled_journal_FKE6G;
                case "grunt":
                    return Properties.Resources.mouse_derr_grunt_ALC10B_journal;
                case "black_widow":
                    return Properties.Resources.mouse_black_widow_journal;
                case "burglar":
                    return Properties.Resources.mouse_burglar_journal;
                case "mummy":
                    return Properties.Resources.mouse_mummy_journal;
                case "mystic":
                    return Properties.Resources.mouse_elub_mystic_76850C_journal;
                case "archer":
                    return Properties.Resources.mouse_archer_journal;
                case "beast_tamer":
                    return Properties.Resources.mouse_nerg_beasttamer_0239FSC_journal;
                case "water_nymph":
                    return Properties.Resources.mouse_water_nymph_journal;
                case "spellbinder":
                    return Properties.Resources.mouse_derr_spellbinder_8FJCS9_journal;
                case "buccaneer":
                    return Properties.Resources.mouse_buccaneer_journal;
                case "ravenous_zombie":
                    return Properties.Resources.mouse_ravenous_zombie_journal;
                case "gargoyle":
                    return Properties.Resources.mouse_gargoyle_journal;
                case "spider":
                    return Properties.Resources.mouse_spider_journal;
                case "scavenger":
                    return Properties.Resources.mouse_scavenger_journal;
                case "ooze":
                    return Properties.Resources.mouse_ooze_journal;
                case "sorcerer":
                    return Properties.Resources.mouse_sorcerer_FACES_journal;
                case "spectre":
                    return Properties.Resources.mouse_spectre_journal;
                case "siren":
                    return Properties.Resources.mouse_siren_journal;
                case "centaur":
                    return Properties.Resources.mouse_centaur_journal;
                case "kung_fu":
                    return Properties.Resources.mouse_kung_fu_journal;
                case "terror_knight":
                    return Properties.Resources.mouse_terrorknight_284HFC_journal;
                case "samurai":
                    return Properties.Resources.mouse_samurai_journal;
                case "monk":
                    return Properties.Resources.mouse_monk_journal;
                case "mintaka":
                    return Properties.Resources.mouse_derr_mintaka_83JDCS_journal;
                case "tiger":
                    return Properties.Resources.mouse_tiger_journal;
                case "fairy":
                    return Properties.Resources.mouse_fairy_journal;
                case "vampire":
                    return Properties.Resources.mouse_vampire_journal;
                case "student_of_the_cheese_claw":
                    return Properties.Resources.mouse_sot_cheeseclaw_journal;
                case "student_of_the_cheese_fang":
                    return Properties.Resources.mouse_sot_cheesefang_journal;
                case "student_of_the_cheese_belt":
                    return Properties.Resources.mouse_sot_cheesebelt_journal;
                case "golem":
                    return Properties.Resources.mouse_golem_journal;
                case "captain":
                    return Properties.Resources.mouse_captain_journal;
                case "seer":
                    return Properties.Resources.mouse_derr_seer_J493JC_journal;
                case "gate_guardian":
                    return Properties.Resources.mouse_gateguardian_journal;
                case "alnitak":
                    return Properties.Resources.mouse_elub_alnitak_5H3LAZ_journal;
                case "alnilam":
                    return Properties.Resources.mouse_nerg_alnilam_923JF7_journal;
                case "renegade":
                    return Properties.Resources.mouse_derr_renegade_JD93PD_journal;
                case "aged":
                    return Properties.Resources.mouse_derr_aged_J39DNC_journal;
                case "soothsayer":
                    return Properties.Resources.mouse_elub_soothsayer_HGFR8D_journal;
                case "conjurer":
                    return Properties.Resources.mouse_derr_conjurer_JFK39D_journal;
                case "vanquisher":
                    return Properties.Resources.mouse_elub_vanquisher_983DV9_journal;
                case "conqueror":
                    return Properties.Resources.mouse_nerg_conqueror_MGH102_journal;
                case "gorgon":
                    return Properties.Resources.mouse_gorgon_journal;
                case "grandfather":
                    return Properties.Resources.mouse_nerg_grandfather_20GHFB_journal;
                case "guardian":
                    return Properties.Resources.mouse_derr_guardian_J39DS9_journal;
                case "elder":
                    return Properties.Resources.mouse_elub_elder_journal;
                case "reaper":
                    return Properties.Resources.mouse_reaper_journal;
                case "gladiator":
                    return Properties.Resources.mouse_derr_gladiator_JFRI4D_journal;
                case "defender":
                    return Properties.Resources.mouse_nerg_defender_923MDC_journal;
                case "protector":
                    return Properties.Resources.mouse_elub_protector_93JFC7_journal;
                case "assassin":
                    return Properties.Resources.mouse_assassin_journal;
                case "nomad":
                    return Properties.Resources.mouse_nomad_journal;
                case "draconic_warden":
                    return Properties.Resources.mouse_draconic_warden_83JFYC_journal;
                case "squeaken":
                    return Properties.Resources.mouse_squeaken_journal;
                case "master_of_the_cheese_belt":
                    return Properties.Resources.mouse_motc_belt_journal;
                case "master_of_the_cheese_fang":
                    return Properties.Resources.mouse_motc_fang_journal;
                case "master_of_the_cheese_claw":
                    return Properties.Resources.mouse_motc_claw_journal;
                case "leviathan":
                    return Properties.Resources.mouse_leviathan_journal;
                case "wight":
                    return Properties.Resources.mouse_wight_journal;
                case "slayer":
                    return Properties.Resources.mouse_nerg_slayer_92N4F89_journal;
                case "lycan":
                    return Properties.Resources.mouse_lycan_journal;
                case "troll":
                    return Properties.Resources.mouse_troll_journal;
                case "harpy":
                    return Properties.Resources.mouse_harpy_journal;
                case "monster":
                    return Properties.Resources.mouse_monster_journal;
                case "champion":
                    return Properties.Resources.mouse_elub_champion_JFR98D_journal;
                case "derr_chieftain":
                    return Properties.Resources.mouse_derr_chieftain_FHE83H_journal;
                case "nerg_chieftain":
                    return Properties.Resources.mouse_nerg_chieftain_012MN3_journal;
                case "hydra":
                    return Properties.Resources.mouse_hydra_journal;
                case "elub_chieftain":
                    return Properties.Resources.mouse_elub_chieftain_8FHDC7_journal;
                case "primal":
                    return Properties.Resources.mouse_primal_82DHCA_journal;
                case "fetid_swamp":
                    return Properties.Resources.mouse_swamp_9DC0SA_journal;
                case "stonework_warrior":
                    return Properties.Resources.mouse_boulder_93JDNF_journal;
                case "jurassic":
                    return Properties.Resources.mouse_jurassic_29DJCS_journal;
                case "lich":
                    return Properties.Resources.mouse_lich_journal;
                case "chitinous":
                    return Properties.Resources.mouse_chitinous_JFRD9C_journal;
                case "magma_carrier":
                    return Properties.Resources.mouse_magma_HFRYD8C_journal;
                case "master_of_the_dojo":
                    return Properties.Resources.mouse_mot_dojo_journal;
                case "acolyte":
                    return Properties.Resources.mouse_acolyte_journal;
                case "dragon":
                    return Properties.Resources.mouse_dragon_WOW_A_DRAGON_journal;
                case "toy":
                    return Properties.Resources.mouse_toy_NBHVLA_journal;
                case "candy_cane":
                    return Properties.Resources.mouse_candycane_8DHFCP_journal;
                case "present":
                    return Properties.Resources.mouse_present_8F9CAP_journal;
                case "christmas_tree":
                    return Properties.Resources.mouse_xmastree_A9DCLZ_journal;
                case "frosty_snow":
                    return Properties.Resources.mouse_snowman_JD1LZX_journal;
                case "nutcracker":
                    return Properties.Resources.mouse_nutcracker_8DFHYT_journal;
                case "ornament":
                    return Properties.Resources.mouse_ornament_QW1234_journal;
                case "stocking":
                    return Properties.Resources.mouse_stockingstuffer_8DLMN_journal;
                case "rockstar":
                    return Properties.Resources.mouse_rockstar_YEEEAAH_journal;
                case "big_bad_burroughs":
                    return Properties.Resources.mouse_bbbourghs_7CUDO_journal;
                case "core_sample":
                    return Properties.Resources.mouse_coresample_7D81LM_journal;
                case "lambent_crystal":
                    return Properties.Resources.mouse_crystal_journal;
                case "curious_chemist":
                    return Properties.Resources.mouse_curious_chemist_JDKQIC_journal;
                case "demolitions":
                    return Properties.Resources.mouse_demolitions_JFUCLP_journal;
                case "miner":
                    return Properties.Resources.mouse_digger_F80ASO_journal;
                case "dojo_sensei":
                    return Properties.Resources.mouse_dojo_sensai_D01JDC_journal;
                case "frozen":
                    return Properties.Resources.mouse_frozen_7D8ACP_journal;
                case "hope":
                    return Properties.Resources.mouse_hope_H0P3Z_journal;
                case "industrious_digger":
                    return Properties.Resources.mouse_industriousdigger_8D09A1_journal;
                case "itty-bitty_burroughs":
                    return Properties.Resources.mouse_industriousdigger_8D09A1_journal;
                case "nugget":
                    return Properties.Resources.mouse_nugget_8D9CHA_journal;
                case "rock_muncher":
                    return Properties.Resources.mouse_rock_muncher_D8CJAL_journal;
                case "silth":
                    return Properties.Resources.mouse_silth_4758CS_journal;
                case "stone_cutter":
                    return Properties.Resources.mouse_stone_cutter_LPQIFG_journal;
                case "subterranean":
                    return Properties.Resources.mouse_subterranian_8D9CLP_journal;
                case "terrible_twos":
                    return Properties.Resources.mouse_terrible_twos_BR4TY_journal;
                case "costumed_tiger":
                    return Properties.Resources.mouse_costumedtiger_legOO_journal;
                case "dumpling_chef":
                    return Properties.Resources.mouse_dumplingchef_dChiE_journal;
                case "new_years":
                    return Properties.Resources.mouse_newyears_8D9FC0_journal;
                case "red_envelope":
                    return Properties.Resources.mouse_redenvelope_8392C_journal;
                case "romeno":
                    return Properties.Resources.mouse_romeno_greezy_journal;
                case "romeo":
                    return Properties.Resources.mouse_romeo_asstk_journal;
                case "twisted_fiend":
                    return Properties.Resources.mouse_twisted_fiend_JDKC83_journal;
                case "davy_jones":
                    return Properties.Resources.mouse_davy_jones_4QWERT_journal;
                case "nerg_lich":
                    return Properties.Resources.mouse_nerg_lich_8EIFKC_journal;
                case "derr_lich":
                    return Properties.Resources.mouse_derr_lich_ID90D8_journal;
                case "enslaved_spirit":
                    return Properties.Resources.mouse_enslaved_spirit_WER3XC_journal;
                case "brimstone":
                    return Properties.Resources.mouse_brimstone_12KNCI_journal;
                case "riptide":
                    return Properties.Resources.mouse_riptide_K2RKCS_journal;
                case "elub_lich":
                    return Properties.Resources.mouse_elub_lich_2K3J4H_journal;
                case "balack_the_banished":
                    return Properties.Resources.mouse_balack_the_banished_K23KFS_journal;
                case "pigmy_swarm":
                    return Properties.Resources.mouse_swarm_23ERTF_journal;
                case "clockwork_samurai":
                    return Properties.Resources.mouse_clockwork_samurai_journal;
                case "carved_hapless_puppet":
                    return Properties.Resources.mouse_hapless_marionette_journal;
                case "sock_puppet_ghost":
                    return Properties.Resources.mouse_sock_puppet_ghost_journal;
                case "puppet_master":
                    return Properties.Resources.mouse_puppet_master_journal;
                case "toy_sylvan":
                    return Properties.Resources.mouse_toy_sylvan_journal;
                case "wound_up_white":
                    return Properties.Resources.mouse_wound_up_white_journal;
                case "master_burglar":
                    return Properties.Resources.mouse_master_burglar_journal;
                case "bandit":
                    return Properties.Resources.mouse_bandit_journal;
                case "escape_artist":
                    return Properties.Resources.mouse_escape_artist_journal;
                case "impersonator":
                    return Properties.Resources.mouse_impersonator_journal;
                case "lockpick":
                    return Properties.Resources.mouse_lockpick_journal;
                case "rogue":
                    return Properties.Resources.mouse_rogue_journal;
                case "stealth":
                    return Properties.Resources.mouse_stealth_journal;
                case "phanlanx":
                    return Properties.Resources.mouse_phalanx_journal;
                case "page":
                    return Properties.Resources.mouse_page_journal;
                case "berserker":
                    return Properties.Resources.mouse_berserker_journal;
                case "knight":
                    return Properties.Resources.mouse_knight_journal;
                case "fencer":
                    return Properties.Resources.mouse_fencer_journal;
                case "cavalier":
                    return Properties.Resources.mouse_cavalier_journal;
                case "whelpling":
                    return Properties.Resources.mouse_whelpling_journal;
                case "cowbell":
                    return Properties.Resources.mouse_cowbell_journal;
                case "fiddler":
                    return Properties.Resources.mouse_fiddler_journal;
                case "drummer":
                    return Properties.Resources.mouse_drummer_journal;
                case "guqin_player":
                    return Properties.Resources.mouse_guqin_journal;
                case "dancer":
                    return Properties.Resources.mouse_dancer_journal;
                case "cowardly":
                    return Properties.Resources.mouse_cowardly_journal;
                case "pugilist":
                    return Properties.Resources.mouse_pugilist_journal;
                case "aquos":
                    return Properties.Resources.mouse_aquos_journal;
                case "black_mage":
                    return Properties.Resources.mouse_black_mage_journal;
                case "farm_hand":
                    return Properties.Resources.mouse_farmhand_journal;
                case "field":
                    return Properties.Resources.mouse_field_journal;
                case "flying_mouse":
                    return Properties.Resources.mouse_flying_mouse_journal;
                case "ignis":
                    return Properties.Resources.mouse_ignis_journal;
                case "longtail_mouse":
                    return Properties.Resources.mouse_longtail_mouse;
                case "scruffy":
                    return Properties.Resources.mouse_scruffy_journal;
                case "silvertail":
                    return Properties.Resources.mouse_silvertail_journal;
                case "spud":
                    return Properties.Resources.mouse_spud_journal;
                case "terra":
                    return Properties.Resources.mouse_terra_journal;
                case "zephyr":
                    return Properties.Resources.mouse_zephyr_journal;
                case "necromancer":
                    return Properties.Resources.mouse_necromancer_journal;
                case "cherry":
                    return Properties.Resources.mouse_cherry_journal;
                case "eclipse":
                    return Properties.Resources.mouse_eclipse_journal;
                case "fiend":
                    return Properties.Resources.mouse_fiend_journal;
                case "paladin":
                    return Properties.Resources.mouse_paladin_journal;
                case "sacred_shrine":
                    return Properties.Resources.mouse_sacred_shrine_journal;
                case "spotted":
                    return Properties.Resources.mouse_spotted_journal;
                case "white_mage":
                    return Properties.Resources.mouse_white_mage_journal;
                case "lightning_rod":
                    return Properties.Resources.mouse_lightning_rod_journal;
                case "bruticle":
                    return Properties.Resources.mouse_bruticle_journal;
                case "derpicorn":
                    return Properties.Resources.mouse_derpicorn_journal;
                case "firebreather":
                    return Properties.Resources.mouse_firebreather_journal;
                case "firefly":
                    return Properties.Resources.mouse_firefly_journal;
                case "fridgid":
                    return Properties.Resources.mouse_fridgid_journal;
                case "harvest_harrier":
                    return Properties.Resources.mouse_harvest_harrier_journal;
                case "harvester":
                    return Properties.Resources.mouse_harvester_journal;
                case "hot_head_mouse":
                    return Properties.Resources.mouse_hot_head_mouse_journal;
                case "hydrophobe":
                    return Properties.Resources.mouse_hydrophobe_journal;
                case "icicle":
                    return Properties.Resources.mouse_icicle_journal;
                case "monarch":
                    return Properties.Resources.mouse_monarch_journal;
                case "mystic_bishop":
                    return Properties.Resources.mouse_mystic_bishop_journal;
                case "mystic_king":
                    return Properties.Resources.mouse_mystic_king_journal;
                case "mystic_knight":
                    return Properties.Resources.mouse_mystic_knight_journal;
                case "mystic_pawn":
                    return Properties.Resources.mouse_mystic_pawn_journal;
                case "mystic_queen":
                    return Properties.Resources.mouse_mystic_queen_journal;
                case "mystic_rook":
                    return Properties.Resources.mouse_mystic_rook_journal;
                case "overprepared":
                    return Properties.Resources.mouse_overprepared_journal;
                case "penguin":
                    return Properties.Resources.mouse_penguin_journal;
                case "puddlemancer":
                    return Properties.Resources.mouse_puddlemancer_journal;
                case "pumpkin_head":
                    return Properties.Resources.mouse_pumpkin_head_journal;
                case "scarecrow":
                    return Properties.Resources.mouse_scarecrow_journal;
                case "spring_familiar":
                    return Properties.Resources.mouse_spring_familiar_journal;
                case "stinger":
                    return Properties.Resources.mouse_stinger_journal;
                case "summer_mage":
                    return Properties.Resources.mouse_summer_mage_journal;
                case "tech_bishop":
                    return Properties.Resources.mouse_tech_bishop_journal;
                case "tech_king":
                    return Properties.Resources.mouse_tech_king_journal;
                case "tech_knight":
                    return Properties.Resources.mouse_tech_knight_journal;
                case "tech_pawn":
                    return Properties.Resources.mouse_tech_pawn_journal;
                case "tech_queen":
                    return Properties.Resources.mouse_tech_queen_journal;
                case "tech_rook":
                    return Properties.Resources.mouse_tech_rook_journal;
                case "vinetail":
                    return Properties.Resources.mouse_vinetail_journal;
                case "whirleygig":
                    return Properties.Resources.mouse_whirleygig_journal;
                case "tanglefoot":
                    return Properties.Resources.tanglefoot;
                case "gordborg":
                    return Properties.Resources.mouse_gordborg_journal;
                case "realm_guardian":
                    return Properties.Resources.mouse_realm_guardian_journal;
                case "snooty":
                    return Properties.Resources.mouse_snooty_journal;
                case "treasurer":
                    return Properties.Resources.mouse_treasurer_journal;
                case "treat":
                    return Properties.Resources.mouse_treat_journal;
                case "trick":
                    return Properties.Resources.mouse_trick_journal;
                case "zombot_unipire":
                    return Properties.Resources.mouse_zombot_unipire_journal;
            }
            return Properties.Resources.noImg;
        } // End CheckMouseImage

        public static string URLEncode(string StringToEncode, bool UsePlusRatherThanHexForSpace)
        {
            string str = "";
            for (int i = 1; (i - 1) != Strings.Len(StringToEncode); i++)
            {
                int num2 = Strings.Asc(Strings.Mid(StringToEncode, i, 1));
                if ((((num2 >= 0x30) && (num2 <= 0x39)) || ((num2 >= 0x41) && (num2 <= 90))) || ((num2 >= 0x61) && (num2 <= 0x7a)))
                {
                    str = str + Strings.Mid(StringToEncode, i, 1);
                }
                else if (num2 == 0x20)
                {
                    if (UsePlusRatherThanHexForSpace)
                    {
                        str = str + "+";
                    }
                    else
                    {
                        str = str + "%" + Conversion.Hex(0x20);
                    }
                }
                else
                {
                    str = str + "%" + Strings.Format(Conversion.Hex(Strings.Asc(Strings.Mid(StringToEncode, i, 1))), "{00}");
                }
            }
            return str;
        } // End URLEncode

        public static bool login(string username, string password, TextBox txtStatus)
        {
            int status = 0;
            bool isLogin = false;

            txtStatus.Text = "Connecting to Facebook.";

            do
            {
                Thread thread;
                switch (status)
                {

                    case 0:
                        cWeb = new clsWeb("http://www.facebook.com");
                        thread = new Thread(new ThreadStart(cWeb.GetHTTPCookie));
                        thread.Start();
                        do
                        {
                            Application.DoEvents();
                        }
                        while (thread.IsAlive);
                        cCookie = cWeb.Cookie;
                        txtStatus.Text = "Logging in.";
                        if (txtStatus.Text.Equals("Logging in."))
                        {
                            if (status == 0)
                                status++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 1:
                        cWeb = new clsWeb("https://login.facebook.com/login.php?login_attempt=1");


                        //cWeb.sData = "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //            "version=1.0&return_session=0&session_key_only=0&" +
                        //            "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //            "lsd=XOdHU" + "&" +
                        //            "email=" + username + "&" +
                        //            "pass=" + URLEncode(password, true) + "&" +
                        //            "persistent=1";

                        //cWeb.sData = "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //            "version=1.0&return_session=0&session_key_only=0&" +
                        //            "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //            "lsd=XOdHU" + "&" +
                        //            "email=" + username + "&" +
                        //            "pass=" + URLEncode(password, true) + "&" +
                        //            "persistent=1";

                        cWeb.sData = "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                                        "return_session=0&" +
                                        "legacy_return=1&" +
                                        "display=&" +
                                        "session_key_only=0&" +
                                        "trynum=1&" +
                                        "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                                        "lsd=rQ6wM" + "&" +
                                        "email=" + URLEncode(username, true) + "&" +
                                        "pass=" + URLEncode(password, true) + "&" +
                                        "persistent=1&" +
                                        "login=Login";

                        //cWeb.sData = "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //                "locale=en_US&" +
                        //                "email=" + URLEncode(username, true) + "&" +
                        //                "pass=" + URLEncode(password, true) + "&" +
                        //                "persistent=1&" +
                        //                "next=http%3A%2F%2Fapps.facebook.com%2Fmousehunt%2F" + "&" +
                        //                "charset_test=%E2%82%AC%2C%C2%B4%2C%E2%82%AC%2C%C2%B4%2C%E6%B0%B4%2C%D0%94%2C%D0%84&" +
                        //                "lsd=Xh15h";

                        cWeb.Cookie = cCookie;
                        thread = new Thread(new ThreadStart(cWeb.GetCookie));
                        thread.Start();
                        do
                        {
                            Application.DoEvents();
                        }
                        while (thread.IsAlive);
                        cCookie = cWeb.Cookie;
                        if (cCookie == "")
                        {
                            MessageBox.Show(null, "Pikabot was unable to connect to the Internet. Please check your connection and restart Pikabot.", "Login Connection Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Application.Exit();
                        }
                        txtStatus.Text = "Updating status.";
                        if (txtStatus.Text.Equals("Updating status."))
                        {
                            if (status == 1)
                                status++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        cWeb = new clsWeb("http://apps.facebook.com/mousehunt/");
                        //cWeb = new clsWeb("http://www.mousehuntgame.com/canvas/");
                        cWeb.Cookie = cCookie;
                        cWeb.@ref = "http://www.facebook.com/home.php";
                        thread = new Thread(new ThreadStart(cWeb.GetUrl));
                        thread.Start();
                        do
                        {
                            Application.DoEvents();
                        }
                        while (thread.IsAlive);
                        txtStatus.Text = "";
                        
                        if (cWeb.sData.Contains("<title>Hunter&#039;s Camp | MouseHunt on Facebook</title>") || 
                            cWeb.sData.Contains("<title>MouseHunt on Facebook</title>") || 
                            cWeb.sData.Contains("<title>MouseHunt | Hunter&#039;s Camp</title>"))
                        {
                            isLogin = true;
                            HTMLData = cWeb.sData;
                            status = 0;
                            return true;
                        }
                        else
                        {
                            isLogin = false;
                            status = 0;
                            return false;
                        }
                }
            }
            while (!isLogin);

            return isLogin;
        } // End login

        public static string getCurrentTime()
        {
            string timeHour;
            string timeMinute;
            string timeSecond;

            if (int.Parse(DateTime.Now.Hour.ToString()) < 10)
                timeHour = "0" + DateTime.Now.Hour.ToString();
            else
                timeHour = DateTime.Now.Hour.ToString();

            if (int.Parse(DateTime.Now.Minute.ToString()) < 10)
                timeMinute = "0" + DateTime.Now.Minute.ToString();
            else
                timeMinute = DateTime.Now.Minute.ToString();

            if (int.Parse(DateTime.Now.Second.ToString()) < 10)
                timeSecond = "0" + DateTime.Now.Second.ToString();
            else
                timeSecond = DateTime.Now.Second.ToString();

            return timeHour + ":" + timeMinute + ":" + timeSecond;
        }

        public static string readFromFile(string filename)
        {
            string contents;

            try
            {
                StreamReader sr = new StreamReader(filename);
                contents = sr.ReadToEnd();
                sr.Close();
            }
            catch
            {
                contents = "Error retrieving data.";
            }

            return contents;
        }

        public static List<string> readArrayFromFile(string filename)
        {
            List<string> contents = new List<string>();
            string line;

            try
            {
                StreamReader sr = new StreamReader(filename);
                do
                {
                    line = sr.ReadLine();
                    contents.Add(line);
                }
                while (line != null);

                sr.Close();
            }
            catch
            {
                contents.Add("Error retrieving data.");
            }

            return contents;
        }

        public static bool writeToFile(string data, string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                sw.NewLine = Environment.NewLine;
                sw.Write(data);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool writeLineToFile(string data, string filename)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                sw.WriteLine(data);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string formatNumericString(string number)
        {
            string finalstring = "";
            int divRemainder = number.Length % 3;
            int divResult = number.Length / 3;

            if (number.Length > 3)
            {
                if (divRemainder > 0)
                {
                    for (int i = 0; i < divRemainder; i++)
                    {
                        finalstring += number[i].ToString();
                    }
                    number = number.Substring(divRemainder);
                }
                else
                {
                    finalstring += number[0].ToString() + number[1].ToString() + number[2].ToString();
                    number = number.Substring(3);
                }

                finalstring += ",";

                if (divRemainder != 0)
                {
                    for (int i = 0; i < divResult; i++)
                    {
                        finalstring += number[3 * i].ToString() + number[3 * i + 1].ToString() + number[3 * i + 2].ToString();
                        if (i != divResult - 1)
                            finalstring += ",";
                    }
                }
                else
                {
                    for (int i = 0; i < divResult - 1; i++)
                    {
                        finalstring += number[3 * i].ToString() + number[3 * i + 1].ToString() + number[3 * i + 2].ToString();
                        if (i != divResult - 2)
                            finalstring += ",";
                    }
                }
            }
            else
            {
                finalstring = number;
            }

            return finalstring;
        }

        public static void getScreenResolution()
        {
            screenWidth = SystemInformation.PrimaryMonitorSize.Width;
            screenHeight = SystemInformation.PrimaryMonitorSize.Height;
        }

        public static int getPikabotInstance()
        {
            int count = 0;
            Process[] prs = Process.GetProcesses();

            for (int i = 0; i < prs.Length; i++)
            {
                if (prs[i].ProcessName.Equals("Pikabot4"))
                {
                    count++;
                    if (Process.GetCurrentProcess().Id.Equals(prs[i].Id))
                    {
                        processInstance = count;
                    }
                }
            }

            return count;
        }

        public static Point arrangeOpenWindows()
        {
            Point finalCoord = new Point();
            int totalTimes = 1;
            int totalPikaProcesses = getPikabotInstance();

            getScreenResolution();
            int maxBotsHorizontal = screenWidth / 356;
            int maxBotsVertical = screenHeight / 228;

            for (int i = 0; i < maxBotsHorizontal; i++)
            {
                for (int j = 0; j < maxBotsVertical; j++)
                {
                    if (totalTimes == processInstance)
                    {
                        finalCoord.X = i * 356;
                        finalCoord.Y = j * 228;

                        MessageBox.Show(processInstance.ToString());

                        return finalCoord;
                    }

                    totalTimes++;
                }
            }

            return finalCoord;
        }

        public static string getAnnouncement()
        {
            String ann = "";
            try
            {
                ann = getWebDocument(announcementURL);
            }
            catch
            {
                try
                {
                    ann = getWebDocument(announcementURLAlt);
                }
                catch { }
            }

            return ann;
        }

        public static void writeLog(string logdata, string ex, string user)
        {
            string logstr;
            logstr = readFromFile(logFile);
            logstr += Environment.NewLine;
            logstr += DateTime.Now.ToString();
            logstr += " [" + user + "] ";
            logstr += ": ";
            logstr += logdata;
            logstr += Environment.NewLine;
            logstr += "------ Details ------";
            logstr += Environment.NewLine;
            logstr += ex;
            logstr += Environment.NewLine;
            logstr += "---------------------";
            logstr += Environment.NewLine;
            writeToFile(logstr, logFile);
        }

        public static string CalculateSHA1(string text, Encoding enc) 
        { 
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider(); 
            string hash = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", ""); 
            
            return hash; 
        }
    }
}
