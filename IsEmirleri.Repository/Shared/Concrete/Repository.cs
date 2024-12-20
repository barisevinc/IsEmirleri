﻿using IsEmirleri.Data;
using IsEmirleri.Models;
using IsEmirleri.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsEmirleri.Repository.Shared.Concrete
{
    public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public T Add(T entity)
        {
           _dbSet.Add(entity);
            Save();
            return entity;
        }

        public bool Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if(entity != null)
            {
                entity.IsDeleted = true;
                entity.DateDeleted = DateTime.Now;
                _dbSet.Update(entity);
                Save();
                return true;
            }
            return false;
            
        }

        public IQueryable<T> GetAll()
        {
           return _dbSet.Where(t=>t.IsDeleted==false);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAllWithIsDeleted()
        {
            return _dbSet;
        }

        public T GetByGuid(Guid guid)
        {
            return GetFirstOrDefault(t=>t.Guid == guid);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public bool HardDelete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            Save();
            return true;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            entity.DateUpdated = DateTime.Now;
            Save();
            return entity;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<T> GetAllWithIsDeleted(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

    }
}
