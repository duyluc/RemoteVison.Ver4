using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basler.Pylon;

namespace PylonSupport
{
    public class LCamera:Basler.Pylon.Camera
    {
        public LCamera(ICameraInfo info):base(info)
        {

        }
    }
}