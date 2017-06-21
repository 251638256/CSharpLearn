using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConsole {
    class Program {
        private static MyDbContext context = new MyDbContext();
        static void Main(string[] args) {
            context.Database.CreateIfNotExists();


            Data2();

            context.SaveChanges();
        }

        static void Data1() {
            // 使用
            //Article[] articles = new Article[] {
            //    new Article { ArticleName = "MyArticle1",Blog = new Blog { BlogName = "Fcuking Blog" } },
            //    new Article { ArticleName = "MyArticle2" },
            //    new Article { ArticleName = "MyArticle3" },
            //    new Article { ArticleName = "MyArticle4" },
            //};

            //Blog[] blogs = new Blog[] {
            //    new Blog { BlogName = "MyBlog1", Articles = articles },
            //    new Blog { BlogName = "MyBlog2" },
            //    new Blog { BlogName = "MyBlog3" },
            //    new Blog { BlogName = "MyBlog4" },
            //};

            //context.Article.AddRange(articles);
            //context.Blog.AddRange(blogs);
        }

        static void Data2() {
            Blog[] blogs = new Blog[] {
                new Blog { BlogName = "MyBlog1" },
                new Blog { BlogName = "MyBlog2" },
            };
            context.Blog.AddRange(blogs);
        }
    }
}
