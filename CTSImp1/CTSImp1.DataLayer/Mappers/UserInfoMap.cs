using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTSImp1.Models;
using System.Data.Entity.ModelConfiguration;

namespace CTSImp1.DataLayer.Mappers
{
   public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            this.HasKey(t => t.usersinfo_id);
            this.ToTable("UserInfo");
            this.Property(t => t.usersinfo_id).HasColumnName("usersinfo_id");
            this.Property(t => t.users_id).HasColumnName("users_id");
            this.Property(t => t.first_name).HasColumnName("first_name");
            this.Property(t => t.last_name).HasColumnName("last_name");
            this.Property(t => t.phone_no).HasColumnName("phone_no");
            this.Property(t => t.user_role).HasColumnName("user_role");
            this.Property(t => t.user_group).HasColumnName("user_group");
            this.Property(t => t.user_status).HasColumnName("user_status");
            this.Property(t => t.user_email).HasColumnName("user_email");
            this.Property(t => t.last_logon_date).HasColumnName("last_logon_date");
            this.Property(t => t.tstamp).HasColumnName("tstamp");
        }
    }
}
