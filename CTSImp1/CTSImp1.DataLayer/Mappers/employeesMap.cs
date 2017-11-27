using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
  public  class employeesMap : EntityTypeConfiguration<employees>
    {
        public employeesMap()
        {
            this.HasKey(t => t.employee_id);
            this.ToTable("employees");
            this.Property(t => t.employee_id).HasColumnName("employee_id");
            this.Property(t => t.full_name).HasColumnName("full_name");
            this.Property(t => t.department).HasColumnName("department");
            this.Property(t => t.gender).HasColumnName("gender");
            this.Property(t => t.position).HasColumnName("position");
            this.Property(t => t.salary).HasColumnName("salary");
           
        }
    }
}
