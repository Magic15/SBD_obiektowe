using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Starcounter;

namespace StarcounterJsonData.Database.Model
{
    public abstract class StarcounterRelationCollection<T, TSubject> : IEnumerable<T>, ICollection<T>
    {
        public QueryResultRows<T> Query { get; protected set; }
        public TSubject Subject { get; protected set; }

        public StarcounterRelationCollection(TSubject Subject)
        {
            this.Subject = Subject;
            this.Query = Db.SQL<T>(this.GetSqlQuery(), this.Subject);
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
            this.SetSubject(item, this.Subject);
        }

        public void Clear()
        {
            this.Query.ToList().ForEach(x => this.RemoveSubject(x));
        }

        public bool Contains(T item)
        {
            return this.GetSubject(item).Equals(this.Subject);
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
            if (!this.GetSubject(item).Equals(this.Subject))
            {
                return false;
            }

            this.RemoveSubject(item);
            return true;
        }

        #region virtual methods
        protected abstract string GetSqlQuery();
        protected abstract TSubject GetSubject(T Entity);
        protected abstract void SetSubject(T Entity, TSubject Subject);
        protected abstract void RemoveSubject(T Entity);
        #endregion
    }
}
