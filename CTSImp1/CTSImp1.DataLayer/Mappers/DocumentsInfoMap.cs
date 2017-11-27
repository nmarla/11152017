using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class DocumentsInfoMap : EntityTypeConfiguration<DocumentsInfo>
    {
        public DocumentsInfoMap()
        {
            this.HasKey(t => t.attachment_id);
            this.ToTable("DocumentsInfo");
            this.Property(t => t.attachment_id).HasColumnName("attachment_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.attachment_type).HasColumnName("attachment_type");
            this.Property(t => t.file_name).HasColumnName("file_name");
            this.Property(t => t.file_ext).HasColumnName("file_ext");
            this.Property(t => t.file_location).HasColumnName("file_location");
            this.Property(t => t.last_updated_by).HasColumnName("last_updated_by");
            this.Property(t => t.record_status).HasColumnName("record_status");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
