using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class IncLocationInfoMap : EntityTypeConfiguration<IncLocationInfo>
    {
        public IncLocationInfoMap()
        {
            this.HasKey(t => t.inc_loc_id);
            this.ToTable("IncLocationInfo");
            this.Property(t => t.inc_loc_id).HasColumnName("inc_loc_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.inc_loc_type).HasColumnName("inc_loc_type");
            this.Property(t => t.street_add).HasColumnName("street_add");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.zipcode).HasColumnName("zipcode");
            this.Property(t => t.zipcode2).HasColumnName("zipcode2");
            this.Property(t => t.last_update_by).HasColumnName("last_update_by");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
