// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.Test.Execution.EngineCommands
{
    /// <summary>
    /// After each test, saves desktop snapshots differing from previous.
    /// </summary>
    internal class MoveWindowCommand : ICleanableCommand
    {
        private static IntPtr hWnd = FindConsole();
        private tagWINDOWINFO initialState;

        public static MoveWindowCommand Apply()
        {
            return new MoveWindowCommand();
        }

        public MoveWindowCommand()
        {
            initialState = new tagWINDOWINFO();
            initialState.cbSize = (uint)Marshal.SizeOf(initialState);
            GetWindowInfo(hWnd, ref initialState);

            int safeDistance = DesktopSnapshotCommand.DefaultRect.Width + 50;
            if (initialState.rcWindow.left < safeDistance)
            {
                Execution.ExecutionEventLog.RecordStatus("Moving the test console window to upper-middle for Visual Verification stability - Sorry for the inconvenience.");
                MoveWindow(hWnd,
                    safeDistance,
                    200,
                    initialState.rcWindow.right - initialState.rcWindow.left,
                    initialState.rcWindow.bottom - initialState.rcWindow.top, true);
                UpdateWindow(hWnd);
            }
        }

        public void Cleanup()
        {
            MoveWindow(hWnd,
                initialState.rcWindow.left,
                initialState.rcWindow.top,
                initialState.rcWindow.right - initialState.rcWindow.left,
                initialState.rcWindow.bottom - initialState.rcWindow.top, true);
            UpdateWindow(hWnd);
            Execution.ExecutionEventLog.RecordStatus("Returned test console window to original position.");
        }


        /// <summary>
        /// Finds the pointer to the window containing the infra console.
        /// This is needed when hosted by a parent process, as we won't own that window.
        /// Is disruptive, so we only do it once.
        /// </summary>
        /// <returns></returns>
        static private IntPtr FindConsole()
        {
            // System.Console APIs (e.g. Console.Title) will crash if no console is available for the current process.
            // Attach or allocate a console for this process.
            var processId = Process.GetCurrentProcess().Id;
            if (!AttachConsole((uint)processId))
            {
                int lastError = Marshal.GetLastWin32Error();

                // Process is already attached to another console
                if (lastError == ERROR_ACCESS_DENIED)
                {
                    // Do nothing.  Console is already available for this process.
                }

                else if (lastError == ERROR_INVALID_HANDLE)
                {
                    // Process does not have a console.  Create one.
                    if (!AllocConsole())
                    {
                        throw new Exception($"QualityVault: Microsoft.Test.Execution.EngineCommands.MoveWindowCommand: AllocConsole failed [{Marshal.GetLastWin32Error()}].");
                    }

                }

                else if (lastError == ERROR_INVALID_PARAMETER)
                {
                        
                    // Process id passed in to AttachConsole is invalid.
                    throw new Exception($"QualityVault: Microsoft.Test.Execution.EngineCommands.MoveWindowCommand: ProcessId is invalid [{processId}].");
                }

                else
                {
                    // Unknown error.  AttachConsole failed.
                    throw new Exception($"QualityVault: Microsoft.Test.Execution.EngineCommands.MoveWindowCommand: could not attach or create console [{lastError}].");
                }
            }
            
            IntPtr window = (IntPtr)null;
            string previous = Console.Title;
            string target = "Finding_Infra_Capture_Console";
            Console.Title = target;
            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    if (!ProcessUtilities.IsCriticalProcess(p) && p.MainWindowTitle == target)
                    {

                        window = p.MainWindowHandle;
                    }
                }
                catch (Exception) { }
            }
            Console.Title = previous;
            return (IntPtr)window;
        }


        #region Win32 Pinvoke code

        [DllImport("user32.dll")]
        private static extern bool GetWindowInfo(IntPtr hwnd, ref tagWINDOWINFO pwi);

        [StructLayout(LayoutKind.Sequential)]
        public struct tagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagWINDOWINFO
        {
            public uint cbSize;
            public tagRECT rcWindow;
            public tagRECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;
        }

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("kernel32.dll")] [return: MarshalAs(UnmanagedType.Bool)] private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)] private static extern bool AttachConsole(uint dwProcessId);

        private const int ERROR_ACCESS_DENIED = 5; // process is already attached to another console
        private const int ERROR_INVALID_HANDLE = 6; // process does not have a console 
        private const int ERROR_INVALID_PARAMETER = 87; // process id is invalid

        #endregion

    }
}
