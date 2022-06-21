using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJira.Models
{
    public class MiscButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BusinessRoleId { get; set; }
        public int? TaskId { get; set; }

        public string ActionParameter
        {
            get
            {
                StringBuilder param = new StringBuilder(@"/");
                
                if (ProjectId != null && ProjectId > 0)
                {
                    param.Append($"{ProjectId}");
                }

                if (UserId != null && UserId > 0)
                {
                    param.Append($"{UserId}");
                }

                if (DepartmentId != null && DepartmentId > 0)
                {
                    param.Append($"{DepartmentId}");
                }

                if (BusinessRoleId != null && BusinessRoleId > 0)
                {
                    param.Append($"{BusinessRoleId}");
                }

                if (TaskId != null && TaskId > 0)
                {
                    param.Append($"{TaskId}");
                }

                return param.ToString();
            }
        }


}
}
