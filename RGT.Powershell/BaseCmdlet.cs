using System;
using System.Management.Automation;

namespace RGT.Powershell
{
    public class BaseCmdlet : PSCmdlet
    {
        protected virtual void InternalProcessRecord()
        {
        }

        protected override sealed void ProcessRecord()
        {
            try
            {
                InternalProcessRecord();
            }
            catch (AggregateException ex)
            {
                foreach (var iex in ex.InnerExceptions)
                {
                    var er = new ErrorRecord(iex, iex.GetType().Name, ErrorCategory.OperationStopped, this);
                    er.ErrorDetails = new ErrorDetails(iex.Message);
                    WriteError(er);
                }
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, ex.GetType().Name, ErrorCategory.OperationStopped, this));
            }
        }
    }
}
