using System;
using System.IO;
using System.Reflection;

namespace ET
{
    public static class DllHelper
    {
        public static Assembly GetHotfixAssembly()
        {
            //byte[] dllBytes = File.ReadAllBytes("./Server.Hotfix.dll");
            //byte[] pdbBytes = File.ReadAllBytes("./Server.Hotfix.pdb");
            byte[] dllBytes = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/Server.Hotfix.dll");
            byte[] pdbBytes = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/Server.Hotfix.pdb");
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }
    }
}