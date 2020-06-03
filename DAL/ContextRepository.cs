﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public sealed class ContextRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AuctionContext Context;
        private readonly DbSet<TEntity> BDSet;


        public ContextRepository(AuctionContext context)
        {

            Context = context;
            BDSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            using (AuctionContext db = new AuctionContext())
            {
                BDSet.Add(item);
            }
        }

        public TEntity FindById(int id)
        {
            return BDSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return BDSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return BDSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return BDSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity item)
        {
            try
            {
                BDSet.Remove(item);
            }
            catch (ArgumentNullException)
            {

            }
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }


    }
}
