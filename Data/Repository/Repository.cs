using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using AppDemo.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace AppDemo.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected localContext Db;

        protected DbSet<TEntity> DbSet;

        public Repository(localContext context)
        {
            Db = context;

            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            //obj.GetType().GetProperty("DataJogo")?.SetValue(obj, DateTime.Now, null);

            DbSet.AddAsync(obj);

            Db.SaveChanges();
        }

        public TEntity GetById(object keys)
        {
            return DbSet.Find(keys);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public T Query<T>(string query)
        {
            using (var cn = connection)
            {
                return cn.QueryFirst<T>($@"{query}");
            }
        }

        public IEnumerable<T> QueryList<T>(string query)
        {
            using (var cn = connection)
            {
                return cn.Query<T>($@"{query}").ToList();
            }
        }

        public IDbConnection connection
        {
            get { return new SqlConnection(Db.Database.GetDbConnection().ConnectionString); }
        }


        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}