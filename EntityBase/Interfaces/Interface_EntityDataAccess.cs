using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lv02_EntityBase.Interfaces
{
    public interface Interface_EntityDataAccess
    {
        List<String> GetEntityKeys(String EntityName);
    }
}
