using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JogControl;
using RobotController;

namespace Getech.GS.RobotController
{
    public static class RobotControllerModel
    {        
        public static void DownloadPoints(bool Is6Axis, EpsonRobotController epsonRbt, List<Getech.GS.RobotController.RobotPoint> listPoints)
        {
            if (epsonRbt == null)
                return;
            if (!epsonRbt.IsConnected)
                return;
            foreach (Getech.GS.RobotController.RobotPoint rp in listPoints)
            {
                JogControl.RobotPoint Pt = new JogControl.RobotPoint(rp.X, rp.Y, rp.Z, rp.U, rp.V, rp.W);
                Pt.Hand = rp.Hand;
                if(Is6Axis)
                {                    
                    Pt.Elbow = rp.Elbow;
                    Pt.Wrist = rp.Wrist;
                }
                Pt.ZOff = 0; //default seems 50 
                Pt.PointNum = (int)rp.PointNumber;

                epsonRbt.SendRobotPoint(Pt);                
            }            
        }     
        
    }
}
