using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class ExcelWindowWrapper : IWin32Window
{
    private IntPtr _hwnd;

    public ExcelWindowWrapper(IntPtr hwnd)
    {
        _hwnd = hwnd;
    }

    public IntPtr Handle => _hwnd;
}