using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.DAL.Entities;
using QuanLyThuVien.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly QuanLyThuVienContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(QuanLyThuVienContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
    public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query.ToList();
    }
    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
            _dbSet.Remove(entity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}