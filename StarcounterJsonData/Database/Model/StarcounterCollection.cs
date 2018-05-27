using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    public abstract class StarcounterCollection<T> : IEnumerable<T>, ICollection<T>
    {
        public QueryResultRows<T> Query { get; protected set; }

        public StarcounterCollection()
        {
            this.Query = Db.SQL<T>(this.GetSqlQuery());
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Query.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this.Query.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
        }

        public void Clear()
        {
            this.Query.ToList().ForEach(x => x.Delete());
        }

        public bool Contains(T item)
        {
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var items = this.Query.ToList();

            for (int i = arrayIndex; i < items.Count; i++)
            {
                array[i] = items[i];
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            item.Delete();
            return true;
        }

        #region virtual methods
        protected abstract string GetSqlQuery();
        #endregion
    }
}
