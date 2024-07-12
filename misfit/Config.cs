using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace MISFIT
{
    public class Config
    {

        public enum AutoWorkFetchModes
        {
            DISABLED,
            GIMPS,
            GPU72,
            EXTERNAL_COMMAND
        }
        public const int MinEventInterval = 5;
        public const int MinAutoBalance = 3;
        public static int DEFAULT_SMTP_PORT=25;
        private ArrayList _ConfigLookForWorkDirectoryList = new ArrayList();
        private ArrayList _ConfigStartProcessList = new ArrayList();
        private ArrayList _ConfigStopProcessList = new ArrayList();
        private List<string> _ConfigProcessScheduleList = new List<string>();
        //private List<string> _ConfigProcessScheduleList = new List<string> { "*,00:50,UPLOAD_RESULTS", "*,06:50,UPLOAD_RESULTS", "*,12:50,UPLOAD_RESULTS", "*,18:50,UPLOAD_RESULTS" };
        private int _ConfigAutoUpdateStatsMins = 10;
        private string _ConfigLaunchURL = "www.mersenne.org";
        private bool _ConfigShowConfirmationDialogs = true;
        private bool _ConfigShowExportInExternalViewer = true;
        private string _ConfigExportURL = "www.mersenne.org";
        private int _ConfigStartProcessDelaySeconds = 1;
        private bool _ConfigEnableSchedules = true;
        private bool _ConfigSetStartProcessWorkingDirectory = true;
        
        private string _ConfigDebugSection = string.Empty;
        private int _ConfigGIMPSstatsCacheTimeout = 30;
       
        private string _ConfigGIMPSUserID = string.Empty;
        private string _ConfigGIMPSPassword = string.Empty;

        private string _ConfigGPU72UserID = string.Empty;
        private string _ConfigGPU72Password = string.Empty;

        private string _ConfigSMTPUserID = string.Empty;
        private string _ConfigSMTPPassword = string.Empty;

        private int _ConfigAutoBalanceDifferenceTrigger = 0;
        private string _ConfigSMTPServer = string.Empty;
        private int _ConfigSMTPPort = DEFAULT_SMTP_PORT;
        private bool _ConfigSMTPUseTLS = false;
        private bool _ConfigSMTPRequiresAuthentication = false;
        private string _ConfigSMTPFromAddress = string.Empty;
        private string _ConfigSMTPRecipients = string.Empty;
        private bool _ConfigMinimizeToSysTray = false;
        private int _ConfigMinsOldBeforeProcessStallAlarm = 10;
        
        private bool _ConfigStalledProcessSendEmailAlert = false;
        
        private int _ConfigNotifyWhenGHZdaysToDoDropsBelow = 0;
        private bool _ConfigSendEmailWhenLowGHZdaysIsDetected = false;
        private bool _ConfigShowWorkingFactorInPhases = true;
        private int _ConfigAssignWorkWhenGHZdaysToDoDropsBelow = 100;
        private int _ConfigMaxGhDzPerAutoAssignEvent = 75;
        private bool _ConfigWorkFetchExternalCommandEmailResults = false;
        private string _ConfigWorkFetchExternalCommand = string.Empty;
        private string _ConfigWorkFetchExternalCommandArguments = string.Empty;
        private int _ConfigWorkFetchMISFITWorkToDoHoursBetweenChecks = 1;
        private int _ConfigWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz = 250;
        private int _ConfigWorkFetchAssignmentsToFetch = 25;
        private int _ConfigWorkFetchBitLevelTo = Gpu72.DEFAULT_PLEDGE;  // OK FOR UPPING BIT LEVEL FOR GIMPS TOO.
        private bool _ConfigWorkFetchReplaceIdentifierWithDate = true;
        private bool _ConfigWorkFetchGPU72FallBack = true;
        private int _ConfigWorkFetchGPU72GHZdays = 0;
        private int _ConfigWorkFetchMode = (int)AutoWorkFetchModes.DISABLED;

        private int _ConfigWorkFetchGPU72Preference = (int)Gpu72.GPU72WorkOptionsLLTF.WhatMakesSense;
        private int _ConfigWorkFetchGPU72ExponentLow = Gpu72.EXPONENT_MIN;
        private int _ConfigWorkFetchGPU72ExponentHigh = Gpu72.EXPONENT_MAX;
        private int _ConfigWorkFetchGPU72WorkType = (int)Gpu72.GPU72WorkTypes.LLTF;

        private bool _ConfigEmailGlobalWorkStatsBeforeAutoUpload = false;
        private int _ConfigPurgeLogsDaysOld = 31;
        private bool _ConfigDuplicateAssignmentsDetectionIncludeBitLevel = false;
      
        private bool _ConfigProductivityShowAverages = false;

        private string _ConfigEmailSubjectStalledProcess = "MISFIT detected a stalled process!";
        private string _ConfigEmailSubjectExtenralFetchResults = "MISFIT fetch results";
        private string _ConfigEmailSubjectLowGHZDsToDo = "MISFIT detected the work queue is low!";
        private string _ConfigEmailSubjectStats = "MISFIT statistics report";
        private bool _ConfigStartWithStallDetectionSuspended = false;

        private bool _ConfigSendEmailWhenAlertPanelRemainsOpen = false;
        private string _ConfigEmailSubjectAlertPanelRemainsOpen = "MISFIT ALERT PANEL is open!";

        private bool _ConfigSendEmailWhenGIOMPanelRemainsOpen = false;
        private string _ConfigEmailSubjectGIOMPanelRemainsOpen = "MISFIT GIOM PANEL is open!";
        private bool _ConfigHoldBackPartialResults = true;
        private bool _ConfigUseWorkToDoAdd = false;


        //file keywords
        
        private const string DuplicateAssignmentsDetectionIncludeBitLevel = "DuplicateAssignmentsDetectionIncludeBitLevel:";
        private const string Lookin="Lookin:";
        private const string StartExtProcessName = "StartExtProcessName:";
        private const string StopExtProcessName = "StopExtProcessName:";
        private const string LaunchURLonExport = "LaunchURLonExport:";
        private const string AutoUpdateStatsMins = "AutoUpdateStatsMins:";
        private const string AutoShutdownDelayMins = "AutoShutdownDelayMins:";
        private const string SetExtProcessWorkingDirectoryToGivenPath = "SetExtProcessWorkingDirectoryToGivenPath:";
        private const string StartExtProcessDelay = "StartExtProcessDelay:";
        private const string Scheduler = "Scheduler:";
        private const string LaunchURL = "LaunchURL:";
        private const string ShowConfirmationDialogs = "ShowConfirmationDialogs:";
        private const string ShowExportResultsInExternalFileViewer = "ShowExportResultsInExternalFileViewer:";
        private const string EnableSchedules = "EnableSchedules:";
        private const string GimpsStatsCacheTimeout = "GimpsStatsCacheTimeout:";
        private const string GIMPSUserID = "GIMPSUserID:";
        private const string GIMPSPassword = "GIMPSPassword:";
        private const string AutoBalanceDifferenceTrigger = "AutoBalanceDifferenceTrigger:";
        public const string SMTPServer = "SMTPServer:";
        public const string SMTPPort = "SMTPPort:";
        public const string SMTPUserID="SMTPUserID:";
        public const string SMTPPassword = "SMTPPassword:";
        public const string SMTPUseTLS="SMTPUseTLS:";
        public const string SMTPRequiresAuthentication = "SMTPRequiresAuthentication:";
        public const string SMTPFromAddress = "SMTPFromAddress:";
        public const string SMTPRecipients = "SMTPRecipients:";
        public const string MinsOldBeforeProcessStallAlarm = "MinsOldBeforeProcessStallAlarm:";
        public const string StalledProcessSendEmailAlert = "StalledProcessSendEmailAlert:";
        public const string MinimizeToSysTray = "MinimizeToSysTray:";
        
        public const string NotifyWhenGHZdaysToDoDropsBelow = "NotifyWhenGHZdaysToDoDropsBelow:";
        public const string SendEmailWhenLowGHZdaysIsDetected = "SendEmailWhenLowGHZdaysIsDetected:";
        public const string ShowWorkingFactorInPhases = "ShowWorkingFactorInPhases:";
        public const string AssignWorkWhenGHZdaysToDoDropsBelow = "AssignWorkWhenGHZdaysToDoDropsBelow:";
        public const string MaxGhDzPerAutoAssignEvent = "MaxGhDzPerAutoAssignEvent:";
        public const string WorkFetchExternalCommand = "WorkFetchExternalCommand:";
        public const string WorkFetchExternalCommandArguments = "WorkFetchExternalCommandArguments:";
        public const string WorkFetchExternalCommandEmailResults = "WorkFetchExternalCommandEmailResults:";
        public const string WorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz = "WorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz:";
        public const string WorkFetchAssignmentsToFetch = "WorkFetchAssignmentsToFetch:";
        public const string WorkFetchBitLevelTo = "WorkFetchBitLevelTo:";
        public const string WorkFetchReplaceIdentifierWithDate = "WorkFetchReplaceIdentifierWithDate:";
        public const string WorkFetchMode = "WorkFetchMode:";
        public const string GPU72UserID = "GPU72UserID:";
        public const string GPU72Password = "GPU72Password:";
        public const string WorkFetchGPU72Preference = "WorkFetchGPU72Preference:";
        public const string WorkFetchGPU72ExponentLow = "WorkFetchGPU72ExponentLow:";
        public const string WorkFetchGPU72ExponentHigh = "WorkFetchGPU72ExponentHigh:";
        public const string WorkFetchGPU72FallBack = "WorkFetchGPU72FallBack:";
        public const string WorkFetchGPU72WorkType="WorkFetchGPU72WorkType:";
        public const string WorkFetchGPU72GHZdays = "WorkFetchGPU72GHZdays:";
        public const string WorkFetchMISFITWorkToDoHoursBetweenChecks = "WorkFetchMISFITWorkToDoHoursBetweenChecks:";
        public const string EmailGlobalWorkStatsBeforeAutoUpload = "EmailGlobalWorkStatsBeforeAutoUpload:";
        public const string PurgeLogsDaysOld = "PurgeLogsDaysOld:";
        public const string AlertONResultsNotNeeded = "AlertONResultsNotNeeded:";
        private const string ProductivityShowAverages = "ProductivityShowAverages:";

        private const string EmailSubjectStalledProcess = "EmailSubjectStalledProcess:";
        private const string EmailSubjectExtenralFetchResults = "EmailSubjectExtenralFetchResults:";
        private const string EmailSubjectLowGHZDsToDo = "EmailSubjectLowGHZDsToDo:";
        private const string EmailSubjectStats = "EmailSubjectStats:";
        private const string StartWithStallDetectionSuspended = "StartWithStallDetectionSuspended:";

        private const string SendEmailWhenAlertPanelRemainsOpen = "SendEmailWhenAlertPanelRemainsOpen:";
        private const string EmailSubjectAlertPanelRemainsOpen = "EmailSubjectAlertPanelRemainsOpen:";

        private const string SendEmailWhenGIOMPanelRemainsOpen = "SendEmailWhenGIOMPanelRemainsOpen:";
        private const string EmailSubjectGIOMPanelRemainsOpen = "EmailSubjectGIOMPanelRemainsOpen:";
        private const string HoldBackPartialResults = "HoldBackPartialResults:";
        private const string UseWorkToDoAdd = "UseWorkToDoAdd:";


        public bool settingUseWorkToDoAdd
        {

            set
            {

                this._ConfigUseWorkToDoAdd = value;
            }
            get
            {

                return this._ConfigUseWorkToDoAdd;
            }
        }



        public bool settingHoldBackPartialResults
        {

            set
            {

                this._ConfigHoldBackPartialResults = value;
            }
            get
            {

                return this._ConfigHoldBackPartialResults;
            }
        }


        public bool settingSendEmailWhenAlertPanelRemainsOpen
        {

            set
            {

                this._ConfigSendEmailWhenAlertPanelRemainsOpen = value;
            }
            get
            {

                return this._ConfigSendEmailWhenAlertPanelRemainsOpen;
            }
        }


        public string settingEmailSubjectAlertPanelRemainsOpen
        {

            set
            {

                this._ConfigEmailSubjectAlertPanelRemainsOpen = value;
            }
            get
            {

                return this._ConfigEmailSubjectAlertPanelRemainsOpen;
            }
        }


        public bool settingSendEmailWhenGIOMPanelRemainsOpen
        {

            set
            {

                this._ConfigSendEmailWhenGIOMPanelRemainsOpen = value;
            }
            get
            {

                return this._ConfigSendEmailWhenGIOMPanelRemainsOpen;
            }
        }


        public string settingEmailSubjectGIOMPanelRemainsOpen
        {

            set
            {

                this._ConfigEmailSubjectGIOMPanelRemainsOpen = value;
            }
            get
            {

                return this._ConfigEmailSubjectGIOMPanelRemainsOpen;
            }
        }





        public bool settingStartWithStallDetectionSuspended
        {

            set
            {

                this._ConfigStartWithStallDetectionSuspended = value;
            }
            get
            {

                return this._ConfigStartWithStallDetectionSuspended;
            }
        }

        public string settingEmailSubjectStats
        {
            set
            {
                this._ConfigEmailSubjectStats = value;
            }
            get
            {
                return this._ConfigEmailSubjectStats;
            }
        }




        public string settingEmailSubjectLowGHZDsToDo
        {
            set
            {
                this._ConfigEmailSubjectLowGHZDsToDo = value;
            }
            get
            {
                return this._ConfigEmailSubjectLowGHZDsToDo;
            }
        }



        public string settingEmailSubjectExtenralFetchResults
        {
            set
            {
                this._ConfigEmailSubjectExtenralFetchResults = value;
            }
            get
            {
                return this._ConfigEmailSubjectExtenralFetchResults;
            }
        }



        public string settingEmailSubjectStalledProcess
        {
            set
            {
                this._ConfigEmailSubjectStalledProcess = value;
            }
            get
            {
                return this._ConfigEmailSubjectStalledProcess;
            }
        }


        public bool settingProductivityShowAverages
        {
            set
            {
                this._ConfigProductivityShowAverages = value;
            }
            get
            {
                return this._ConfigProductivityShowAverages;
            }

        }



       


        public bool settingDuplicateAssignmentsDetectionIncludeBitLevel
        {
            set
            {
                this._ConfigDuplicateAssignmentsDetectionIncludeBitLevel = value;
            }
            get
            {
                return this._ConfigDuplicateAssignmentsDetectionIncludeBitLevel;
            }

        }




        public int settingPurgeLogsDaysOld
        {
            set
            {
                this._ConfigPurgeLogsDaysOld = value;
            }
            get
            {
                return this._ConfigPurgeLogsDaysOld;
            }

        }

        public bool settingEmailGlobalWorkStatsBeforeWorkFetch
        {
            set
            {
                this._ConfigEmailGlobalWorkStatsBeforeAutoUpload = value;
            }
            get
            {
                return this._ConfigEmailGlobalWorkStatsBeforeAutoUpload;
            }

        }






        public int settingWorkFetchMISFITWorkToDoHoursBetweenChecks
        {
            set
            {
                this._ConfigWorkFetchMISFITWorkToDoHoursBetweenChecks = value;
            }
            get
            {
                return this._ConfigWorkFetchMISFITWorkToDoHoursBetweenChecks;
            }

        }


        public bool settingWorkFetchGPU72FallBack
        {

            set
            {
                this._ConfigWorkFetchGPU72FallBack = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72FallBack;
            }
        }



        public int settingWorkFetchGPU72UseGHZdays
        {
            set
            {
                this._ConfigWorkFetchGPU72GHZdays = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72GHZdays;
            }

        }


        public int settingWorkFetchGPU72ExponentHigh
        {
            set
            {
                this._ConfigWorkFetchGPU72ExponentHigh = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72ExponentHigh;
            }

        }


        public int settingWorkFetchGPU72ExponentLow
        {
            set
            {
                this._ConfigWorkFetchGPU72ExponentLow = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72ExponentLow;
            }

        }


        public int settingWorkFetchGPU72WorkType
        {
            set
            {
                this._ConfigWorkFetchGPU72WorkType = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72WorkType;
            }

        }


        public int settingWorkFetchGPU72Preference
        {
            set
            {
                this._ConfigWorkFetchGPU72Preference = value;
            }
            get
            {
                return this._ConfigWorkFetchGPU72Preference;
            }

        }


        public string settingGPU72UserID
        {
            set
            {
                this._ConfigGPU72UserID = value;
            }
            get
            {
                return this._ConfigGPU72UserID;
            }

        }



        public string settingGPU72Password
        {
            set
            {
                this._ConfigGPU72Password = value;
            }
            get
            {
                return this._ConfigGPU72Password;
            }

        }



        public int settingWorkFetchMode
        {
            set
            {
                this._ConfigWorkFetchMode = value;
            }
            get
            {
                return this._ConfigWorkFetchMode;
            }
        }



        public int settingWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz
        {
            set
            {
                this._ConfigWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz = value;
            }
            get
            {
                return this._ConfigWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz;
            }
        }

        public int settingWorkFetchAssignmentsToFetch
        {
            set
            {
                this._ConfigWorkFetchAssignmentsToFetch = value;
            }
            get
            {
                return this._ConfigWorkFetchAssignmentsToFetch;
            }
        }


        public int settingWorkFetchBitLevelTo
        {
            set
            {
                this._ConfigWorkFetchBitLevelTo = value;
            }
            get
            {
                return this._ConfigWorkFetchBitLevelTo;
            }
        }



        public bool settingWorkFetchReplaceIdentifierWithDate
        {
            set
            {
                this._ConfigWorkFetchReplaceIdentifierWithDate = value;
            }
            get
            {
                return this._ConfigWorkFetchReplaceIdentifierWithDate;
            }
        }



        public bool settingEmailPreAssignRunResult
        {
            set
            {
                this._ConfigWorkFetchExternalCommandEmailResults = value;
            }
            get
            {
                return this._ConfigWorkFetchExternalCommandEmailResults;

            }
        }


        public string settingWorkFetchExternalCommand
        {
            set
            {
                this._ConfigWorkFetchExternalCommand = value;
            }
            get
            {
                return this._ConfigWorkFetchExternalCommand;
            }

        }


        public string settingWorkFetchExternalCommandArguments
        {
            set
            {
                this._ConfigWorkFetchExternalCommandArguments = value;
            }
            get
            {
                return this._ConfigWorkFetchExternalCommandArguments;
            }

        }



        public int settingAssignWorkWhenGHZdaysToDoDropsBelow
        {
            set
            {
                this._ConfigAssignWorkWhenGHZdaysToDoDropsBelow = value;
            }
            get
            {
                return this._ConfigAssignWorkWhenGHZdaysToDoDropsBelow;
            }

        }


        public int settingMaxGhDzPerAutoAssignEvent
        {
            set
            {
                this._ConfigMaxGhDzPerAutoAssignEvent = value;
            }
            get
            {
                return this._ConfigMaxGhDzPerAutoAssignEvent;
            }

        }

       



        public bool settingShowWorkingFactorInPhases
        {
            set
            {
                this._ConfigShowWorkingFactorInPhases = value;
                
            }
            get
            {
                return this._ConfigShowWorkingFactorInPhases;
            }
        }



        public bool SchedulerHasEventsOfType(string eventName)
        {

            bool result = false;

            foreach (string s in _ConfigProcessScheduleList)
            {
                if (s.Contains(eventName))
                {
                    result = true;
                    break;
                }

            }

            return result;
        }


        public int settingNotifyWhenGHZdaysToDoDropsBelow
        {
            set
            {
                this._ConfigNotifyWhenGHZdaysToDoDropsBelow = value;
            }
            get
            {
                return this._ConfigNotifyWhenGHZdaysToDoDropsBelow;
            }
        }



        public bool settingSendEmailWhenLowGHZdaysIsDetected
        {
            set
            {
                this._ConfigSendEmailWhenLowGHZdaysIsDetected = value;
            }
            get
            {
                return this._ConfigSendEmailWhenLowGHZdaysIsDetected;
            }
        }


       

        public bool settingStalledProcessSendEmailAlert
        {
            set
            {
                this._ConfigStalledProcessSendEmailAlert = value;
            }
            get
            {
                return this._ConfigStalledProcessSendEmailAlert;
            }

        }
        public int settingMinsOldBeforeProcessStallAlarm
        {
            set
            {
                this._ConfigMinsOldBeforeProcessStallAlarm = value;
            }
            get
            {
                return this._ConfigMinsOldBeforeProcessStallAlarm;
            }
        }


       


        public bool settingMinimizeToSysTray
        {
            set
            {
                this._ConfigMinimizeToSysTray = value;
            }
            get
            {
                return this._ConfigMinimizeToSysTray;
            }
        }
        
        
        
        
        
        public string settingSMTPServer
        {
            set
            {
                this._ConfigSMTPServer = value;
            }
            get
            {
                return this._ConfigSMTPServer;
            }
        }


        public int settingSMTPPort
        {
            set
            {
                this._ConfigSMTPPort = value;
            }
            get
            {
                return this._ConfigSMTPPort;
            }
        }

        public string settingSMTPUserID
        {
            set
            {
                this._ConfigSMTPUserID = value;
            }
            get
            {
                return this._ConfigSMTPUserID;
            }
        }

        public string settingSMTPPassword
        {
            set
            {
                this._ConfigSMTPPassword = value;
            }
            get
            {
                return this._ConfigSMTPPassword;
            }
        }


        public bool settingSMTPUseTLS
        {
            set
            {
                this._ConfigSMTPUseTLS = value;
            }
            get
            {
                return this._ConfigSMTPUseTLS;
            }
        }


        public bool settingSMTPRequiresAuthentication
        {
            set
            {
                this._ConfigSMTPRequiresAuthentication = value;
            }
            get
            {
                return this._ConfigSMTPRequiresAuthentication;
            }
        }

        public string settingSMTPFromAddress
        {
            set
            {
                this._ConfigSMTPFromAddress = value;
            }
            get
            {
                return this._ConfigSMTPFromAddress;
            }
        }

        public string settingSMTPRecipients
        {
            set
            {
                this._ConfigSMTPRecipients = value;
            }
            get
            {
                return this._ConfigSMTPRecipients;
            }
        }



        public int settingAutoBalanceDifferenceTrigger
        {

            set
            {
                this._ConfigAutoBalanceDifferenceTrigger = value;
            }
            get
            {
                return this._ConfigAutoBalanceDifferenceTrigger;
           
            }
        }
       


       
        public string settingGIMPSUserID
        {
            set
            {
                this._ConfigGIMPSUserID = value;
            }
            get
            {
                return this._ConfigGIMPSUserID;
            }

        }


        public string settingGIMPSPassword
        {
            set
            {
                this._ConfigGIMPSPassword = value;
            }
            get
            {
                return this._ConfigGIMPSPassword;
            }

        }



        public int settingGimpsStatsCacheTimeout
        {
            set
            {
                this._ConfigGIMPSstatsCacheTimeout = value;
            }
            get
            {
                return this._ConfigGIMPSstatsCacheTimeout;
            }


        }

        public int settingStartProcessDelay
        {
            set
            {

                this._ConfigStartProcessDelaySeconds=value;
            }
            get
            {
                return this._ConfigStartProcessDelaySeconds;
            }


        }

        public bool settingEnableSchedules
        {
            set
            {
                this._ConfigEnableSchedules = value;
            }
            get
            {
                return this._ConfigEnableSchedules;
            }
        }


        public bool settingShowExportInExternalViewer
        {
            set
            {
                this._ConfigShowExportInExternalViewer = value;
            }
            get
            {
                return this._ConfigShowExportInExternalViewer;
            }
        }

        public bool settingShowConfirmationDialogs
        {
            set
            {
                this._ConfigShowConfirmationDialogs = value;
            }
            get
            {
                return this._ConfigShowConfirmationDialogs;
            }
        }
        
        
        public bool settingSetProcessWorkingDirectory
        {
            set
            {
                this._ConfigSetStartProcessWorkingDirectory = value;
            }

            get
            {
                return this._ConfigSetStartProcessWorkingDirectory;
            }

        }

        
        public List<string> settingProcessScheduleList
        {

            set
            {
                this._ConfigProcessScheduleList = value;
                //this._ConfigProcessScheduleList.Sort();
            }
            get
            {
                return this._ConfigProcessScheduleList;
            }

        }

        public ArrayList settingStopProcessList
        {
            set
            {
                this._ConfigStopProcessList = value;
            }
            get
            {
                return this._ConfigStopProcessList;
            }


        }
        
                
        public ArrayList settingStartProcessList
        {
            set
            {
                this._ConfigStartProcessList = value;
                
            }
            get
            {
                return this._ConfigStartProcessList;
            }

        }

      


        public int settingUpdateStatsInterval
        {
            set 
            {
               this._ConfigAutoUpdateStatsMins = value;
            }

            get
            {
                return this._ConfigAutoUpdateStatsMins;
            }
            

        }


        public ArrayList settingFactoringDirectories
        {
            set
            {
                this._ConfigLookForWorkDirectoryList = value;

            }
            get
            {
                return this._ConfigLookForWorkDirectoryList;
            }
        }




        public string settingLaunchURL
        {
            set
            {
                this._ConfigLaunchURL = value;
            }
            get
            {

                return this._ConfigLaunchURL;
            }

        }


        public string settingExportURL
        {
            set
            {
                this._ConfigExportURL = value;
            }
            get
            {
                return this._ConfigExportURL;
            }



        }


       


        public bool SaveConfigurationToFile(string ConfigFile)
        {
            bool result = true;
            //const string crlf = "\r\n";
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(LaunchURLonExport + this._ConfigExportURL);
                sb.AppendLine(LaunchURL + this._ConfigLaunchURL);
                sb.AppendLine(AutoUpdateStatsMins + this._ConfigAutoUpdateStatsMins.ToString());
            
                sb.AppendLine(SetExtProcessWorkingDirectoryToGivenPath + this._ConfigSetStartProcessWorkingDirectory.ToString());
                sb.AppendLine(StartExtProcessDelay + this._ConfigStartProcessDelaySeconds.ToString());
                sb.AppendLine(GimpsStatsCacheTimeout + this._ConfigGIMPSstatsCacheTimeout.ToString());
                sb.AppendLine(ShowConfirmationDialogs + this._ConfigShowConfirmationDialogs.ToString()); 
                sb.AppendLine(ShowExportResultsInExternalFileViewer + this._ConfigShowExportInExternalViewer.ToString());
                sb.AppendLine(EnableSchedules + this._ConfigEnableSchedules.ToString());
                sb.AppendLine(GIMPSUserID + this._ConfigGIMPSUserID);
                sb.AppendLine(GIMPSPassword + Crypto.Encrypt(this._ConfigGIMPSPassword, Globals.MISFITCRYPTO_KEY()));
                
                sb.AppendLine(AutoBalanceDifferenceTrigger + this._ConfigAutoBalanceDifferenceTrigger.ToString());
                sb.AppendLine(SMTPServer + this._ConfigSMTPServer);
                sb.AppendLine(SMTPPort + this._ConfigSMTPPort.ToString());
                sb.AppendLine(SMTPUserID + this._ConfigSMTPUserID);
                sb.AppendLine(SMTPPassword + Crypto.Encrypt(this._ConfigSMTPPassword, Globals.MISFITCRYPTO_KEY()));
                sb.AppendLine(SMTPUseTLS + this._ConfigSMTPUseTLS);
                sb.AppendLine(SMTPRequiresAuthentication + this._ConfigSMTPRequiresAuthentication.ToString());
                sb.AppendLine(SMTPFromAddress + this._ConfigSMTPFromAddress);
                sb.AppendLine(SMTPRecipients + this._ConfigSMTPRecipients);
                sb.AppendLine(MinimizeToSysTray + this._ConfigMinimizeToSysTray.ToString());
                sb.AppendLine(MinsOldBeforeProcessStallAlarm + this._ConfigMinsOldBeforeProcessStallAlarm.ToString());
                sb.AppendLine(StalledProcessSendEmailAlert + this._ConfigStalledProcessSendEmailAlert.ToString());
                
                sb.AppendLine(NotifyWhenGHZdaysToDoDropsBelow + this._ConfigNotifyWhenGHZdaysToDoDropsBelow.ToString());
                sb.AppendLine(SendEmailWhenLowGHZdaysIsDetected + this._ConfigSendEmailWhenLowGHZdaysIsDetected.ToString());
                sb.AppendLine(ShowWorkingFactorInPhases + this._ConfigShowWorkingFactorInPhases.ToString());
                sb.AppendLine(AssignWorkWhenGHZdaysToDoDropsBelow + this._ConfigAssignWorkWhenGHZdaysToDoDropsBelow.ToString());
                sb.AppendLine(MaxGhDzPerAutoAssignEvent + this._ConfigMaxGhDzPerAutoAssignEvent.ToString());
                sb.AppendLine(WorkFetchExternalCommand + this._ConfigWorkFetchExternalCommand);
                sb.AppendLine(WorkFetchExternalCommandArguments + this._ConfigWorkFetchExternalCommandArguments);
                sb.AppendLine(WorkFetchExternalCommandEmailResults + this._ConfigWorkFetchExternalCommandEmailResults.ToString());
                sb.AppendLine(WorkFetchMISFITWorkToDoHoursBetweenChecks + this._ConfigWorkFetchMISFITWorkToDoHoursBetweenChecks.ToString());
                sb.AppendLine(WorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz + this._ConfigWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz.ToString());
                sb.AppendLine(WorkFetchAssignmentsToFetch + this._ConfigWorkFetchAssignmentsToFetch.ToString());
                sb.AppendLine(WorkFetchBitLevelTo + this._ConfigWorkFetchBitLevelTo.ToString());
                sb.AppendLine(WorkFetchReplaceIdentifierWithDate + this._ConfigWorkFetchReplaceIdentifierWithDate.ToString());
                sb.AppendLine(WorkFetchMode + this._ConfigWorkFetchMode.ToString());
                sb.AppendLine(GPU72UserID + this._ConfigGPU72UserID);
                sb.AppendLine(GPU72Password + Crypto.Encrypt(this._ConfigGPU72Password, Globals.MISFITCRYPTO_KEY()));
                sb.AppendLine(WorkFetchGPU72WorkType + this._ConfigWorkFetchGPU72WorkType.ToString());
                sb.AppendLine(WorkFetchGPU72Preference + this._ConfigWorkFetchGPU72Preference.ToString());
                sb.AppendLine(WorkFetchGPU72ExponentLow + this._ConfigWorkFetchGPU72ExponentLow.ToString());
                sb.AppendLine(WorkFetchGPU72ExponentHigh + this._ConfigWorkFetchGPU72ExponentHigh.ToString());
                sb.AppendLine(WorkFetchGPU72FallBack + this._ConfigWorkFetchGPU72FallBack.ToString());
                sb.AppendLine(WorkFetchGPU72GHZdays + this._ConfigWorkFetchGPU72GHZdays.ToString());
                sb.AppendLine(EmailGlobalWorkStatsBeforeAutoUpload + this._ConfigEmailGlobalWorkStatsBeforeAutoUpload.ToString());
                sb.AppendLine(PurgeLogsDaysOld + this._ConfigPurgeLogsDaysOld.ToString());
                sb.AppendLine(DuplicateAssignmentsDetectionIncludeBitLevel + this._ConfigDuplicateAssignmentsDetectionIncludeBitLevel.ToString());
                
                sb.AppendLine(ProductivityShowAverages + this._ConfigProductivityShowAverages.ToString());
                sb.AppendLine(EmailSubjectExtenralFetchResults + this._ConfigEmailSubjectExtenralFetchResults);
                sb.AppendLine(EmailSubjectLowGHZDsToDo + this._ConfigEmailSubjectLowGHZDsToDo);
                sb.AppendLine(EmailSubjectStalledProcess + this._ConfigEmailSubjectStalledProcess);
                sb.AppendLine(EmailSubjectStats + this._ConfigEmailSubjectStats);
                sb.AppendLine(StartWithStallDetectionSuspended + this._ConfigStartWithStallDetectionSuspended.ToString());
                sb.AppendLine(EmailSubjectAlertPanelRemainsOpen + this._ConfigEmailSubjectAlertPanelRemainsOpen);
                sb.AppendLine(SendEmailWhenAlertPanelRemainsOpen + this._ConfigSendEmailWhenAlertPanelRemainsOpen.ToString());
                sb.AppendLine(EmailSubjectGIOMPanelRemainsOpen + this._ConfigEmailSubjectGIOMPanelRemainsOpen);
                sb.AppendLine(SendEmailWhenGIOMPanelRemainsOpen + this._ConfigSendEmailWhenGIOMPanelRemainsOpen.ToString());
                sb.AppendLine(HoldBackPartialResults + this._ConfigHoldBackPartialResults.ToString());
                sb.AppendLine(UseWorkToDoAdd + this._ConfigUseWorkToDoAdd.ToString());

                
            



                foreach (string item in this._ConfigLookForWorkDirectoryList)
                {
                    sb.AppendLine(Lookin + item);
                }


                foreach (string item in this._ConfigStartProcessList)
                {
                    sb.AppendLine(StartExtProcessName + item);
                }

                foreach (string item in this._ConfigStopProcessList)
                {
                    sb.AppendLine(StopExtProcessName + item);
                }


                foreach (string item in this._ConfigProcessScheduleList)
                {
                    sb.AppendLine(Scheduler + item);
                }

                File.WriteAllText(ConfigFile, sb.ToString());
               


            }
            catch (Exception E)
            {
                Globals.simpleMessageBox("Error during save of configuration\r\n" + E.Message);
                result = false;
            }

            return result;
        }


        public bool isExportToGIMPSEnabled()
        {

            bool answer = false;
            if (this.settingGIMPSUserID.Length > 0 && this.settingGIMPSPassword.Length > 0 &&  SchedulerHasEventsOfType("UPLOAD_RESULTS") && this._ConfigEnableSchedules)
            {
                answer = true;
            }
            return answer;
        }

        public bool isEmailConfigured()
        {
            bool answer = false;
            if (this.settingSMTPFromAddress.Length > 0 && this.settingSMTPRecipients.Length > 0 && this.settingSMTPServer.Length > 0)
                answer = true;
            return answer;
        }
        public bool isGIMPScredentialsConfigured()
        {
            bool answer = false;
            if (this.settingGIMPSUserID.Length > 0 && this.settingGIMPSPassword.Length > 0)
                answer = true;
            return answer;
        }

        public bool isGPU72credentialsConfigured()
        {
            bool answer = false;
            if (this.settingGPU72UserID.Length > 0 && this.settingGPU72Password.Length > 0)
                answer = true;
            return answer;
        }



        public bool LoadConfigurationFromFile(string ConfigFile)
        {
            bool result = true;
            string[] configFileLines;
            string trimmedLine = string.Empty;
            StringBuilder sbz = new StringBuilder();
            try
            {

                configFileLines = File.ReadAllLines(ConfigFile);

                foreach (string line in configFileLines)
                {
                    trimmedLine = line.Trim();
                    try
                    {



                        _ConfigDebugSection = UseWorkToDoAdd;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigUseWorkToDoAdd = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        
                        _ConfigDebugSection = HoldBackPartialResults;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigHoldBackPartialResults = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = SendEmailWhenGIOMPanelRemainsOpen;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSendEmailWhenGIOMPanelRemainsOpen = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = EmailSubjectGIOMPanelRemainsOpen;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectGIOMPanelRemainsOpen = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = SendEmailWhenAlertPanelRemainsOpen;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSendEmailWhenAlertPanelRemainsOpen = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = EmailSubjectAlertPanelRemainsOpen;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectAlertPanelRemainsOpen = trimmedLine.Substring(_ConfigDebugSection.Length);



                        _ConfigDebugSection = StartWithStallDetectionSuspended;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigStartWithStallDetectionSuspended = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = EmailSubjectStalledProcess;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectStalledProcess =trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = EmailSubjectStats;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectStats = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = EmailSubjectLowGHZDsToDo;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectLowGHZDsToDo = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = EmailSubjectExtenralFetchResults;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailSubjectExtenralFetchResults = trimmedLine.Substring(_ConfigDebugSection.Length);


                        _ConfigDebugSection = ProductivityShowAverages;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigProductivityShowAverages = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));





                      

                        _ConfigDebugSection = DuplicateAssignmentsDetectionIncludeBitLevel;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigDuplicateAssignmentsDetectionIncludeBitLevel = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        





                        _ConfigDebugSection = PurgeLogsDaysOld;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigPurgeLogsDaysOld = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length)); 
                        


                        _ConfigDebugSection = WorkFetchGPU72WorkType;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72WorkType = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        

                         _ConfigDebugSection = WorkFetchGPU72FallBack;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72FallBack = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        

                        _ConfigDebugSection = EmailGlobalWorkStatsBeforeAutoUpload;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEmailGlobalWorkStatsBeforeAutoUpload = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        

                        _ConfigDebugSection = WorkFetchMISFITWorkToDoHoursBetweenChecks;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchMISFITWorkToDoHoursBetweenChecks = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));



                        _ConfigDebugSection = WorkFetchGPU72GHZdays;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72GHZdays = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));



                        _ConfigDebugSection = WorkFetchGPU72ExponentHigh;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72ExponentHigh = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = WorkFetchGPU72ExponentLow;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72ExponentLow = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        
                        
                        _ConfigDebugSection = WorkFetchGPU72Preference;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchGPU72Preference = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = GPU72UserID;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigGPU72UserID = trimmedLine.Substring(_ConfigDebugSection.Length);


                        _ConfigDebugSection = GPU72Password;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            this._ConfigGPU72Password = trimmedLine.Substring(_ConfigDebugSection.Length);
                            try
                            {
                                this._ConfigGPU72Password = Crypto.Decrypt(this._ConfigGPU72Password, Globals.MISFITCRYPTO_KEY());
                            }
                            catch
                            {
                                this._ConfigGPU72Password = string.Empty;
                                Globals.simpleMessageBox("GPU72 Password could not be decrypted\r\nUse Configuration Editor to re-encrypt");
                            }
                        }



                      
                        _ConfigDebugSection = WorkFetchMode;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchMode =  int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = WorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchWhenRemainingMISFITWorkToDoDropsBelowGhDz = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = WorkFetchAssignmentsToFetch;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchAssignmentsToFetch = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = WorkFetchBitLevelTo;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchBitLevelTo = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = WorkFetchReplaceIdentifierWithDate;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchReplaceIdentifierWithDate = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));



                        _ConfigDebugSection = WorkFetchExternalCommandEmailResults;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                             this._ConfigWorkFetchExternalCommandEmailResults = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));






                        _ConfigDebugSection = WorkFetchExternalCommand;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchExternalCommand = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = WorkFetchExternalCommandArguments;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigWorkFetchExternalCommandArguments = trimmedLine.Substring(_ConfigDebugSection.Length);



                        _ConfigDebugSection = AssignWorkWhenGHZdaysToDoDropsBelow;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigAssignWorkWhenGHZdaysToDoDropsBelow = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = MaxGhDzPerAutoAssignEvent;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigMaxGhDzPerAutoAssignEvent = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                       
                        
                        _ConfigDebugSection = ShowWorkingFactorInPhases;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigShowWorkingFactorInPhases = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                        

                        _ConfigDebugSection = NotifyWhenGHZdaysToDoDropsBelow;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigNotifyWhenGHZdaysToDoDropsBelow = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = SendEmailWhenLowGHZdaysIsDetected;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSendEmailWhenLowGHZdaysIsDetected = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                       

                        _ConfigDebugSection = MinsOldBeforeProcessStallAlarm;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigMinsOldBeforeProcessStallAlarm = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));



                       

                        _ConfigDebugSection = StalledProcessSendEmailAlert;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigStalledProcessSendEmailAlert = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));




                        _ConfigDebugSection = MinimizeToSysTray;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigMinimizeToSysTray = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));



                        _ConfigDebugSection = SMTPServer;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPServer = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = SMTPPort;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPPort = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));




                        _ConfigDebugSection = SMTPUserID;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPUserID = trimmedLine.Substring(_ConfigDebugSection.Length);


                        _ConfigDebugSection = SMTPPassword;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            this._ConfigSMTPPassword = trimmedLine.Substring(_ConfigDebugSection.Length);
                            try
                            {
                                this._ConfigSMTPPassword = Crypto.Decrypt(this._ConfigSMTPPassword, Globals.MISFITCRYPTO_KEY());
                            }catch
                            {
                                this._ConfigSMTPPassword = string.Empty;
                                Globals.simpleMessageBox("SMTP Password could not be decrypted\r\nUse Configuration Editor to re-encrypt");
                            }
                        }

                        _ConfigDebugSection = SMTPUseTLS;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPUseTLS = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = SMTPRequiresAuthentication;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPRequiresAuthentication = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = SMTPFromAddress;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPFromAddress = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = SMTPRecipients;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSMTPRecipients = trimmedLine.Substring(_ConfigDebugSection.Length);


                        _ConfigDebugSection = LaunchURL;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigLaunchURL = trimmedLine.Substring(_ConfigDebugSection.Length);


                        _ConfigDebugSection = LaunchURLonExport;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigExportURL = trimmedLine.Substring(_ConfigDebugSection.Length);

                        _ConfigDebugSection = GIMPSUserID;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigGIMPSUserID = trimmedLine.Substring(_ConfigDebugSection.Length);





                        _ConfigDebugSection = GIMPSPassword; ;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            this._ConfigGIMPSPassword = trimmedLine.Substring(_ConfigDebugSection.Length);
                            try
                            {
                                this._ConfigGIMPSPassword = Crypto.Decrypt(this._ConfigGIMPSPassword, Globals.MISFITCRYPTO_KEY());
                            }
                            catch
                            {
                                this._ConfigGIMPSPassword = string.Empty;
                                Globals.simpleMessageBox("GIMPS Password could not be decrypted!\r\nUse Configuration Editor to re-encrypt");
                            }
                        }
                
                                                

                        _ConfigDebugSection = AutoBalanceDifferenceTrigger;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            this._ConfigAutoBalanceDifferenceTrigger = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                            if (this._ConfigAutoBalanceDifferenceTrigger > 0 && this._ConfigAutoBalanceDifferenceTrigger < MinAutoBalance)
                                this._ConfigAutoBalanceDifferenceTrigger = MinAutoBalance;

                        }

                        _ConfigDebugSection = AutoUpdateStatsMins;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            this._ConfigAutoUpdateStatsMins = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                            if (this._ConfigAutoUpdateStatsMins > 0 && this._ConfigAutoUpdateStatsMins < 5)
                                this._ConfigAutoUpdateStatsMins = 5;
                        }
                        
                 

                     
                      

                        _ConfigDebugSection = StartExtProcessDelay;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigStartProcessDelaySeconds = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));


                        _ConfigDebugSection = GimpsStatsCacheTimeout;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigGIMPSstatsCacheTimeout = int.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                      


                        
                        
                        _ConfigDebugSection = SetExtProcessWorkingDirectoryToGivenPath;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigSetStartProcessWorkingDirectory = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));
                      
                        
                        _ConfigDebugSection = ShowConfirmationDialogs;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigShowConfirmationDialogs = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = EnableSchedules;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigEnableSchedules = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = ShowExportResultsInExternalFileViewer;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                            this._ConfigShowExportInExternalViewer = bool.Parse(trimmedLine.Substring(_ConfigDebugSection.Length));

                        _ConfigDebugSection = Lookin;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            Globals.ArrayListAddWithDupChecking(this._ConfigLookForWorkDirectoryList, trimmedLine.Substring(_ConfigDebugSection.Length).ToUpper());
                        }
                        _ConfigDebugSection = StartExtProcessName;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            Globals.ArrayListAddWithDupChecking(this._ConfigStartProcessList, trimmedLine.Substring(_ConfigDebugSection.Length));
                        }
                        _ConfigDebugSection = StopExtProcessName;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            Globals.ArrayListAddWithDupChecking(this._ConfigStopProcessList, trimmedLine.Substring(_ConfigDebugSection.Length));
                        }
                        _ConfigDebugSection = Scheduler;
                        if (trimmedLine.StartsWith(_ConfigDebugSection))
                        {
                            string[] splitter = trimmedLine.Substring(Scheduler.Length).Split(',');
                            if (splitter.Length == 3)
                            {
                               Globals.ListAddWithDupChecking(this._ConfigProcessScheduleList, trimmedLine.Substring(_ConfigDebugSection.Length).ToUpper());
                            }
                            else
                                throw new Exception("Invalid schedule format detected in " + Globals.FILE_MASTER_CONFIG);
                        }
                       
                    }
                   catch(Exception E)
                    {
                        sbz.AppendLine(_ConfigDebugSection +":"+E.Message);
                    }

                   

                }

               

                if (sbz.Length > 0)
                    throw new Exception("Errors during processing of " + Globals.FILE_MASTER_CONFIG + "\r\n" + sbz.ToString());

              
            }
            catch (Exception E)
            {

                Globals.simpleMessageBox("Error in LoadConfiguration:" + E.Message);
                result = false;
            }


            if (this._ConfigProcessScheduleList.Count == 0)
            {
                Random RND = new Random();
                string min = RND.Next(10, 59).ToString();  //using 10 on solves the problem of leading 0 for numbers under 10.
                _ConfigProcessScheduleList = new List<string> { "*,00:" + min + ",UPLOAD_RESULTS", "*,04:" + min + ",UPLOAD_RESULTS", "*,08:" + min + ",UPLOAD_RESULTS", "*,12:" + min + ",UPLOAD_RESULTS", "*,16:" + min + ",UPLOAD_RESULTS", "*,20:" + min + ",UPLOAD_RESULTS" };
            }
            return result;

        }
    




    }
}
