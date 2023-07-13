using System;

namespace RailroadStationVisualizer.UI.Commands
{
    public class ExceptionEventArgs : EventArgs
    {
        public ExceptionEventArgs(Exception exception) {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}