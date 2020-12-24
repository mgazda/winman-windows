﻿
using WinMan.Implementation.Win32;

namespace WinMan
{
    public static class Workspaces
    {
        private static readonly object s_syncRoot = new object();
        private static IWorkspace m_currentWorkspace;

        public static IWorkspace GetCurrentWorkspace()
        {
            if (m_currentWorkspace == null) 
            {
                lock (s_syncRoot)
                {
                    if (m_currentWorkspace == null)
                    {
                        m_currentWorkspace = new Win32Workspace();
                    }
                }
            }
            return m_currentWorkspace;
        }
    }
}
