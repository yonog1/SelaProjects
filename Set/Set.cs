using System.Text;

namespace Set
{
    public class Set
    {
        private const int SET_LENGTH = 1001;
        private bool[] set = new bool[SET_LENGTH];

        public Set(params int[] arr)
        {
            foreach (int n in arr)
            {
                if (IsValidIndex(n) && !set[n])
                    set[n] = true;
            }
        }

        private bool IsValidIndex(int n)
        {
            return n >= 0 && n < SET_LENGTH;
        }

        public void Insert(int n)
        {
            if (IsValidIndex(n))
            {
                set[n] = true;
            }
        }

        public void Delete(int n)
        {
            if (IsValidIndex(n))
            {
                set[n] = false;
            }
        }

        public bool IsMember(int n)
        {
            if (IsValidIndex(n))
            {
                return set[n];
            }
            return false;
        }

        public bool Subset(Set other)
        {
            for (int i = 0; i < other.set.Length; i++)
            {
                if (other.set[i] == true)
                    if (this.set[i] != true)
                        return false;
            }
            return true;
        }

        public void Union(Set other)
        {
            for (int n = 0; n < other.set.Length; n++)
            {
                this.set[n] = other.set[n] || this.set[n];
            }
        }

        public void Intersection(Set other)
        {
            for (int n = 0; n < other.set.Length; n++)
            {
                this.set[n] = other.set[n] && this.set[n];
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{");
            for (int n = 0; n < set.Length; n++)
            {
                if (set[n])
                    stringBuilder.Append($"{n},");
            }
            if (stringBuilder.Length > 1)
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Set)) return false;
            Set other = (Set)obj;
            for (int i = 0; i < other.set.Length; i++)
            {
                if (other.set[i] != this.set[i])
                    return false;
            }
            return true;
        }
    }
}
