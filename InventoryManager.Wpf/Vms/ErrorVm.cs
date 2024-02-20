using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Wpf.Vms
{
    public class ErrorVm
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorVm(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
