using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineNewGUI.Entity
{
   // [Serializable]
    public class RobotCommandConst
    {
        public const int VChgTeach = 1;
        public const int VChgAuto = 2;
        public const int VChgVerify = 3;    
        public const int VChgNone = 4;
        public const int VOffBuzzer = 5;
        public const int VInputStatus = 7;
        public const int VOutputStatus = 8;
        public const int VOnOutput = 9;

        public const int VReqMode = 11;
        public const int VGetRobotPos = 12;
        public const int VGetRobotAngles = 13;
        public const int VSetPoint = 14;
        public const int VSetServiceParam = 15;
        public const int VStopProduction = 16;
        public const int VChkArm2length = 20;
        public const int VErrorResponse = 22;
        public const int VAlarmOfPC = 25;

        public const int VReplyBarcode = 50;
        public const int VReplyVisionEmptyTray = 52;
        public const int VSetArm2 = 53;
        public const int VSendSysParameter = 54;
        public const int VSendProductData = 55;
        public const int VSendPanelInfo = 56;
        public const int VSendHas48SlotTester = 57;
        public const int VSendMachineOptions = 58;
        public const int VPause = 60;
        public const int VResume = 62;
        public const int VChkStatus = 70;
        public const int VReplyCameraCtov = 71;

        public const int VRinst = 100;
        public const int VGetRobotPosition = 102;
        public const int VRMotorOn = 111;
        public const int VRMotorOff = 112;
        public const int VJumpZZero = 113;
        public const int VChangeAdapters = 115;
        public const int VCleanAdapters = 116;
        public const int VMoveToScanner = 117;

        public const int VGiveFlipTake = 122;
        public const int vScanFinger1 = 125;
        public const int vScanFinger2 = 126;
        public const int vScanPallet = 127;
        public const int VLoadTrayIn = 130;
        public const int VFullTrayOut = 131;
        public const int VEndEffectorCal = 142;

        public const int VRinst1 = 200;
        public const int VrChgLocal = 203;
        public const int VrChgArm = 204;
        public const int VrChgTool = 205;
        public const int VrChgTip = 206;
        public const int VrTrayLocatorAct = 208;
        public const int VrGripperAct = 210;
        public const int VrVacumOnOff = 211;
        public const int VrOnFlipper = 212;
        public const int VrLockAdapter = 214;
        public const int VrOnHandShut = 216;
        public const int VrClearTip = 221;

        public const int VRobotInstruct5 = 400;
        public const int VrIncMoveRobot = 401;
        public const int VrJumpPoint = 402;
        public const int VrJumpPallet = 403;
        public const int VrJumpBarcode = 404;
        public const int VrMoveDeltaAxis = 405;
        public const int VrJumpPalletBcd = 406;
        public const int VrJumpFlipperFingerBcd = 408;
        public const int VrJumpFixtureBcd = 409;

        public const int VPickBoard = 410;
        public const int VPlaceBoard = 411;
        public const int VIndexerHome = 412;
        public const int VIndexerJog = 413;
        public const int VIndexerStep = 414;
        public const int VrSpotCheck = 415;
        public const int VRunMachine = 418;
        public const int VFlipper = 419;
        public const int VTrayWidthAdjust = 424;

        public const int DriveResult = 503;
        public const int VBatchParameter = 510;
        public const int VTesterPortConfig = 511;
        public const int VTesterDriveState = 512;
        public const int VDriveAtLabelStationReply = 513;
        public const int VDriveAtInspectionStationReply = 514;
        public const int VPrevStopDone = 515;
        public const int VStopConv = 516;
        public const int VSetPoint6Axis = 517;
        public const int VTesterPortConfig48 = 518;

        public const int VPickFromFlipper = 521;
        public const int VPickFromIndexer = 522;
        public const int VPlaceToFlipper = 523;
        public const int VPlaceToIndexer = 524;
        public const int VPlaceToBridgeFixture = 525;

        public const int VGetLabel = 530;
        public const int VPickLabel = 531;
        public const int VPlaceLabel = 532;
        public const int VSecsGemMode = 540;
        public const int VLabelPosition = 542;
        
    }
}
