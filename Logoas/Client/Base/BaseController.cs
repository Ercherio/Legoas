﻿using Client.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Client.Base;
public class BaseController<TId, TEntity, TRepository> : Controller
    where TEntity : class
    where TRepository : IRepository<TId, TEntity>
{
    private readonly TRepository repository;

    public BaseController(TRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public async Task<JsonResult> Get()
    {
        var result = await repository.Get();
        return Json(result);
    }

    [HttpGet]
    public async Task<JsonResult> Get(TId id)
    {
        var result = await repository.Get(id);
        return Json(result);
    }

    [HttpPost]
    public JsonResult Post(TEntity entity)
    {
        var result = repository.Post(entity);
        return Json(result);
    }

    [HttpPut]
    public JsonResult Put(TEntity entity, TId id )
    {
        var result = repository.Put(entity, id );
        return Json(result);
    }

    [HttpDelete]
    public JsonResult Delete(TId id)
    {
        var result = repository.Delete(id);
        return Json(result);
    }
}
