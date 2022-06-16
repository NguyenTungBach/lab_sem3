using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSem3.Enum
{
    public enum DepartmentStatusEnum
    {
        ACTIVE = 1, // đang hoạt động
        INACTIVE = -1, // dừng hoạt động
        MAINTENANCE = 0, // đang bảo trì
    }
}