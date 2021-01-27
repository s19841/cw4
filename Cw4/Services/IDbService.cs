using System.Collections.Generic;

namespace Cw4.Services
{
    public interface IDbService<T, in TI>
    {
        public IEnumerable<T> GetEntries();
        public T GetEntry(TI indexNumber);
        public int AddEntry(T entryToAdd);
        public int UpdateEntry(T entryToUpdate);
        public int RemoveEntry(TI idToRemove);
    }
}