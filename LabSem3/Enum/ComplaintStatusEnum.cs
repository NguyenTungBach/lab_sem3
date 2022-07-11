using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSem3.Enum
{
    public enum ComplaintStatusEnum
    {
        PENDING = 1, // chưa hỗ trợ
        PROCESSING = 2, // đang xử lý
        COMPLETE = 3, // hoàn thành
        UNASSIGN = 4, // chưa đc phân bổ cho người xử lý
    }
}