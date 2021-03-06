﻿using SensorsSystem.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorsSystem.DataLayer.Implementations
{
    public class FileSystemRepository<T> : IRepository<T> where T: class,  new()
    {
        private readonly IFileSystemManager<T> _fileSystemManager;

        public FileSystemRepository(IFileSystemManager<T> fileSystemManager)
        {
            _fileSystemManager = fileSystemManager;
        }

        public Task<T> Create(T item)
        {
            return _fileSystemManager.Add(item);
        }

        public Task<T> Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return _fileSystemManager.Find(expression);
        }

        public Task<IEnumerable<T>> FindAll (Expression<Func<T, bool>> condition)
        {
            return Task.FromResult(new List<T> { new T(), new T() } as IEnumerable<T>);
        }

        public Task<T> Get(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Remove(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
