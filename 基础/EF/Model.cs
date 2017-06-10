namespace 基础 {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public class Model : DbContext {
        public Model()
            : base("name=Model") {
        }

        public virtual DbSet<Person> People { get; set; }


        //public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            Database.SetInitializer<Model>(new DataInit());
            //Database.SetInitializer<Model>(new DropCreateDatabaseIfModelChanges<Model>());
            //Database.SetInitializer<Model>(new MigrateDatabaseToLatestVersion<Model, DbMigrationsConfig>());
        }
    }

    /// <summary>
    /// 数据库改变后的初始化配置(删库并使用种子初始化)
    /// </summary>
    public class DataInit : DropCreateDatabaseIfModelChanges<Model> {
        protected override void Seed(Model context) {
            var query = new Person[]{
                new Person { Age = null,Name = "赞赏34", Born = DateTime.Now,  Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 19,  Name = "赞赏22", Born = DateTime.Now,  Sex = 1, Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 12,  Name = "赞赏33", Born = DateTime.Now,  Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 13,  Name = "赞赏34", Born = DateTime.Now,  Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 14,  Name = "赞赏35", Born = DateTime.Now,  Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 15,  Name = "赞赏33", Born = DateTime.Now,  Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } }
            };
            context.People.AddRange(query);
            context.SaveChanges();
            base.Seed(context);
        }
    }

    /// <summary>
    /// 自动迁移数据库 并且每次都初始化(会有多次初始化的问题)
    /// </summary>
    public class DbMigrationsConfig : DbMigrationsConfiguration<Model> {

        private bool _pendingMigrations; // 决定是否迁移在

        public DbMigrationsConfig() {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Model context) {

            context.People.AddOrUpdate(
                c => c.ID,
                new Person { Age = null, Name = "赞赏34", Born = DateTime.Now, Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 19, Name = "赞赏22", Born = DateTime.Now, Sex = 1, Scores = new Score { EnglishScore = 1, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 12, Name = "赞赏33", Born = DateTime.Now, Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 13, Name = "赞赏34", Born = DateTime.Now, Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 14, Name = "赞赏35", Born = DateTime.Now, Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } },
                new Person { Age = 15, Name = "赞赏33", Born = DateTime.Now, Sex = 1, Scores = new Score { EnglishScore = 0, MathScore = 2, PhysicalScore = 3 } }
            );
            context.SaveChanges();
            base.Seed(context);
        }


    }

}