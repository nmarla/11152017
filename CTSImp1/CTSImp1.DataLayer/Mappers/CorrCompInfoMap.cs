using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class CorrCompInfoMap : EntityTypeConfiguration<CorrCompInfo>
    {
        public CorrCompInfoMap()
        {
            this.HasKey(t => t.cc_number);
            this.ToTable("CorrCompInfo");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.purpose_of_contact).HasColumnName("purpose_of_contact");
            this.Property(t => t.poc_other).HasColumnName("poc_other");
            this.Property(t => t.cc_recdin).HasColumnName("cc_recdin");
            this.Property(t => t.date_recd).HasColumnName("date_recd");
            this.Property(t => t.recd_by).HasColumnName("recd_by");
            this.Property(t => t.date_entered).HasColumnName("date_entered");
            this.Property(t => t.cc_date).HasColumnName("cc_date");
            this.Property(t => t.cc_status).HasColumnName("cc_status");
            this.Property(t => t.serv_req_number).HasColumnName("serv_req_number");
        }
    }
}
