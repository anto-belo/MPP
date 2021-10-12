using System;
using System.Runtime.InteropServices;

namespace MPP_4
{
    public class OsHandle : IDisposable
    {
        [DllImport("Kernel32")]
        private static extern Boolean CloseHandle(IntPtr handle);
        private IntPtr Handle { get; set; }
        private bool _disposed;

        public OsHandle(IntPtr handle)
        {
            Handle = handle;
        }

        public void Dispose()
        {
            Console.WriteLine("DISPOSING!");
            if (_disposed || Handle == IntPtr.Zero) return;
            CloseHandle(Handle);
            Handle = IntPtr.Zero;
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        
        ~OsHandle()
        {
            Dispose();
        }
    }
}