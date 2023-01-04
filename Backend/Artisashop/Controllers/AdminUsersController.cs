namespace Artisashop.Controllers;

using System.Linq.Dynamic.Core;
using Artisashop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// Variant of IReactAdminController for IdentityUser based entities
/// <see cref="IReactAdminController{T}"/> の抽象実装クラスです。
/// </summary>
/// <typeparam name="T">対象となるモデルの型</typeparam>
[ApiController]
[Route("api/admin/user")]
[Authorize(Roles = Roles.Admin)]
public class AdminUserController : ControllerBase
{
    protected readonly StoreDbContext _context;
    protected DbSet<Account> _table;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context"><see cref="DotNetCoreReactAdminContext"/></param>
    public AdminUserController(StoreDbContext context)
    {
        _context = context;
        _table = _context.Users;
    }

    /// <inheritdoc />
    [HttpDelete("{id}")]
    public async Task<ActionResult<Account>> Delete(string id)
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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Account>>> Get(string filter = "", string range = "", string sort = "")
    {
        var entityQuery = _table.AsQueryable() as IQueryable;

        // NOTE
        // 検索条件を元に対象データの絞り込みを行います。
        // 検索対象項目が string型 の場合は、部分一致による検索を行います。
        if (!string.IsNullOrEmpty(filter))
        {
            var filterVal = (JObject)JsonConvert.DeserializeObject(filter);
            var t = new Account();
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
        if (!string.IsNullOrEmpty(sort))
        {
            var sortVal = JsonConvert.DeserializeObject<List<string>>(sort);
            var condition = sortVal.First();
            var order = sortVal.Last() == "ASC" ? "" : "descending";
            entityQuery = entityQuery.OrderBy($"{condition} {order}");
        }

        // NOTE 取得範囲条件を元にデータの取得を行います。
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
        Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
        Response.Headers.Add("Content-Range", $"{typeof(Account).Name.ToLower()} {from}-{to}/{count}");
        return await entityQuery.Cast<Account>().ToListAsync();
    }

    /// <inheritdoc />
    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> Get(string id)
    {
        var entity = await _table.FindAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    /// <inheritdoc />
    [HttpPost]
    public async Task<ActionResult<Account>> Post(Account entity)
    {
        var entry = _table.Add(entity);
        await _context.SaveChangesAsync();

        var id = (int?)typeof(Account).GetProperty("Id")?.GetValue(entry.Entity);
        return Ok(await _table.FindAsync(id));
    }

    /// <inheritdoc />
    [HttpPut("{id}")]
    public async Task<ActionResult<Account>> Put(string id, Account entity)
    {
        var entityId = (string?)typeof(Account).GetProperty("Id")?.GetValue(entity);
        if (entityId == null || id != entityId)
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
    /// </summary>
    /// <param name="id">Id値</param>
    /// <returns>存在する場合: true</returns>
    private bool EntityExists(string id)
    {
        return _table.Any(e => (string)typeof(Account).GetProperty("Id").GetValue(e) == id);
    }
}