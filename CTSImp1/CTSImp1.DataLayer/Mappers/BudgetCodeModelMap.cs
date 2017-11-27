using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
    public class BudgetCodeModelMap : EntityTypeConfiguration<BudgetCodeModel>
    {
        public BudgetCodeModelMap()
        {
            this.HasKey(t => t.data_value);
            this.ToTable("BudgetCodeModel");
            this.Property(t => t.data_value).HasColumnName("data_value");
            this.Property(t => t.display_value).HasColumnName("display_value");
        }
    }
}
