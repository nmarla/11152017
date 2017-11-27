using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class CTSCodeTableMap : EntityTypeConfiguration<CTSCodeTable>
    {
        public CTSCodeTableMap()
        {
            this.HasKey(t => t.table_no);
            this.ToTable("CTSCodeTable");
            this.Property(t => t.table_no).HasColumnName("table_no");
            this.Property(t => t.table_code).HasColumnName("table_code");
            this.Property(t => t.short_description).HasColumnName("short_description");
            this.Property(t => t.long_description).HasColumnName("long_description");
            this.Property(t => t.display_order).HasColumnName("display_order");
            this.Property(t => t.visibleyn).HasColumnName("visibleyn");
            this.Property(t => t.adm_flag).HasColumnName("adm_flag");
            this.Property(t => t.check1_flag).HasColumnName("check1_flag");
            this.Property(t => t.show_long_desc_info).HasColumnName("show_long_desc_info");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
