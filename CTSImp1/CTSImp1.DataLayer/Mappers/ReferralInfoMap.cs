using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
    public class ReferralInfoMap: EntityTypeConfiguration<ReferralInfo>
    {
        public ReferralInfoMap()
        {
            this.HasKey(t => t.referral_id);
            this.ToTable("ReferralInfo");
            this.Property(t => t.referral_id).HasColumnName("referral_id");
            this.Property(t => t.cc_number).HasColumnName("cc_number");
            this.Property(t => t.referred_to_group).HasColumnName("referred_to_group");
            this.Property(t => t.due_date).HasColumnName("due_date");
            this.Property(t => t.referral_status).HasColumnName("referral_status");
            this.Property(t => t.comments).HasColumnName("comments");
            this.Property(t => t.referral_accpt_yn).HasColumnName("referral_accpt_yn");
            this.Property(t => t.referral_rejected_comments).HasColumnName("referral_rejected_comments");
            this.Property(t => t.last_update_by).HasColumnName("last_update_by");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
