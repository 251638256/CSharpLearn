namespace 控制器入门.Models {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“Model”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“控制器入门.Models.Model”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“Model”
        //连接字符串。
        public Model()
            : base("name=Model") {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<Model>(null);
            //base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<基本信息> 基本信息 { get; set; }
        public virtual DbSet<受检者个人信息> 个人信息 { get; set; }
        public virtual DbSet<既往病史> 既往病史 { get; set; }
        public virtual DbSet<职业史> 职业史 { get; set; }
    }
}