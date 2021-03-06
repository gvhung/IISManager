﻿using IISManager.Core.Configuration;
using System;
using System.IO;

namespace IISManager.Core
{
    public class DeleteOperation : OperationBase
    {
        public DeleteOperation() { }
        public DeleteOperation(Publish publish) : base(publish) { }
        public override string Execute(Operation context)
        {
            if (string.IsNullOrEmpty(context.Path)) return string.Empty;
            return Execute(context.Path);
        }

        public string Execute(string path)
        {
            string fullPath = Path.Combine(RootPath, path);
            if (Directory.Exists(fullPath))
            {
                try
                {
                    Directory.Delete(fullPath, true);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return string.Empty;
        }
    }
}
