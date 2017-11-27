using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer
{
   public class CorrCompDescResolutionMap : EntityTypeConfiguration<CorrCompDescResolution>
    {
        public CorrCompDescResolutionMap()
        {
            this.HasKey(t => t.cc_desc_id);
            this.ToTable("CorrCompDescResolution");
            this.Property(t => t.cc_desc_id).HasColumnName("cc_desc_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.cc_description).HasColumnName("cc_description");
            this.Property(t => t.cc_description_text).HasColumnName("cc_description_text");
            this.Property(t => t.cc_resolution).HasColumnName("cc_resolution");
            this.Property(t => t.cc_resolution_text).HasColumnName("cc_resolution_text");
            this.Property(t => t.last_update_by).HasColumnName("last_update_by");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
