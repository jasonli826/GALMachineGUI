using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Getech.GS.RobotController
{
    public class RobotCommandConst
    {
        public const int VChgAuto = 2;
        public const int VChgVerify = 3;//call after LoadBatchParameter. This moded for error proofing        
        public const int VChgNone = 4;
        public const int VOffBuzzer = 5;
        public const int VSetServiceParam = 15;
        public const int VStopProduction = 16;
        public const int VAlarmOfPC = 25;
        public const int VReplyBarcode = 50;
        public const int VReplyStackerBarcode = 51;
        public const int VSendSysParameter = 54;
        public const int VSendProductData = 55;
        public const int VSendPanelInfo = 56;
        public const int VPause = 60;
        public const int VResume = 62;
        public const int VChkStatus = 70;
        public const int VReplyCamera1 = 71;
        public const int VReplyCamera2 = 72;
        
        public const int VLoadBatchParameter = 510;
        public const int VSystemOptionParameter = 511;
        public const int VMIDReadBeforePrintReply = 513;
        public const int VDriveAtPreInspectionStationSnapShotTakenReply = 514;
        public const int VDriveAtPreInspectionStationResult = 515;
        public const int VDriveAtInspectionStationReply = 516;
        public const int VDriveAtInspectionStationResult = 517;
        public const int VIndexerStep = 600;
        public const int VMoveFujiAxis = 605;
        public const int VrJumpPallet = 611;
        public const int VPickFromTray = 670;
        public const int VPlaceToTray = 670;
        public const int VPlaceToIndexer =674;

        public const int VLabelPrint = 680;
        public const int VGetLabel = 681;
        public const int VPickLabel = 682;
        public const int VPlaceLabel = 683;
        public const int VRejectLabel = 684;

        public const int VSecsGemMode = 685;
       
    }
}
