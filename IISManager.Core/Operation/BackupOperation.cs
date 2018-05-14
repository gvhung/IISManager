﻿using IISManager.Core.Configuration;
using IISManager.Core.Utils;
using System.IO;
using System.Linq;

namespace IISManager.Core
{
    public class BackupOperation : OperationBase
    {
        public BackupOperation(Publish publish) : base(publish){}
        public override bool Execute(Operation context)
        {
            string previousVersion = Publish.Version.Previous;
            string wp = Path.Combine(RootPath, Globals.WEB_ROOT);
            ZipUtil.Zip(wp, Path.Combine(RootPath, previousVersion + ".zip"));
            return true;
        }
    }
}
