using System;
using System.Collections.Generic;
using System.Linq;
using SysAPI.Models;

namespace SysAPI.Models
{
    public class MemberRepository : IMemberRepository
	{
        private List<Member> members = new List<Member>();
        private int _nextId = 1;

		public MemberRepository()
		{
            Add(new Member { email = "test@test.com", password = "qwe", level = 0 });
		}

        public IEnumerable<Member> GetAll()
		{
            return members;
		}

        public Member Get(string id)
		{
            return members.Find(p => p.id == id);
		}

		public Member Add(Member item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
            item.id = _nextId++.ToString();
            members.Add(item);
			return item;
		}

		public void Remove(string id)
		{
            members.RemoveAll(p => p.id == id);
		}

		public bool Update(Member item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
            int index = members.FindIndex(p => p.id == item.id);
			if (index == -1)
			{
				return false;
			}
            members.RemoveAt(index);
            members.Add(item);
			return true;
		}
	}
}