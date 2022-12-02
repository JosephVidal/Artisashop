using System.Linq.Dynamic.Core;
using System.Net.Http.Headers;

namespace Artisashop.Common;

using Artisashop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// <see cref="IReactAdminController{T}"/> の抽象実装クラスです。
/// is an abstract implementation class of <see cref="IReactAdminController{T}"/>.
/// </summary>
/// <typeparam name="T">対象となるモデルの型. Target model type</typeparam>
[Route("[controller]")]
[ApiController]
public abstract class ReactAdminController<T> : ControllerBase, IReactAdminController<T> where T : class, new()
{
    protected readonly StoreDbContext _context;
    protected DbSet<T> _table;

    /// <summary>
    /// コンストラクタ
    /// constructor
    /// </summary>
    /// <param name="context"><see cref="DotNetCoreReactAdminContext"/></param>
    protected ReactAdminController(StoreDbContext context)
    {
        _context = context;
    }


    /// <inheritdoc />
    [HttpDelete, Route("[controller]/{id:int}")]
    public async Task<ActionResult<T>> Delete(int id)
    {
        var entity = await _table.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        _table.Remove(entity);
        await _context.SaveChangesAsync();

        return Ok(entity);
    }

    /// <inheritdoc />
    [HttpGet, Route("[controller]")]
    public async Task<ActionResult<IEnumerable<T>>> Get(string filter = "", string range = "", string sort = "")
    {
        var entityQuery = _table.AsQueryable();

        // NOTE
        // 検索条件を元に対象データの絞り込みを行います。
        // 検索対象項目が string型 の場合は、部分一致による検索を行います。
        // The target data is narrowed down based on the search conditions.
        // If the search target item is string type, search by partial match.
        if (!string.IsNullOrEmpty(filter))
        {
            var filterVal = (JObject)JsonConvert.DeserializeObject(filter);
            var t = new T();
            foreach (var f in filterVal)
            {
                if (t.GetType().GetProperty(f.Key)?.PropertyType == typeof(string))
                {
                    entityQuery = entityQuery.Where($"{f.Key}.Contains(@0)", f.Value.ToString());
                }
                else
                {
                    entityQuery = entityQuery.Where($"{f.Key} == @0", f.Value.ToString());
                }
            }
        }

        var count = entityQuery.Count();

        // NOTE ソート条件を元に対象データのソートを行います。
        // NOTE Sort the target data based on the sort conditions.
        if (!string.IsNullOrEmpty(sort))
        {
            var sortVal = JsonConvert.DeserializeObject<List<string>>(sort);
            var condition = sortVal.First();
            var order = sortVal.Last() == "ASC" ? "" : "descending";
            entityQuery = entityQuery.OrderBy($"{condition} {order}");
        }

        // NOTE 取得範囲条件を元にデータの取得を行います。
        // NOTE Data is acquired based on the acquisition range conditions.
        var from = 0;
        var to = 0;
        if (!string.IsNullOrEmpty(range))
        {
            var rangeVal = JsonConvert.DeserializeObject<List<int>>(range);
            from = rangeVal.First();
            to = rangeVal.Last();
            entityQuery = entityQuery.Skip(from).Take(to - from + 1);
        }

        // NOTE React Admin の仕様に従い、レスポンスヘッダを設定します。
        // NOTE Set response headers according to the React Admin spec.
        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range", $"{typeof(T).Name.ToLower()} {from}-{to}/{count}");
        return await entityQuery.ToListAsync();
    }

    /// <inheritdoc />
    [HttpGet, Route("[controller]/{id:int}")]
    public async Task<ActionResult<T>> Get(int id)
    {
        var entity = await _table.FindAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    /// <inheritdoc />
    [HttpPost, Route("[controller]")]
    public async Task<ActionResult<T>> Post(T entity)
    {
        var entry = _table.Add(entity);
        await _context.SaveChangesAsync();

        var id = (int?)typeof(T).GetProperty("Id")?.GetValue(entry.Entity);
        return Ok(await _table.FindAsync(id));
    }

    /// <inheritdoc />
    [HttpPut, Route("[controller]/{id:int}")]
    public async Task<ActionResult<T>> Put(int id, T entity)
    {
        var entityId = (int?)typeof(T).GetProperty("Id")?.GetValue(entity);
        if (!entityId.HasValue || id != entityId)
        {
            return BadRequest();
        }

        _context.Entry(entity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EntityExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(await _table.FindAsync(entityId));
    }


    /// <summary>
    /// 対象モデルの存在をチェックします。
    /// Checks for the existence of the target model.
    /// </summary>
    /// <param name="id">Id値</param>
    /// <returns>存在する場合: true</returns>
    private bool EntityExists(int id)
    {
        return _table.Any(e => (int)typeof(T).GetProperty("Id").GetValue(e) == id);
    }
}