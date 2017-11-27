using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer
{
   public class CorrCompContactInfoMap:EntityTypeConfiguration<CorrCompContactInfo>
    {
        public CorrCompContactInfoMap()
        {
            this.HasKey(t => t.cc_contact_id);
            this.ToTable("CorrCompContactInfo");
            this.Property(t => t.cc_contact_id).HasColumnName("cc_contact_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.fname).HasColumnName("fname");
            this.Property(t => t.lname).HasColumnName("lname");
            this.Property(t => t.tel_number).HasColumnName("tel_number");
            this.Property(t => t.email_add).HasColumnName("email_add");
            this.Property(t => t.street_add).HasColumnName("street_add");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.zipcode).HasColumnName("zipcode");
            this.Property(t => t.zipcode2).HasColumnName("zipcode2");
            this.Property(t => t.dfta_id).HasColumnName("dfta_id");
            this.Property(t => t.other_site_name).HasColumnName("other_site_name");
            this.Property(t => t.last_updated_by).HasColumnName("last_updated_by");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
            this.Property(t => t.cont_with_dfta_yn).HasColumnName("cont_with_dfta_yn");
        }
    }
}
