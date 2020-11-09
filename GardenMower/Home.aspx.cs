using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoverGardenClass;

namespace GardenMower
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Click(object sender, EventArgs e)
        {
            Response.Write("HIIII");
        }
        
        [System.Web.Services.WebMethod]
        public static string ReloadData(int xGarden,int yGarden, string strPosition,string strCommand)
        {
            string strRet = "";
            try
            {
                RoverGardenClass.GardenRover lawnMower = new GardenRover(3, 3, GardenRover.RoverDirection.E, xGarden, yGarden);
                var success = lawnMower.MoveMowerByCommand(strCommand.ToUpper());
                int iX = lawnMower.GetPosition().X;
                int iY = lawnMower.GetPosition().Y;
                string str = lawnMower.GetPosition().Moving.ToString();
                strRet = ("x =" + iX + " y= " + iY + " Direction =" + str);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return strRet;
        }
    }
}