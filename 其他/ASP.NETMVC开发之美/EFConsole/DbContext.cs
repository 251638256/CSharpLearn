
namespace EF.Models {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MyDbContext : DbContext {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“EF.Models.DbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DbContext”
        //连接字符串。
        public MyDbContext()
            : base("name=DbContext") {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Blog> Blog { get; set; }

        public virtual DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            var blogConfig = modelBuilder.Entity<Blog>();
            var articleConfig = modelBuilder.Entity<Article>();

            //// 绝对错误的一对一关系 两个都是绝对的互相引用 会造成不能插入失败
            //blogConfig.HasRequired(c => c.Article).WithRequiredPrincipal();
            //articleConfig.HasRequired(c => c.Blog).WithOptional();

            // 一对一关系中 不用额外的字段就可以表示这个关系 一个主键对于另外一张表的主键
            // blog表引用article表中的主键 既必须article有的主键blog才能插入新值
            //blogConfig.HasRequired(c => c.Article).WithOptional();


            // 一对多 (有外键字段)
            //blogConfig.HasMany(c => c.Articles).WithOptional(s => s.Blog); // 外面关联不是不许的
            //blogConfig.HasMany(c => c.Articles).WithRequired(s => s.Blog); // 关联是必须的,子表的是必须要主表ID


            // 多对多 (有中间表)
            //blogConfig.HasMany(c => c.Articles).WithMany(c => c.Blogs).Map(c => {
            //    c.ToTable("BlogsToArticles");
            //    c.MapLeftKey("BlogID");
            //    c.MapRightKey("ArticleID");
            //});

        }
    }

    public class Blog {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public ICollection<Article> Articles { get; set; }
    }

    public class Article {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public ICollection<Blog> Blogs { get; set; }

    }
}