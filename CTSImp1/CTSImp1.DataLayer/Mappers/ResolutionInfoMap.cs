using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class ResolutionInfoMap : EntityTypeConfiguration<ResolutionInfo>
    {
        public ResolutionInfoMap()
        {
            this.HasKey(t => t.resolution_id);
            this.ToTable("ResolutionInfoMap");
            this.Property(t => t.resolution_id).HasColumnName("resolution_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.cc_handled_by).HasColumnName("cc_handled_by");
            this.Property(t => t.comments).HasColumnName("comments");
            this.Property(t => t.last_updated_by).HasColumnName("last_updated_by");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
            this.Property(t => t.date_resolved).HasColumnName("date_resolved"); 
        }
    }
}
