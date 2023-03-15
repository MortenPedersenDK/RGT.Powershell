using RGT.Services.Core.Data;
using RGT.Services.Core.DTO;
using System.Management.Automation;

namespace RGT.Powershell
{
    public class SecureCmdlet : BaseCmdlet
    {
        [Parameter(Mandatory = false)]
        private Context context;

        public Context Context
        {
            get
            {
                if (context == null)
                {
                    if (ContextContainer.CurrentContext == null)
                    {
                        throw new PSArgumentException("Use Connect-RGTService to login before calling this cmdlet.");
                    }
                    else
                    {
                        context = ContextContainer.CurrentContext;
                    }
                }
                return context;
            }
            set
            {
                context = value;
            }
        }
    }
}
