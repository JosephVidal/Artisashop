/*
 * API Entreprise
 *
 * Cette page contient la documentation technique pour accéder à API Entreprise. Les API étant accessible uniquement sous habilitation, l'interaction avec l'environnement de production n'est possible que si vous êtes **en possession d'une clé d'accès (jeton).  ### Comment tester l'API ?  Il est possible de tester les API via notre environnement de **staging** qui vous retournera systématiquement des données fictives.  Il est nécessaire d'utiliser le jeton de staging indiqué ci-dessous.  - --  *eyJhbGciOiJIUzI1NiJ9.eyJ1aWQiOiI1MmE1YmZjMi1jMzUwLTQ4ZjQtYjY5Ni05ZWE3NmRiM2VmMjkiLCJqdGkiOiIwMDAwMDAwMC0wMDAwLTAwMDAtMDAwMC0wMDAwMDAwMDAwMDAiLCJzY29wZXMiOlsiY2VydGlmaWNhdF9yZ2VfYWRlbWUiLCJtc2FfY290aXNhdGlvbnMiLCJlbnRyZXByaXNlcyIsImV4dHJhaXRzX3JjcyIsImNlcnRpZmljYXRfb3BxaWJpIiwiYXNzb2NpYXRpb25zIiwiZXRhYmxpc3NlbWVudHMiLCJmbnRwX2NhcnRlX3BybyIsInF1YWxpYmF0IiwiZW50cmVwcmlzZXNfYXJ0aXNhbmFsZXMiLCJjZXJ0aWZpY2F0X2NuZXRwIiwiZW9yaV9kb3VhbmVzIiwicHJvYnRwIiwiYWN0ZXNfaW5waSIsImV4dHJhaXRfY291cnRfaW5waSIsImF0dGVzdGF0aW9uc19zb2NpYWxlcyIsImxpYXNzZV9maXNjYWxlIiwiYXR0ZXN0YXRpb25zX2Zpc2NhbGVzIiwiZXhlcmNpY2VzIiwiY29udmVudGlvbnNfY29sbGVjdGl2ZXMiLCJiaWxhbnNfaW5waSIsImRvY3VtZW50c19hc3NvY2lhdGlvbiIsImNlcnRpZmljYXRfYWdlbmNlX2JpbyIsImJpbGFuc19lbnRyZXByaXNlX2JkZiIsImF0dGVzdGF0aW9uc19hZ2VmaXBoIiwibWVzcmlfaWRlbnRpZmlhbnQiLCJtZXNyaV9pZGVudGl0ZSIsIm1lc3JpX2luc2NyaXB0aW9uX2V0dWRpYW50IiwibWVzcmlfaW5zY3JpcHRpb25fYXV0cmUiLCJtZXNyaV9hZG1pc3Npb24iLCJtZXNyaV9ldGFibGlzc2VtZW50cyIsInBvbGVfZW1wbG9pX2lkZW50aXRlIiwicG9sZV9lbXBsb2lfYWRyZXNzZSIsInBvbGVfZW1wbG9pX2NvbnRhY3QiLCJwb2xlX2VtcGxvaV9pbnNjcmlwdGlvbiIsImNuYWZfcXVvdGllbnRfZmFtaWxpYWwiLCJjbmFmX2FsbG9jYXRhaXJlcyIsImNuYWZfZW5mYW50cyIsImNuYWZfYWRyZXNzZSIsImNub3VzX3N0YXR1dF9ib3Vyc2llciIsInVwdGltZSIsImNub3VzX2VjaGVsb25fYm91cnNlIiwiY25vdXNfZW1haWwiLCJjbm91c19wZXJpb2RlX3ZlcnNlbWVudCIsImNub3VzX3N0YXR1dF9ib3Vyc2UiLCJjbm91c192aWxsZV9ldHVkZXMiLCJjbm91c19pZGVudGl0ZSIsImRnZmlwX2RlY2xhcmFudDFfbm9tIiwiZGdmaXBfZGVjbGFyYW50MV9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50MV9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50MV9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RlY2xhcmFudDJfbm9tIiwiZGdmaXBfZGVjbGFyYW50Ml9ub21fbmFpc3NhbmNlIiwiZGdmaXBfZGVjbGFyYW50Ml9wcmVub21zIiwiZGdmaXBfZGVjbGFyYW50Ml9kYXRlX25haXNzYW5jZSIsImRnZmlwX2RhdGVfcmVjb3V2cmVtZW50IiwiZGdmaXBfZGF0ZV9ldGFibGlzc2VtZW50IiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX3RheGF0aW9uIiwiZGdmaXBfYWRyZXNzZV9maXNjYWxlX2FubmVlIiwiZGdmaXBfbm9tYnJlX3BhcnRzIiwiZGdmaXBfbm9tYnJlX3BlcnNvbm5lc19hX2NoYXJnZSIsImRnZmlwX3NpdHVhdGlvbl9mYW1pbGlhbGUiLCJkZ2ZpcF9yZXZlbnVfYnJ1dF9nbG9iYWwiLCJkZ2ZpcF9yZXZlbnVfaW1wb3NhYmxlIiwiZGdmaXBfaW1wb3RfcmV2ZW51X25ldF9hdmFudF9jb3JyZWN0aW9ucyIsImRnZmlwX21vbnRhbnRfaW1wb3QiLCJkZ2ZpcF9yZXZlbnVfZmlzY2FsX3JlZmVyZW5jZSIsImRnZmlwX2FubmVlX2ltcG90IiwiZGdmaXBfYW5uZWVfcmV2ZW51cyIsImRnZmlwX2VycmV1cl9jb3JyZWN0aWYiLCJkZ2ZpcF9zaXR1YXRpb25fcGFydGllbGxlIl0sInN1YiI6InN0YWdpbmcgZGV2ZWxvcG1lbnQiLCJpYXQiOjE2NjY4NjQwNzQsInZlcnNpb24iOiIxLjAiLCJleHAiOjE5ODI0ODMyNzR9.u2kMWzll3iCTczUOqMQbpS66VfrVzI2lLiyGEPcKAec*       
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: support@entreprise.api.gouv.fr
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;

namespace EntreprisesApi.Client
{
    /// <summary>
    /// A dictionary in which one key has many associated values.
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TValue">The type of the value associated with the key.</typeparam>
    public class Multimap<TKey, TValue> : IDictionary<TKey, IList<TValue>>
    {
        #region Private Fields

        private readonly Dictionary<TKey, IList<TValue>> _dictionary;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Empty Constructor.
        /// </summary>
        public Multimap()
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>();
        }

        /// <summary>
        /// Constructor with comparer.
        /// </summary>
        /// <param name="comparer"></param>
        public Multimap(IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, IList<TValue>>(comparer);
        }

        #endregion Constructors

        #region Enumerators

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<KeyValuePair<TKey, IList<TValue>>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// To get the enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion Enumerators

        #region Public Members
        /// <summary>
        /// Add values to Multimap
        /// </summary>
        /// <param name="item">Key value pair</param>
        public void Add(KeyValuePair<TKey, IList<TValue>> item)
        {
            if (!TryAdd(item.Key, item.Value))
                throw new InvalidOperationException("Could not add values to Multimap.");
        }

        /// <summary>
        /// Add Multimap to Multimap
        /// </summary>
        /// <param name="multimap">Multimap</param>
        public void Add(Multimap<TKey, TValue> multimap)
        {
            foreach (var item in multimap)
            {
                if (!TryAdd(item.Key, item.Value))
                    throw new InvalidOperationException("Could not add values to Multimap.");
            }
        }

        /// <summary>
        /// Clear Multimap
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Determines whether Multimap contains the specified item.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        /// <returns>true if the Multimap contains the item; otherwise, false.</returns>
        public bool Contains(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Copy items of the Multimap to an array,
        ///     starting at a particular array index.
        /// </summary>
        /// <param name="array">The array that is the destination of the items copied
        ///     from Multimap. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public void CopyTo(KeyValuePair<TKey, IList<TValue>>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified item from the Multimap.
        /// </summary>
        /// <param name="item">Key value pair</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        /// <exception cref="NotImplementedException">Method needs to be implemented</exception>
        public bool Remove(KeyValuePair<TKey, IList<TValue>> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the number of items contained in the Multimap.
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Gets a value indicating whether the Multimap is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add the value to Multimap.</exception>
        public void Add(TKey key, IList<TValue> value)
        {
            if (value != null && value.Count > 0)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    foreach (var k in value) list.Add(k);
                }
                else
                {
                    list = new List<TValue>(value);
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add values to Multimap.");
                }
            }
        }

        /// <summary>
        /// Determines whether the Multimap contains an item with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the Multimap contains an item with
        ///     the key; otherwise, false.</returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Removes item with the specified key from the Multimap.
        /// </summary>
        /// <param name="key">The key to locate in the Multimap.</param>
        /// <returns>true if the item is successfully removed; otherwise, false.</returns>
        public bool Remove(TKey key)
        {
            return TryRemove(key, out var _);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the
        ///     key is found; otherwise, the default value for the type of the value parameter.
        ///     This parameter is passed uninitialized.</param>
        /// <returns> true if the object that implements Multimap contains
        ///     an item with the specified key; otherwise, false.</returns>
        public bool TryGetValue(TKey key, out IList<TValue> value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets or sets the item with the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get or set.</param>
        /// <returns>The value of the specified key.</returns>
        public IList<TValue> this[TKey key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the keys of the Multimap.
        /// </summary>
        public ICollection<TKey> Keys => _dictionary.Keys;

        /// <summary>
        /// Gets a System.Collections.Generic.ICollection containing the values of the Multimap.
        /// </summary>
        public ICollection<IList<TValue>> Values => _dictionary.Values;

        /// <summary>
        ///  Copy the items of the Multimap to an System.Array,
        ///     starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the items copied
        ///     from Multimap. The System.Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            ((ICollection)_dictionary).CopyTo(array, index);
        }

        /// <summary>
        /// Adds an item with the provided key and value to the Multimap.
        /// </summary>
        /// <param name="key">The object to use as the key of the item to add.</param>
        /// <param name="value">The object to use as the value of the item to add.</param>
        /// <exception cref="InvalidOperationException">Thrown when couldn't add value to Multimap.</exception>
        public void Add(TKey key, TValue value)
        {
            if (value != null)
            {
                if (_dictionary.TryGetValue(key, out var list))
                {
                    list.Add(value);
                }
                else
                {
                    list = new List<TValue> { value };
                    if (!TryAdd(key, list))
                        throw new InvalidOperationException("Could not add value to Multimap.");
                }
            }
        }

        #endregion Public Members

        #region Private Members

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryRemove(TKey key, out IList<TValue> value)
        {
            _dictionary.TryGetValue(key, out value);
            return _dictionary.Remove(key);
        }

        /**
         * Helper method to encapsulate generator differences between dictionary types.
         */
        private bool TryAdd(TKey key, IList<TValue> value)
        {
            try
            {
                _dictionary.Add(key, value);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
        #endregion Private Members
    }
}
