namespace Artisashop.Common;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// React Admin の バックエンド用インターフェースです。
/// Backend interface for React Admin.
/// </summary>
/// <typeparam name="T">対象となるモデルの型. Target model type</typeparam>
/// <remarks>
/// <para>https://marmelab.com/react-admin/Tutorial.html#connecting-to-a-real-api</para>
/// </remarks>
public interface IReactAdminController<T>
{
    /// <summary>
    /// 対象となるモデルのリストを取得します。
    /// Get the list of models of interest.
    /// </summary>
    /// <param name="filter">検索条件, JSONオブジェクト形式 例) {"Name":"Taro"}</param>
    /// <param name="range">取得範囲条件 (ページング), JSON配列形式 例) [0,9]</param>
    /// <param name="sort">ソート条件, JSON配列形式 例) ["id","ASC"]</param>
    /// <returns>モデルのリスト. list of models</returns>
    /// <remarks>
    /// <para>Get list に相当します。Equivalent to Get list.</para>
    /// </remarks>
    Task<ActionResult<IEnumerable<T>>> Get(string filter = "", string range = "", string sort = "");

    /// <summary>
    /// 対象となるモデルの単一要素を取得します。
    /// Gets a single element of the model of interest.
    /// </summary>
    /// <param name="id">Id値</param>
    /// <returns>モデル</returns>
    /// <remarks>
    /// <para>Get one record に相当します。</para>
    /// </remarks>
    Task<ActionResult<T>> Get(int id);

    /// <summary>
    /// 対象となるモデルを更新します。
    /// Update the target model.
    /// </summary>
    /// <param name="id">Id値</param>
    /// <param name="entity">モデル</param>
    /// <returns>モデル</returns>
    /// <remarks>
    /// <para>Update a record に相当します。</para>
    /// </remarks>
    Task<ActionResult<T>> Put(int id, T entity);

    /// <summary>
    /// 対象となるモデルを登録します。
    /// Register the target model.
    /// </summary>
    /// <param name="entity">モデル</param>
    /// <returns>モデル</returns>
    /// <remarks>
    /// <para>Create a record に相当します。</para>
    /// </remarks>
    Task<ActionResult<T>> Post(T entity);

    /// <summary>
    /// 対象となるモデルを削除します。
    /// Delete the target model.
    /// </summary>
    /// <param name="id">Id値</param>
    /// <returns>モデル</returns>
    /// <remarks>
    /// <para>Delete a record に相当します。</para>
    /// </remarks>
    Task<ActionResult<T>> Delete(int id);
}