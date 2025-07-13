using System;
using System.Windows.Forms;

public static class ExcelAppContext
{
    private static Control _uiThreadControl;

    public static void Initialize()
    {
        _uiThreadControl = new Control();
        _uiThreadControl.CreateControl();
    }

    public static void RunOnMainThread(Action action)
    {
        if (_uiThreadControl.InvokeRequired)
            _uiThreadControl.Invoke(action);
        else
            action();
    }
}